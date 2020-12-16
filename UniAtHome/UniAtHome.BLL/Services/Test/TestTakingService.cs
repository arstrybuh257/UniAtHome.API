using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UniAtHome.BLL.DTOs.Test;
using UniAtHome.BLL.Exceptions;
using UniAtHome.BLL.Interfaces;
using UniAtHome.BLL.Interfaces.Test;
using UniAtHome.DAL.Entities;
using UniAtHome.DAL.Entities.Tests;
using UniAtHome.DAL.Interfaces;
using TestEntity = UniAtHome.DAL.Entities.Tests.Test;

namespace UniAtHome.BLL.Services.Test
{
    public class TestTakingService : ITestTakingService
    {
        private readonly IRepository<TestEntity> tests;

        private readonly IRepository<TestQuestion> questions;

        private readonly IRepository<TestAnswerVariant> answerVariants;

        private readonly IRepository<TestAnsweredQuestion> answeredQuestions;

        private readonly IStudentService studentService;

        private readonly IRepository<Student> students;

        private readonly IRepository<TestAttempt> attempts;

        private readonly IRepository<TestSchedule> schedules;

        private readonly ITestGenerationService testGenerator;

        public TestTakingService(
            IRepository<TestEntity> tests,
            IRepository<TestQuestion> questions,
            IRepository<TestAnswerVariant> answerVariants,
            IRepository<TestAnsweredQuestion> answeredQuestions,
            IStudentService studentService,
            IRepository<Student> students,
            IRepository<TestAttempt> attempts,
            IRepository<TestSchedule> schedules,
            ITestGenerationService testGenerator)
        {
            this.tests = tests;
            this.questions = questions;
            this.answerVariants = answerVariants;
            this.answeredQuestions = answeredQuestions;
            this.studentService = studentService;
            this.students = students;
            this.attempts = attempts;
            this.schedules = schedules;
            this.testGenerator = testGenerator;
        }

        public async Task<TestTakingDTO> StartTestAsync(int id, string email)
        {
            var student = await students.GetSingleOrDefaultAsync(s => s.User.Email == email);
            if (student == null)
            {
                throw new ForbiddenException("The user either is not a student or is not registered!");
            }
            var test = await tests.GetByIdAsync(id);
            if (test == null)
            {
                throw new BadRequestException("The test doesn't exist!");
            }

            await ValidateTestAccessibilityAsync(email, test);

            await ValidateAttemptsMadeAsync(id, email, test);

            await ValidateWhetherTestIsAvailableByTimeAsync(id, email);

            TestAttempt testAttempt = await CreateAndSaveNewAttemptAsync(id, student);

            var generatedTest = await testGenerator.GenerateTestAsync(test);
            generatedTest.AttemptId = testAttempt.Id;
            return generatedTest;
        }

        private async Task ValidateTestAccessibilityAsync(string email, TestEntity test)
        {
            var courses = await studentService.GetStudentsCoursesAsync(new DTOs.Students.StudentsCoursesRequest
            {
                StudentEmail = email
            });
            if (!courses.Any(course => course.Id == test.CourseId))
            {
                throw new ForbiddenException("The student can't take tests of this course!");
            }
        }

        private async Task ValidateAttemptsMadeAsync(int id, string email, TestEntity test)
        {
            int attemptsMade = (await attempts.Find(a => a.User.Email == email && a.TestId == id)).Count();
            if (attemptsMade >= test.AttemptsAllowed)
            {
                throw new ForbiddenException($"Already made {attemptsMade}/{test.AttemptsAllowed} attemts!");
            }
        }

        private async Task ValidateWhetherTestIsAvailableByTimeAsync(int id, string email)
        {
            var groupsOfStudent = (await studentService.GetStudentsGroupsAsync(email))
                            .Select(gr => gr.Id);
            DateTimeOffset now = DateTimeOffset.UtcNow;
            bool isAvailableByTime = (await schedules
                .Find(sch => sch.TestId == id && now > sch.BeginTime && now <= sch.EndTime))
                .Select(sch => sch.GroupId)
                .Intersect(groupsOfStudent).Any();
            if (!isAvailableByTime)
            {
                throw new ForbiddenException("The test isn't scheduled for now");
            }
        }

        private async Task<TestAttempt> CreateAndSaveNewAttemptAsync(int id, Student student)
        {
            var testAttempt = new TestAttempt
            {
                TestId = id,
                UserId = student.UserId,
                BeginTime = DateTimeOffset.UtcNow,
                EndTime = null,
            };

            await attempts.AddAsync(testAttempt);
            await attempts.SaveChangesAsync();
            return testAttempt;
        }

        public async Task SubmitAnswerAsync(AnswerSubmitDTO submit)
        {
            var student = await students.GetSingleOrDefaultAsync(s => s.User.Email == submit.Email);
            var attempt = await attempts.GetByIdAsync(submit.AttemptId);
            if (attempt == null)
            {
                throw new BadRequestException("Not valid attempt!");
            }
            if (student == null)
            {
                throw new ForbiddenException("The user either is not a student or is not registered!");
            }
            if (attempt.UserId != student.UserId)
            {
                throw new ForbiddenException("Isn't the attempt of the user!");
            }
            if (attempt.EndTime != null)
            {
                throw new ForbiddenException("Can't send answers after the attempt is over!");
            }
            await ValidateAnswerTimeAsync(submit, attempt);

            bool isCorrect = await CheckAnswerCorrectnessAsync(submit);

            var previousAnswer = await answeredQuestions.GetSingleOrDefaultAsync(
                aq => aq.AttemptId == submit.AttemptId && aq.QuestionId == submit.QuestionId);
            if (previousAnswer != null)
            {
                previousAnswer.IsCorrect = isCorrect;
                answeredQuestions.Update(previousAnswer);
            }
            else
            {
                var questionAswer = new TestAnsweredQuestion
                {
                    AttemptId = submit.AttemptId,
                    QuestionId = submit.QuestionId,
                    IsCorrect = isCorrect
                };
                await answeredQuestions.AddAsync(questionAswer);
            }
            await answeredQuestions.SaveChangesAsync();
        }

        private async Task ValidateAnswerTimeAsync(AnswerSubmitDTO submit, TestAttempt attempt)
        {
            var test = await tests.GetByIdAsync(attempt.TestId);
            if (attempt.BeginTime.AddMinutes(test.DurationMinutes) < DateTimeOffset.UtcNow)
            {
                await FinishAsync(attempt.Id, submit.Email);
                throw new ForbiddenException("The time is over!");
            }
        }

        private async Task<bool> CheckAnswerCorrectnessAsync(AnswerSubmitDTO submit)
        {
            var correctAnswers = await answerVariants.Find(
                            a => a.QuestionId == submit.QuestionId && a.IsCorrect);
            var correctAnswersIds = correctAnswers.Select(a => a.Id);
            bool allVaraintsAreCorrect = correctAnswers.Count() == submit.SelectedAnswers.Count()
                && submit.SelectedAnswers.Intersect(correctAnswersIds).Count() == submit.SelectedAnswers.Count();
            return allVaraintsAreCorrect;
        }

        public async Task<TestFinishedDTO> FinishAsync(int attemptId, string email)
        {
            var attempt = await attempts.GetByIdAsync(attemptId);
            var student = await students.GetSingleOrDefaultAsync(s => s.User.Email == email);
            if (student == null)
            {
                throw new ForbiddenException("The user either is not a student or is not registered!");
            }
            if (attempt == null)
            {
                throw new BadRequestException("Not valid attempt!");
            }
            if (attempt.UserId != student.UserId)
            {
                throw new ForbiddenException("Isn't the attempt of the user!");
            }
            if (attempt.EndTime != null)
            {
                throw new BadRequestException("The test attempt is already finished!");
            }

            attempt.EndTime = DateTimeOffset.UtcNow;
            attempts.Update(attempt);
            await attempts.SaveChangesAsync();

            return await GetFinishedAttemptResultsAsync(attempt);
        }

        private async Task<TestFinishedDTO> GetFinishedAttemptResultsAsync(TestAttempt attempt)
        {
            var test = await tests.GetByIdAsync(attempt.Id);
            var allQuestions = await questions.Find(q => q.TestId == test.Id);
            float questionsWeightSum = allQuestions.Sum(q => q.Weight);
            var correctAnswersOfUser = await answeredQuestions
                .Find(aq => aq.AttemptId == attempt.Id && aq.IsCorrect);
            var correctAnswersWeight = allQuestions
                .Where(q => correctAnswersOfUser
                    .Any(ca => ca.QuestionId == q.Id))
                .Sum(q => q.Weight);

            float mark = test.MaxMark * correctAnswersWeight / questionsWeightSum;

            return new TestFinishedDTO
            {
                TestId = test.Id,
                AttemptId = attempt.Id,
                Begin = attempt.BeginTime,
                End = attempt.EndTime.Value,
                CorrectAnswers = correctAnswersOfUser.Count(),
                TotalQuestions = allQuestions.Count(),
                Mark = mark,
                MaxMark = test.MaxMark,
            };
        }

        public async Task<IEnumerable<TestFinishedDTO>> GetAllFinishedAttemptsAsync(int testId, string email)
        {
            var test = await tests.GetByIdAsync(testId);
            var finishedAttempts = await attempts.Find(
                a => a.User.Email == email && a.TestId == testId);
            var timedOutAttempts = finishedAttempts.Where(
                a => a.EndTime == null && a.BeginTime.AddMinutes(test.DurationMinutes) < DateTimeOffset.UtcNow);
            foreach(var expiredAttempt in timedOutAttempts)
            {
                await FinishAsync(expiredAttempt.Id, email);
            }

            var info = new List<TestFinishedDTO>();
            foreach (var attempt in finishedAttempts.Concat(timedOutAttempts))
            {
                info.Add(await GetFinishedAttemptResultsAsync(attempt));
            }
            return info;
        }
    }
}
