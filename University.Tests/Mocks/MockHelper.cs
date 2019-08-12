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
        public static DbSet<T> GetDbSetMock<T>(List<T> items = null, Func<T, object> primaryKey = null) where T : class
        {
            if (items == null)
            {
                items = new List<T>();
            }

            var dbSetMock = new Mock<DbSet<T>>();
            var q = dbSetMock.As<IQueryable<T>>();

            q.Setup(x => x.GetEnumerator()).Returns(items.AsQueryable().GetEnumerator);
            dbSetMock.Setup(d => d.Add(It.IsAny<T>())).Callback<T>((s) => items.Add(s));

            if (primaryKey != null)
            {
                dbSetMock.Setup(set => set.Find(It.IsAny<object[]>())).Returns((object[] input) => items.SingleOrDefault(x => (int)primaryKey(x) == (int)input.First()));
            }

            dbSetMock.Setup(d => d.Remove(It.IsAny<T>())).Callback<T>((s) => items.Remove(s));
            dbSetMock.Setup(d => d.AddRange(It.IsAny<IEnumerable<T>>())).Callback<IEnumerable<T>>((s) => items.AddRange(s));

            return dbSetMock.Object;
        }
    }
}
