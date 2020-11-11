using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using UniAtHome.DAL.Entities;
using UniAtHome.DAL.Interfaces;

namespace UniAtHome.DAL.Repositories
{
    public sealed class UniversityRepository : Repository<University>, IUniversityRepository
    {
        public UniversityRepository(DbContext context) : base(context)
        {
        }

        public Task<bool> HasUniversityAdminAsync(int universityId, string userName)
        {
            return context.Set<UniversityAdmin>()
                .AnyAsync(uadmin => uadmin.UniversityId == universityId && uadmin.User.UserName == userName);
        }

        public Task<bool> HasTeacherAsync(int universityId, string userName)
        {
            return context.Set<Teacher>()
                .AnyAsync(teacher => teacher.UniversityId == universityId && teacher.User.UserName == userName);
        }

        public Task<bool> HasStudentAsync(int universityId, string userName)
        {
            return context.Set<Student>()
                .AnyAsync(student => student.UniversityId == universityId && student.User.UserName == userName);
        }
    }
}
