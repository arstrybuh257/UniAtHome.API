using UniAtHome.BLL.DTOs.Test;

namespace UniAtHome.BLL.Interfaces.Test
{
    public interface ITestCreationService
    {
        int CreateTest(TestCreateDTO createDTO);

        void DeleteTest(int testId);

        void EditTest(TestDTO editDTO);

        TestDTO GetTest(int testId);
    }
}
