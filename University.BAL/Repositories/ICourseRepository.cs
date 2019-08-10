using System;
using System.Collections.Generic;
using University.Common.Models;

namespace University.BAL.Repositories
{
    public interface ICourseRepository : IDisposable, IGenericRepository<Course>
    {
        int UpdateCourseCredits(int multiplier);
    }
}
