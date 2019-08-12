using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using University.DAL;
using Moq;
using Moq.Protected;
using University.Tests.Mocks;
using University.Common.Models;

namespace University.BAL.Repositories.Tests
{
    [TestClass()]
    public class StudentRepositoryTests
    {
        Mock<UniversityContext> dbContext;
        private IStudentRepository sRep;

        [TestInitialize()]
        public void Initialize()
        {
            dbContext = UniversityContextMock.SetupMock();
            sRep = new StudentRepository(dbContext.Object);
        }

        [TestMethod()]
        public void StudentRepositoryTest()
        {
            Assert.IsNotNull(sRep);
        }

        [TestMethod()]
        public void GetStudentsTest()
        {
            var student = new Student
            {
                PersonID = 1,
                FirstMidName = "Carson",
                LastName = "Alexander",
                EnrollmentDate = DateTime.Parse("2010-09-01")
            };

            sRep.InsertStudent(student);
            var result = sRep.GetStudents();
            Assert.AreEqual(1, (result as IList<Student>).Count);
        }

        [TestMethod()]
        public void GetStudentByIDTest()
        {
            var student = new Student
            {
                PersonID = 1,
                FirstMidName = "Carson",
                LastName = "Alexander",
                EnrollmentDate = DateTime.Parse("2010-09-01")
            };

            sRep.InsertStudent(student);
            var result = sRep.GetStudentByID(student.PersonID);

            Assert.AreEqual(student.PersonID, result.PersonID);
        }

        [TestMethod()]
        public void InsertStudentTest()
        {
            var student = new Student
            {
                PersonID = 1,
                FirstMidName = "Carson",
                LastName = "Alexander",
                EnrollmentDate = DateTime.Parse("2010-09-01")
            };

            sRep.InsertStudent(student);
            var result = sRep.GetStudents();
            Assert.AreEqual(1, (result as IList<Student>).Count);
        }

        [TestMethod()]
        public void DeleteStudentTest()
        {
            var student = new Student
            {
                PersonID = 1,
                FirstMidName = "Carson",
                LastName = "Alexander",
                EnrollmentDate = DateTime.Parse("2010-09-01")
            };

            sRep.Insert(student);
            sRep.Save();
            sRep.DeleteStudent(student.PersonID);
            var data = sRep.GetAll();
            Assert.AreEqual(0, data.Count());
        }

        [TestMethod()]
        public void UpdateStudentTest()
        {
            var student = new Student
            {
                PersonID = 1,
                FirstMidName = "Carson",
                LastName = "Alexander",
                EnrollmentDate = DateTime.Parse("2010-09-01")
            };

            sRep.Insert(student);
            sRep.Save();
            var data = sRep.GetById(student.PersonID);
            data.LastName = "John";
            sRep.UpdateStudent(data);
            dbContext.Setup(x => x.SetModified(data)).Verifiable();
            sRep.Save();
            var updatedData = sRep.GetById(student.PersonID);
            Assert.AreEqual(data.LastName, updatedData.LastName);
        }
    }
}