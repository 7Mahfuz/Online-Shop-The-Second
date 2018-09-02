using OnlineShopping_Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineShopping_Application.DLL
{
    public class UnitOfWork : IDisposable
    {
        private ApplicationDbContext context = null;

        public UnitOfWork()
        {
            context = new ApplicationDbContext();
        }

        public Dictionary<Type, object> repositories = new Dictionary<Type, object>();

        public _IRepository<T>  Repository<T>() where T : class
        {
            if (repositories.Keys.Contains(typeof(T)) == true)
            {
                return repositories[typeof(T)] as _IRepository<T>;
            }
            _IRepository<T> repo = new Repository<T>(context);

            repositories.Add(typeof(T), repo);
            return repo;
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
