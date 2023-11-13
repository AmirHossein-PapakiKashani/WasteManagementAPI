using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WasteManagement.Application.Repositories.IRepository
{
    public interface IGenericRepository<T> where T : class
    {
        //Task<T> Get(int id);
        //Task<IEnumerable<T>> GetAll();
        void Add(T entity);
        void Delete(T entity);
        void Update(T entity);
    }
}
