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
    public class CitizensRepository : ICitizensRepository
    {
         private readonly WastMangementDbContext _dbContext;

        public CitizensRepository(WastMangementDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Add(Citizens entity)
        {
              _dbContext.Citizens.AddAsync(entity);        }

        public void Delete(Citizens entity)
        {
             _dbContext.Citizens.Remove(entity); 
          
        }

        
        public Citizens? GetFirstObject(Expression<Func<Citizens, bool>> filterExpression)
        {
            return _dbContext.Citizens.FirstOrDefault(filterExpression);
        }

       

       
        public void Update(Citizens entity)
        {
            _dbContext.Set<Citizens>().Update(entity); 
        }
       
    }
}
