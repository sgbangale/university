using Microsoft.VisualStudio.TestTools.UnitTesting;
using University.BAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using University.Tests.Mocks;
using Moq;
using University.DAL;
using University.Common.Models;

namespace University.BAL.Repositories.Tests
{
    [TestClass()]
    public class GenericRepositoryTests
    {
        Mock<UniversityContext> dbContext;
        public GenericRepositoryTests()
        {
            dbContext = UniversityContextMock.SetupMock();
        }
        [TestMethod()]
        public void GenericRepositoryTest()
        {
            var gRep = new GenericRepository<Student>(dbContext.Object);
            Assert.IsNotNull(gRep);
        }

        [TestMethod()]
        public void GetAllTest()
        {
            var student = new Student
            {
                FirstMidName = "Carson",
                LastName = "Alexander",
                EnrollmentDate = DateTime.Parse("2010-09-01")
            };
            var gRep = new GenericRepository<Student>(dbContext.Object);
            gRep.Insert(student);
            gRep.Save();
            var data = gRep.GetAll();
        }

        [TestMethod()]
        public void GetByIdTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void InsertTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void UpdateTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void DeleteTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void SaveTest()
        {
            Assert.Fail();
        }
    }
}