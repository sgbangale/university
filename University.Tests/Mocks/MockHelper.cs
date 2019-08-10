using Moq;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace University.Tests.Mocks
{
    public class MockHelper
    {
        public static DbSet<T> GetDbSetMock<T>(IEnumerable<T> items = null) where T : class
        {
            if (items == null)
            {
                items = new T[0];
            }

            var dbSetMock = new Mock<DbSet<T>>();
            var q = dbSetMock.As<IQueryable<T>>();

            q.Setup(x => x.GetEnumerator()).Returns(items.GetEnumerator);

            return dbSetMock.Object;
        }

        //public static DbSet<T> GetQueryableMockDbSet<T>(List<T> sourceList) where T : class
        //{
        //    var queryable = sourceList.AsQueryable();

        //    var dbSet = new Mock<DbSet<T>>();
        //    dbSet.As<IQueryable<T>>().Setup(m => m.Provider).Returns(queryable.Provider);
        //    dbSet.As<IQueryable<T>>().Setup(m => m.Expression).Returns(queryable.Expression);
        //    dbSet.As<IQueryable<T>>().Setup(m => m.ElementType).Returns(queryable.ElementType);
        //    dbSet.As<IQueryable<T>>().Setup(m => m.GetEnumerator()).Returns(() => queryable.GetEnumerator());
        //    dbSet.Setup(d => d.Add(It.IsAny<T>())).Callback<T>((s) => sourceList.Add(s));

        //    return dbSet.Object;
        //}
    }
}
