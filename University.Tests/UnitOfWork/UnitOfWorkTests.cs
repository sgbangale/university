using Microsoft.VisualStudio.TestTools.UnitTesting;
using University.Tests.Mocks;
using Moq;
using University.DAL;
using University.BAL.Repositories;
using System;
using System.Collections;

namespace University.BAL.UnitOfWork.Tests
{
    [TestClass()]
    public class UnitOfWorkTests
    {
        Mock<UniversityContext> dbContext;
        public UnitOfWorkTests()
        {
            dbContext = UniversityContextMock.SetupMock();
        }

        [TestMethod()]
        public void UnitOfWorkTest()
        {
            IUnitOfWork uow = new Repositories.UnitOfWork(dbContext.Object);
            Assert.IsNotNull(uow);
        }

        [TestMethod()]
        public void UnitOfWorkTest_Student()
        {
            IUnitOfWork uow = new Repositories.UnitOfWork(dbContext.Object);
            Assert.IsNotNull(uow.Student);
        }

        [TestMethod()]
        public void UnitOfWorkTest_Course()
        {
            IUnitOfWork uow = new Repositories.UnitOfWork(dbContext.Object);
            Assert.IsNotNull(uow.Course);
        }

        [TestMethod()]
        public void UnitOfWorkTest_Department()
        {
            IUnitOfWork uow = new Repositories.UnitOfWork(dbContext.Object);
            Assert.IsNotNull(uow.Department);
        }

        [TestMethod()]
        public void UnitOfWorkTest_Enrollment()
        {
            IUnitOfWork uow = new Repositories.UnitOfWork(dbContext.Object);
            Assert.IsNotNull(uow.Enrollment);
        }

        [TestMethod()]
        public void UnitOfWorkTest_Instructor()
        {
            IUnitOfWork uow = new Repositories.UnitOfWork(dbContext.Object);
            Assert.IsNotNull(uow.Instructor);
        }

        [TestMethod()]
        public void CommitTest()
        {
            IUnitOfWork uow = new Repositories.UnitOfWork(dbContext.Object);
            uow.Student.Insert(new Common.Models.Student { EnrollmentDate = DateTime.Now, FirstMidName = "Suraj", LastName = "Bangale" });
            uow.Commit();
            dbContext.Verify(x => x.SaveChanges());
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException), "dbContext should not be null")]
        public void UnitOfWorkNullContext()
        {
            IUnitOfWork uow = new Repositories.UnitOfWork(null);
        }
    }
}