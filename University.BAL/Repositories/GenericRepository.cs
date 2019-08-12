using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using University.DAL;
using System.Data.Entity;
using System.Linq.Expressions;

namespace University.BAL.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        internal UniversityContext context;
        internal DbSet<T> table;

        public GenericRepository(UniversityContext _context)
        {
            this.context = _context;
            this.table = context.Set<T>();
        }
        public IEnumerable<T> GetAll()
        {
            return table.ToList();
        }
        public T GetById(object id)
        {
            return table.Find(id);
        }
        public void Insert(T obj)
        {
            table.Add(obj);
        }
        public void Update(T obj)
        {
            table.Attach(obj);
            context.SetModified<T>(obj);
        }
        public void Delete(object id)
        {
            T existing = table.Find(id);
            table.Remove(existing);
        }
        public void Save()
        {
            context.SaveChanges();
        }

        public void AddRange(IEnumerable<T> obj)
        {
            table.AddRange(obj);
        }
    }
}
