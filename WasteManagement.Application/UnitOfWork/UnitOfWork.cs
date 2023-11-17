using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WasteManagement.Application.IUnitOfWork;
using WasteManagement.Application.Repositories.IRepository;
using WasteManagement.Application.Repositories.Repository;
using WasteManagementAPI.Models;

namespace WasteManagement.Domain.Models.UnitOfWork
{
    public class UnitOfWork : IUnitOfWorks, IDisposable
    {
        private readonly WastMangementDbContext _dbContext;

        
        public IShipmentsRepository Shipments {get; private set;}

        public ICitizensRepository Citizens {get; private set;}

        public UnitOfWork(WastMangementDbContext dbContext)
        {
            _dbContext = dbContext;
            Shipments = new ShipmentsRepostiory(_dbContext);
            Citizens = new CitizensRepository(_dbContext);
        }




        public int Complete()
        {
            return _dbContext.SaveChanges();
        }

        public void Dispose()
        {
            _dbContext.Dispose();
            
        }

    }
}
