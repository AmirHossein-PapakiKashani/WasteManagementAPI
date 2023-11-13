using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WasteManagement.Application.IUnitOfWork;
using WasteManagement.Application.Repositories.IRepository;
using WasteManagementAPI.Models;

namespace WasteManagement.Domain.Models.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly WastMangementDbContext _dbContext;

        public UnitOfWork(WastMangementDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IShipmentsRepository Shipments => throw new NotImplementedException();

        public ICitizensRepository Citizens => throw new NotImplementedException();

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
