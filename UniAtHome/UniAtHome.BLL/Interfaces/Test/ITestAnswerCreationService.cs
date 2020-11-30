using UniAtHome.BLL.DTOs.Test;

namespace UniAtHome.BLL.Interfaces.Test
{
    public interface ITestAnswerCreationService
    {
        int CreateAnswerVariant(TestAnswerVariantCreateDTO createDTO);

        void DeleteAnswerVariant(int answerId);

        void EditAnswerVariant(TestAnswerVariantDTO editDTO);

        TestAnswerVariantDTO GetAnswerVariant(int answerId);
    }
}
