using University.Common.Models;

namespace University.BAL.Repositories
{
    public interface IUnitOfWork
    {
        IStudentRepository Student { get; }
        ICourseRepository Course { get; }
        IGenericRepository<Department> Department { get; }
        IGenericRepository<Instructor> Instructor { get; }
        IGenericRepository<Enrollment> Enrollment { get; }
        void Commit();

    }
}
