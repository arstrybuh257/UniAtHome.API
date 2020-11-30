using UniAtHome.BLL.DTOs.Test;

namespace UniAtHome.BLL.Interfaces.Test
{
    public interface ITestQuestionCreationService
    {
        int CreateQuestion(TestQuestionCreateDTO createDTO);

        void DeleteQuestion(int questionId);

        void EditQuestion(TestQuestionDTO editDTO);

        TestQuestionDTO GetQuestion(int questionId);
    }
}
