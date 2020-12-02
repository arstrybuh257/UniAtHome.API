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
using UniAtHome.DAL.Repositories;
using TestEntity = UniAtHome.DAL.Entities.Tests.Test;

namespace UniAtHome.BLL.Services.Test
{
    public class TestTakingService : ITestTakingService
    {
        private readonly IRepository<TestEntity> tests;

        private readonly IRepository<TestAnswerVariant> answerVariants;

        private readonly IRepository<TestAnsweredQuestion> answeredQuestions;

        private readonly IStudentService studentService;

        private readonly IRepository<Student> students;

        private readonly IRepository<TestAttempt> attempts;

        private readonly IRepository<TestSchedule> schedules;

        private readonly IGroupService groupService;

        private readonly ITestGenerationService testGenerator;

        public async Task<TestTakingDTO> StartTestAsync(int id, string email)
        {
            // TODO: check attempts allowed and made
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
            var courses = await studentService.GetStudentsCoursesAsync(new DTOs.Students.StudentsCoursesRequest
            {
                StudentEmail = email
            });
            if (!courses.Any(course => course.Id == test.CourseId))
            {
                throw new ForbiddenException("The student can't take tests of this course!");
            }
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

            var testAttempt = new TestAttempt
            {
                TestId = id,
                UserId = student.UserId,
                BeginTime = DateTimeOffset.UtcNow,
                EndTime = null,
            };

            await attempts.AddAsync(testAttempt);
            await attempts.SaveChangesAsync();

            var generatedTest = await testGenerator.GenerateTestAsync(test);
            generatedTest.AttemptId = testAttempt.Id;
            return generatedTest;
        }

        public async Task SubmitAnswerAsync(AnswerSubmitDTO submit)
        {
            var student = await students.GetSingleOrDefaultAsync(s => s.User.Email == submit.Email);
            var attempt = await attempts.GetByIdAsync(submit.AttempId);
            if (attempt == null)
            {
                throw new BadRequestException("Not valid attempt!");
            }
            if (attempt.UserId == student.UserId)
            {
                throw new ForbiddenException("Isn't the attempt of the user!");
            }
            if (attempt.EndTime != null)
            {
                throw new ForbiddenException("Can't send answers after the attempt is over!");
            }
            var test = await tests.GetByIdAsync(attempt.TestId);
            if (attempt.BeginTime.AddMinutes(test.DurationMinutes) >= DateTimeOffset.UtcNow)
            {
                await FinishAsync(attempt.Id, submit.Email);
                throw new ForbiddenException("The time is over!");
            }

            var correctAnswers = await answerVariants.Find(
                a => a.QuestionId == submit.QuestionId && a.IsCorrect);
            var correctAnswersIds = correctAnswers.Select(a => a.Id);
            bool allVaraintsAreCorrect = correctAnswers.Count() == submit.SelectedAnswers.Count()
                && submit.SelectedAnswers.Intersect(correctAnswersIds).Count() == submit.SelectedAnswers.Count();

            var previousAnswer = await answeredQuestions.GetSingleOrDefaultAsync(
                aq => aq.AttempId == submit.AttempId && aq.QuestionId == submit.QuestionId);
            if (previousAnswer != null)
            {
                previousAnswer.IsCorrect = allVaraintsAreCorrect;
                answeredQuestions.Update(previousAnswer);
            }
            else
            {
                var questionAswer = new TestAnsweredQuestion
                {
                    AttempId = submit.AttempId,
                    QuestionId = submit.QuestionId,
                    IsCorrect = allVaraintsAreCorrect
                };
                await answeredQuestions.AddAsync(questionAswer);
            }
            await answeredQuestions.SaveChangesAsync();
        }

        public async Task<TestFinishedDTO> FinishAsync(int attemptId, string email)
        {
            throw new NotImplementedException();
        }
        public async Task<IEnumerable<TestFinishedDTO>> GetAllAttemptsAsync(int testId, string email)
        {
            throw new NotImplementedException();
        }
    }
}
