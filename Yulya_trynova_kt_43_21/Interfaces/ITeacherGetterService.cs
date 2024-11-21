
using Microsoft.EntityFrameworkCore;
using Yulya_trynova_kt_43_21.Database;
using Yulya_trynova_kt_43_21.Filters;
using Yulya_trynova_kt_43_21.Models;

namespace Yulya_trynova_kt_43_21.Interfaces
{///////////////
    public interface ITeacherGetterService
    {
        public Task<Teacher[]> GetTeachersByDegreeAsync(TeacherDegreeFilter filter, CancellationToken cancellationToken = default);

        public Task<Teacher[]> GetTeachersByCathedraAsync(TeacherCathedraFilter filter, CancellationToken cancellationToken = default);

        public Task<Teacher[]> GetTeachersByPositionAsync(TeacherPositionFilter filter, CancellationToken cancellationToken = default);

        public Task<Teacher[]> GetTeachersByIDAsync(TeacherIDFilter filter, CancellationToken cancellationToken = default);

        public Task<Teacher[]> GetTeachersByCathedraIDAsync(TeacherCathedraIDFilter filter, CancellationToken cancellationToken = default);

        public Task<Teacher[]> GetTeachersByFIOAsync(TeacherFIOFilter filter, CancellationToken cancellationToken = default);
    }

    public class TeacherGetterService : ITeacherGetterService
    {
        private readonly TeacherDbContext _dbContext;

        public TeacherGetterService(TeacherDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public Task<Teacher[]> GetTeachersByDegreeAsync(TeacherDegreeFilter filter, CancellationToken cancellationToken = default)
        {
            var teachers = _dbContext.Set<Teacher>().Where(t => t.Degree == filter.Degree).ToArrayAsync();
            return teachers;
        }

        public Task<Teacher[]> GetTeachersByCathedraAsync(TeacherCathedraFilter filter, CancellationToken cancellationToken = default)
        {
            var teachers = _dbContext.Set<Teacher>()
                .Where(t => t.Cathedra != null)
                .Where(t => t.Cathedra!.Name == filter.CathedraName).ToArrayAsync();
            return teachers;
        }

        public Task<Teacher[]> GetTeachersByPositionAsync(TeacherPositionFilter filter, CancellationToken cancellationToken = default)
        {
            var teachers = _dbContext.Set<Teacher>().Where(t => t.Position == filter.Position).ToArrayAsync();
            return teachers;


        }
        ////////////////
        public Task<Teacher[]> GetTeachersByIDAsync(TeacherIDFilter filter, CancellationToken cancellationToken = default)
        {
            var teachers = _dbContext.Set<Teacher>().Where(t => t.TeacherId == filter.ID).ToArrayAsync();
            return teachers;


        }

        public Task<Teacher[]> GetTeachersByCathedraIDAsync(TeacherCathedraIDFilter filter, CancellationToken cancellationToken = default)
        {
            var teachers = _dbContext.Set<Teacher>()
              
                .Where(t => t.Cathedra!.CathedraId == filter.CathedraID).ToArrayAsync();
            return teachers;
        }

        public Task<Teacher[]> GetTeachersByFIOAsync(TeacherFIOFilter filter, CancellationToken cancellationToken = default)
        {
            var teachers = _dbContext.Set<Teacher>().Where(t => t.FirstName == filter.FirstName && t.LastName == filter.LastName && t.MiddleName == filter.MiddleName).ToArrayAsync();
            return teachers;
        }

    }
}
