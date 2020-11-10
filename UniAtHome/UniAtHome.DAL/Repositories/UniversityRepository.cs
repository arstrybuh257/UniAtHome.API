using Microsoft.EntityFrameworkCore;
using UniAtHome.DAL.Entities;
using UniAtHome.DAL.Interfaces;

namespace UniAtHome.DAL.Repositories
{
    public sealed class UniversityRepository : Repository<University>, IUniversityRepository
    {
        public UniversityRepository(DbContext context) : base(context)
        {
        }
    }
}
