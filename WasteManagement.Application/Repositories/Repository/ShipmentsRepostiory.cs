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
    public class ShipmentsRepostiory : IShipmentsRepository
    {
        private readonly WastMangementDbContext _dbContext;

        public ShipmentsRepostiory(WastMangementDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        public Shipments? OrderByDescending<TKey>(Expression<Func<Shipments, TKey>> keySelector)
         {
            return _dbContext.Set<Shipments>().OrderByDescending(keySelector).FirstOrDefault();
         }

         
        public void Add(Shipments entity)
        {
              _dbContext.Set<Shipments>().AddAsync(entity);        }

        public void Delete(Shipments entity)
        {
             _dbContext.Set<Shipments>().Remove(entity); 
          
        }

        
        public Shipments? GetFirstObject(Expression<Func<Shipments, bool>> filterExpression)
        {
            return _dbContext.Set<Shipments>().FirstOrDefault(filterExpression);
        }

       

       
        public void Update(Shipments entity)
        {
            _dbContext.Set<Shipments>().Update(entity); 
        }
    }
    
      
    
}
