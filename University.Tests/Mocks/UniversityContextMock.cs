using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using University.Common.Models;
using University.DAL;

namespace University.Tests.Mocks
{
    public class UniversityContextMock
    {
        public static Mock<UniversityContext> SetupMock()
        {
            var mockContext = new Mock<UniversityContext>();
            
            //student
            var studentSet = MockHelper.GetDbSetMock<Student>();
            mockContext.Setup(x => x.Students).Returns(studentSet);
            mockContext.Setup(x => x.Set<Student>()).Returns(studentSet);
            
            //course
            var courseSet = MockHelper.GetDbSetMock<Course>();
            mockContext.Setup(x => x.Courses).Returns(courseSet);
            mockContext.Setup(x => x.Set<Course>()).Returns(courseSet);
            
            //department
            var departmentSet = MockHelper.GetDbSetMock<Department>();
            mockContext.Setup(x => x.Departments).Returns(departmentSet);
            mockContext.Setup(x => x.Set<Department>()).Returns(departmentSet);
            
            //Instructor
            var instructorSet = MockHelper.GetDbSetMock<Instructor>();
            mockContext.Setup(x => x.Instructors).Returns(instructorSet);
            mockContext.Setup(x => x.Set<Instructor>()).Returns(instructorSet);

            return mockContext;

        }

    }
}
