using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WasteManagement.Application.Repositories.IRepository;

namespace WasteManagement.Application.IUnitOfWork
{
    public interface IUnitOfWorks : IDisposable
    {
        IShipmentsRepository Shipments { get; }
        ICitizensRepository Citizens { get; }
        int Complete();
    }
}
