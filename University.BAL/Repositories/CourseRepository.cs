using System;
using University.Common.Models;
using University.DAL;

namespace University.BAL.Repositories
{
    public class CourseRepository : GenericRepository<Course>, ICourseRepository
    {
        public CourseRepository(UniversityContext context) : base(context)
        {
        }

        public int UpdateCourseCredits(int multiplier)
        {
            return context.ExecuteSqlCommand("UPDATE Course SET Credits = Credits * {0}", multiplier);
        }
    }
}
