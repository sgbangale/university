using Microsoft.VisualStudio.TestTools.UnitTesting;
using University.Tests.Mocks;
using Moq;
using University.DAL;
using University.BAL.Repositories;
using System;

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
        public void CommitTest()
        {
            IUnitOfWork uow = new Repositories.UnitOfWork(dbContext.Object);
            uow.Student.Insert(new Common.Models.Student { EnrollmentDate = DateTime.Now, FirstMidName = "Suraj", LastName = "Bangale" });
            uow.Student.Save();
            dbContext.Verify(x => x.SaveChanges());
            Assert.Fail();
        }
    }
}