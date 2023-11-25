using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WasteManagement.Application.IUnitOfWork;
using WasteManagement.Application.Repositories.IRepository;
using WasteManagement.Application.Repositories.Repository;
using WasteManagementAPI.Models;
using WasteManagementAPI.Models.DomainModels;

namespace WasteManagement.Domain.Models.UnitOfWork
{
    public class UnitOfWork : IUnitOfWorks, IDisposable
    {
        private readonly WastMangementDbContext _dbContext;

        
        public IShipmentsRepository Shipments {get;  set;}

        public ICitizensRepository Citizens {get;  set;}

        public UnitOfWork(WastMangementDbContext dbContext , ShipmentsRepostiory shipmentsRepostiory, CitizensRepository citizensRepository)
        {
            _dbContext = dbContext;
            Shipments = shipmentsRepostiory;
            Citizens = citizensRepository;
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
