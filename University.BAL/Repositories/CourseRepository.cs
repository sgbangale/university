using System;
using University.Common.Models;
using University.DAL;

namespace University.BAL.Repositories
{
    public class CourseRepository : GenericRepository<Course>, ICourseRepository, IDisposable
    {
        public CourseRepository(UniversityContext context) : base(context)
        {
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public int UpdateCourseCredits(int multiplier)
        {
            return context.Database.ExecuteSqlCommand("UPDATE Course SET Credits = Credits * {0}", multiplier);
        }
    }
}
