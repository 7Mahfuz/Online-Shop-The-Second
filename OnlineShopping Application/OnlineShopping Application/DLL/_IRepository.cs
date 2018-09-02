using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShopping_Application.DLL
{
   public interface _IRepository<T> where T : class
    {
        IEnumerable<T> GetList(Func<T, bool> predicate = null);
        T GetModelById(int ModelId);

        bool InsertModel(T model);
        bool UpdateModel(T model);
        bool DeleteModel(T model);
        int Count(Func<T, bool> predicate = null);
        T GetModel(Func<T, bool> predicate = null);

    }
}
