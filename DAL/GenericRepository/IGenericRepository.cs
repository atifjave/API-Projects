using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.GenericRepository
{
   public interface IGenericRepository<T> where T : class
    {
        IList<T> GetAll();
        void Insert(T obj);
        T GetById(object id);
        void Delete(T obj);

        //T GetEmployeeById(int id);
    }
}
