using OnlineShopping_Application.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace OnlineShopping_Application.DLL
{
    public class Repository<T> : _IRepository<T> where T : class
    {

        private ApplicationDbContext context;
        private DbSet<T> _DbSet;

        public Repository(ApplicationDbContext _context)
        {
            context = _context;
            this._DbSet = _context.Set<T>();
        }


        public int Count(Func<T, bool> predicate = null)
        {
            throw new NotImplementedException();
        }

        public int DeleteModel(T model)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> GetList(Func<T, bool> predicate = null)
        {
            throw new NotImplementedException();
        }

        public T GetModel(Func<T, bool> predicate = null)
        {
            throw new NotImplementedException();
        }

        public T GetModelById(int ModelId)
        {
            throw new NotImplementedException();
        }

        public int InsertModel(T model)
        {
            throw new NotImplementedException();
        }

        public int UpdateModel(T model)
        {
            throw new NotImplementedException();
        }
    }
}