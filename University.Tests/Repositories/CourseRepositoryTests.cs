using Microsoft.VisualStudio.TestTools.UnitTesting;
using University.BAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using University.DAL;
using University.Tests.Mocks;

namespace University.BAL.Repositories.Tests
{
    [TestClass()]
    public class CourseRepositoryTests
    {
        Mock<UniversityContext> dbContext;
        private ICourseRepository cRep;

        [TestInitialize()]
        public void Initialize()
        {
            dbContext = UniversityContextMock.SetupMock();
        }

        [TestMethod()]
        public void CourseRepositoryTest()
        {
            cRep = new CourseRepository(dbContext.Object);
            Assert.IsNotNull(cRep);
        }

        [TestMethod()]
        public void UpdateCourseCreditsTest()
        {
            
            Mock<CourseRepository> courseRepository = new Mock<CourseRepository>(MockBehavior.Strict, new object[] { dbContext.Object });
       //     courseRepository.Setup(x => x.UpdateCourseCredits(It.IsAny<int>())).Verifiable();
            var data = courseRepository.Object.UpdateCourseCredits(1);
            Assert.AreEqual(1, data);
        }
    }
}