using DataAccessLayer.Abstract;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace DataAccessLayer.Concrete.Repositories
{
    public class GenericRepository<T> : IRepository<T> where T : class
    {
        Context context = new Context();
        DbSet<T> _object;

        public GenericRepository()
        {
            _object = context.Set<T>();
        }
        public void Delete(T p)
        {
            //var entityToDelete = context.Entry(p);
            //entityToDelete.State = EntityState.Deleted;
            _object.Remove(p);
            context.SaveChanges();
        }

        public List<T> Get()
        {
            return _object.ToList();
        }

        public List<T> Get(Expression<Func<T, bool>> filter)
        {
            return _object.Where(filter).ToList() ;
        }

        public T GetByFilter(Expression<Func<T, bool>> filter)
        {
            return _object.SingleOrDefault(filter);
        }

        public void Insert(T p)
        {
            var entityToAdd = context.Entry(p);
            entityToAdd.State = EntityState.Added;
            //_object.Add(entityToAdd.);
            context.SaveChanges();
        }

        public void Update(T p)
        {
            var entityToUpdate = context.Entry(p);
            entityToUpdate.State = EntityState.Modified;
            context.SaveChanges();
        }
    }
}
