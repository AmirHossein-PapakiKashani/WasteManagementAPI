using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WasteManagement.Application.Repositories.IRepository;
using WasteManagementAPI.Models;
using WasteManagementAPI.Models.DomainModels;

namespace WasteManagement.Application.Repositories.Repository
{
    public class CitizensRepository : GenericRepository<Citizens>, ICitizensRepository
    {
        public CitizensRepository(WastMangementDbContext dbContext) : base(dbContext)
        {
        }
    }
}
