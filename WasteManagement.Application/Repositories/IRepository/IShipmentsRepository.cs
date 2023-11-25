using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using WasteManagementAPI.Models.DomainModels;

namespace WasteManagement.Application.Repositories.IRepository
{
    public interface IShipmentsRepository<T> where T : class 
    {
         
         void Add(T entity);
        void Delete(T entity);
        void Update(T entity);
        T? OrderByDescending<TKey>(Expression<Func<T, TKey>> keySelector);
         T? GetFirstObject (Expression<Func<T, bool>> filterExpression);
    }
}
