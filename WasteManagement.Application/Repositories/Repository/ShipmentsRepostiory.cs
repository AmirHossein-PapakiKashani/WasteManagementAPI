using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using WasteManagement.Application.Repositories.IRepository;
using WasteManagementAPI.Models;
using WasteManagementAPI.Models.DomainModels;

namespace WasteManagement.Application.Repositories.Repository
{
    public class ShipmentsRepostiory<T> : IShipmentsRepository<T> where T : class
    {
        private readonly WastMangementDbContext _dbContext;

        public ShipmentsRepostiory(WastMangementDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        public T? OrderByDescending<TKey>(Expression<Func<T, TKey>> keySelector)
         {
            return _dbContext.Set<T>().OrderByDescending(keySelector).FirstOrDefault();
         }

         
        public void Add(T entity)
        {
              _dbContext.Set<T>().AddAsync(entity);        }

        public void Delete(T entity)
        {
             _dbContext.Set<T>().Remove(entity); 
          
        }

        
        public T? GetFirstObject(Expression<Func<T, bool>> filterExpression)
        {
            return _dbContext.Set<T>().FirstOrDefault(filterExpression);
        }

       

       
        public void Update(T entity)
        {
            _dbContext.Set<T>().Update(entity); 
        }
    }
    
      
    
}
