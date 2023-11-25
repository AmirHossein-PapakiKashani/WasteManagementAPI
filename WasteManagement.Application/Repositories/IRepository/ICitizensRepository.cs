using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using WasteManagement.Application.Repositories.Repository;
using WasteManagementAPI.Models;
using WasteManagementAPI.Models.DomainModels;

namespace WasteManagement.Application.Repositories.IRepository
{
    public interface ICitizensRepository<T> where T : class 
    {
        void Add(T entity);
        void Delete(T entity);
        void Update(T entity);

         T? GetFirstObject (Expression<Func<T, bool>> filterExpression);
    }
}
