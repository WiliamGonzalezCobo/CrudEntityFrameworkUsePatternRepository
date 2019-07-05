using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using AdoNetEntity;

namespace EF_Repo.PatternRepository
{
    public class Repository<T> : IRepository<T> where T : class
    {

        private DbEjemplosEntities context;
        private DbSet<T> entities = null;

        public Repository()
        {
            context = new DbEjemplosEntities();
            entities = context.Set<T>();
        }

        public IEnumerable<T> GetAll()

        {
            return this.entities.ToList();
        }

        public T GetById(Object id)

        {
            return this.entities.Find(id);
        }

        public void Add(T entityDb)

        {
            context.Entry(entityDb).State = System.Data.Entity.EntityState.Added;
        }

        public void Update(T entityDb)

        {
            context.Entry(entityDb).State = System.Data.Entity.EntityState.Modified;
        }

        public void Delete(Object id)
        {
            T existing = entities.Find(id);
            entities.Remove(existing);
        }

        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {

            if (!this.disposed)
            {

                if (disposing)
                {

                    context.Dispose();

                }

            }

            this.disposed = true;

        }



        public void Dispose()
        {

            Dispose(true);

            GC.SuppressFinalize(this);

        }

    }

}