using JG_Domain.Entities.NotMapped;
using JG_Domain.Interface;
using JG_Infra.Config;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;

namespace JG_Infra.Repository
{
    public class GenericRepository<T> : IGeneric<T>, IDisposable where T : class
    {

        public static IConfiguration Configuration;
        private readonly DbContextOptionsBuilder<ContextBaseMongoDB> _OptionsBuider;

        public GenericRepository()
        {
            _OptionsBuider = new DbContextOptionsBuilder<ContextBaseMongoDB>();
        }

        public virtual void Add(T entity)
        {
            using (var db = new ContextBaseMongoDB(_OptionsBuider.Options, Configuration))
            {
                db.Set<T>().Add(entity);
                db.SaveChanges();
            }
        }

        public virtual void Delete(T entity)
        {
            using (var db = new ContextBaseMongoDB(_OptionsBuider.Options, Configuration))
            {
                db.Set<T>().Remove(entity);
                db.SaveChanges();
            }
        }

        public virtual T Get(long id)
        {
            using (var db = new ContextBaseMongoDB(_OptionsBuider.Options, Configuration))
            {
                return db.Set<T>().Find(id);
            }
        }

        public virtual IEnumerable<T> List(GenericFilter filter)
        {
            if (filter.Count == 0)
                filter.Count = 10;

            if (filter.Page == 0)
                filter.Page = 1;

            using (var db = new ContextBaseMongoDB(_OptionsBuider.Options, Configuration))
                return db.Set<T>().AsNoTracking().Skip((filter.Page - 1) * filter.Count).Take(filter.Count).ToList();
        }

        public virtual void Update(T Entity)
        {
            using (var db = new ContextBaseMongoDB(_OptionsBuider.Options, Configuration))
            {
                db.Set<T>().Update(Entity);
                db.SaveChanges();
            }
        }

        public virtual void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool isDispose)
        {
            if (!isDispose) return;
        }

        ~GenericRepository()
        {
            Dispose(false);
        }
    }
}
