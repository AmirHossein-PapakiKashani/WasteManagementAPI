using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WasteManagement.Application.Repositories.IRepository;
using WasteManagementAPI.Models;



namespace WasteManagement.Application.Repositories.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly WastMangementDbContext _dbContext;

        public GenericRepository(WastMangementDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Add(T entity)
        {
              _dbContext.Set<T>().AddAsync(entity);        }

        public void Delete(T entity)
        {
             _dbContext.Set<T>().Remove(entity); 
        }

        public void Update(T entity)
        {
            _dbContext.Set<T>().Update(entity); 
        }

        //public async Task Add(T entity)
        //{
        //    
        //}

        //public  void Delete(T entity)
        //{
        //   
        //}

        //public void Update(T entity)
        //{
        //    throw new NotImplementedException();
        //}


        ////public async Task<T> Get(int id)
        ////{
        ////  return await _dbContext.Set<T>().FindAsync(id);
        ////}

        //public async Task<IEnumerable<T>> GetAll()
        //{
        //    return await _dbContext.Set<T>().ToListAsync();
        //}

        //public void Update(T entity)
        //{
        //    _dbContext.Set<T>().Update(entity);
        //}
    }
}
