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
        private IGenericRepository<Student> gRep;

        [TestInitialize()]
        public void Initialize()
        {
            dbContext = UniversityContextMock.SetupMock();
            gRep = new GenericRepository<Student>(dbContext.Object);
        }

        [TestMethod()]
        public void GenericRepositoryTest()
        {
            Assert.IsNotNull(gRep);
        }

        [TestMethod()]
        public void GetAllTest()
        {
            var student = new Student
            {
                PersonID = 1,
                FirstMidName = "Carson",
                LastName = "Alexander",
                EnrollmentDate = DateTime.Parse("2010-09-01")
            };

            gRep.Insert(student);
            gRep.Save();
            var data = gRep.GetAll();
            Assert.AreEqual(1, data.Count());
        }

        [TestMethod()]
        public void GetByIdTest()
        {
            var student = new Student
            {
                PersonID = 1,
                FirstMidName = "Carson",
                LastName = "Alexander",
                EnrollmentDate = DateTime.Parse("2010-09-01")
            };

            gRep.Insert(student);
            gRep.Save();
            var data = gRep.GetById(student.PersonID);
            Assert.AreEqual(student.PersonID, data.PersonID);
        }

        [TestMethod()]
        public void InsertTest()
        {
            var student = new Student
            {

                FirstMidName = "Carson",
                LastName = "Alexander",
                EnrollmentDate = DateTime.Parse("2010-09-01")
            };

            gRep.Insert(student);
            gRep.Save();
            dbContext.Verify(x => x.SaveChanges(), Times.Once);
        }

        [TestMethod()]
        public void UpdateTest()
        {
            var student = new Student
            {
                PersonID = 1,
                FirstMidName = "Carson",
                LastName = "Alexander",
                EnrollmentDate = DateTime.Parse("2010-09-01")
            };

            gRep.Insert(student);
            gRep.Save();
            var data = gRep.GetById(student.PersonID);
            data.LastName = "John";
            gRep.Update(data);
            dbContext.Setup(x => x.SetModified(data)).Verifiable();
            gRep.Save();
            var updatedData = gRep.GetById(student.PersonID);
            Assert.AreEqual(data.LastName, updatedData.LastName);
        }

        [TestMethod()]
        public void DeleteTest()
        {
            var student = new Student
            {
                PersonID = 1,
                FirstMidName = "Carson",
                LastName = "Alexander",
                EnrollmentDate = DateTime.Parse("2010-09-01")
            };

            gRep.Insert(student);
            gRep.Save();
            gRep.Delete(student.PersonID);
            var data = gRep.GetAll();
            Assert.AreEqual(0, data.Count());
        }

        [TestMethod()]
        public void SaveTest()
        {
            var student = new Student
            {

                FirstMidName = "Carson",
                LastName = "Alexander",
                EnrollmentDate = DateTime.Parse("2010-09-01")
            };

            gRep.Insert(student);
            gRep.Save();
            dbContext.Verify(x => x.SaveChanges());
        }

        [TestMethod()]
        public void AddRangeTest()
        {
            var students = new List<Student>
            {
                new Student { FirstMidName = "Carson",   LastName = "Alexander",
                    EnrollmentDate = DateTime.Parse("2010-09-01") },
                new Student { FirstMidName = "Meredith", LastName = "Alonso",
                    EnrollmentDate = DateTime.Parse("2012-09-01") },
                new Student { FirstMidName = "Arturo",   LastName = "Anand",
                    EnrollmentDate = DateTime.Parse("2013-09-01") },
                new Student { FirstMidName = "Gytis",    LastName = "Barzdukas",
                    EnrollmentDate = DateTime.Parse("2012-09-01") },
                new Student { FirstMidName = "Yan",      LastName = "Li",
                    EnrollmentDate = DateTime.Parse("2012-09-01") },
                new Student { FirstMidName = "Peggy",    LastName = "Justice",
                    EnrollmentDate = DateTime.Parse("2011-09-01") },
                new Student { FirstMidName = "Laura",    LastName = "Norman",
                    EnrollmentDate = DateTime.Parse("2013-09-01") },
                new Student { FirstMidName = "Nino",     LastName = "Olivetto",
                    EnrollmentDate = DateTime.Parse("2005-09-01") }
            };

            gRep.AddRange(students);
            gRep.Save();
            var result = gRep.GetAll();
            Assert.AreEqual(students.Count, result.Count());
        }
    }
}