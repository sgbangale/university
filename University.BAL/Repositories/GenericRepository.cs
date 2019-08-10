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
            context.Entry(obj).State = EntityState.Modified;
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
    }


    //public class GenericRepository<TEntity> where TEntity : class
    //{
    //    internal UniversityContext context;
    //    internal DbSet<TEntity> dbSet;

    //    public GenericRepository(UniversityContext _context)
    //    {
    //        this.context = _context ?? throw new ArgumentNullException();
    //        this.dbSet = context.Set<TEntity>();
    //    }

    //    public virtual IEnumerable<TEntity> GetWithRawSql(string query, params object[] parameters)
    //    {
    //        return dbSet.SqlQuery(query, parameters).ToList();
    //    }

    //    public virtual IEnumerable<TEntity> Get(
    //        Expression<Func<TEntity, bool>> filter = null,
    //        Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
    //        string includeProperties = "")
    //    {
    //        IQueryable<TEntity> query = dbSet;

    //        if (filter != null)
    //        {
    //            query = query.Where(filter);
    //        }

    //        foreach (var includeProperty in includeProperties.Split
    //            (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
    //        {
    //            query = query.Include(includeProperty);
    //        }

    //        if (orderBy != null)
    //        {
    //            return orderBy(query).ToList();
    //        }
    //        else
    //        {
    //            return query.ToList();
    //        }
    //    }

    //    public virtual TEntity GetByID(object id)
    //    {
    //        return dbSet.Find(id);
    //    }

    //    public virtual void Insert(TEntity entity)
    //    {
    //        dbSet.Add(entity);
    //    }

    //    public virtual void Delete(object id)
    //    {
    //        TEntity entityToDelete = dbSet.Find(id);
    //        Delete(entityToDelete);
    //    }

    //    public virtual void Delete(TEntity entityToDelete)
    //    {
    //        if (context.Entry(entityToDelete).State == EntityState.Detached)
    //        {
    //            dbSet.Attach(entityToDelete);
    //        }
    //        dbSet.Remove(entityToDelete);
    //    }

    //    public virtual void Update(TEntity entityToUpdate)
    //    {
    //        dbSet.Attach(entityToUpdate);
    //        context.Entry(entityToUpdate).State = EntityState.Modified;
    //    }
    //}
}
