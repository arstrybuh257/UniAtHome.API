using System.Security.Claims;
using System.Threading.Tasks;
using UniAtHome.BLL.Interfaces;
using UniAtHome.DAL.Constants;

namespace UniAtHome.WebAPI
{
    public static class UniversityAccessControlExtension
    {
        public static async Task<bool> IsUniversityStudentOrHigherAsync(
            this ClaimsPrincipal user,
            int universityId,
            IUniversityService universityService)
        {
            if (user.IsInRole(RoleName.STUDENT))
            {
                return await universityService.HasStudentAsync(universityId, user.Identity.Name);
            }

            bool isGreaterAccess = await user.IsUniversityTeacherOrHigherAsync(universityId, universityService);
            return isGreaterAccess;
        }

        public static async Task<bool> IsUniversityTeacherOrHigherAsync(
            this ClaimsPrincipal user,
                int universityId,
                IUniversityService universityService)
        {
            if (user.IsInRole(RoleName.TEACHER))
            {
                return await universityService.HasTeacherAsync(universityId, user.Identity.Name);
            }

            bool isGreaterAccess = await user.IsUniversityAdminOrHigherAsync(universityId, universityService);
            return isGreaterAccess;
        }

        public static async Task<bool> IsUniversityAdminOrHigherAsync(
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
                return await universityService.HasUniversityAdminAsync(universityId, user.Identity.Name);
            }

            return false;
        }
    }
}
