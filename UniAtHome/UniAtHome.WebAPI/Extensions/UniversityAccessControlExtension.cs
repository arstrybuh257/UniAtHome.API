using System.Security.Claims;
using System.Threading.Tasks;
using UniAtHome.BLL.Interfaces;
using UniAtHome.DAL.Constants;

namespace UniAtHome.WebAPI
{
    public static class UniversityAccessControlExtension
    {
        public static async Task<bool> HasStudentOrHigherAccessToUniversity(
            this ClaimsPrincipal user,
            int universityId,
            IUniversityService universityService)
        {
            if (user.IsInRole(RoleName.STUDENT))
            {
                return await universityService.HasStudent(universityId, user.Identity.Name);
            }

            bool isGreaterAccess = await user.HasTeacherOrHigherAccessToUniversity(universityId, universityService);
            return isGreaterAccess;
        }

        public static async Task<bool> HasTeacherOrHigherAccessToUniversity(
            this ClaimsPrincipal user,
                int universityId,
                IUniversityService universityService)
        {
            if (user.IsInRole(RoleName.TEACHER))
            {
                return await universityService.HasTeacher(universityId, user.Identity.Name);
            }

            bool isGreaterAccess = await user.HasUniversityAdminOrHigherAccessToUniversity(universityId, universityService);
            return isGreaterAccess;
        }

        public static async Task<bool> HasUniversityAdminOrHigherAccessToUniversity(
            this ClaimsPrincipal user,
                int universityId,
                IUniversityService universityService)
        {
            if (user.IsInRole(RoleName.ADMIN))
            {
                return true;
            }

            if (user.IsInRole(RoleName.UNIVERSITY_ADMIN))
            {
                return await universityService.HasUniversityAdmin(universityId, user.Identity.Name);
            }

            return false;
        }
    }
}
