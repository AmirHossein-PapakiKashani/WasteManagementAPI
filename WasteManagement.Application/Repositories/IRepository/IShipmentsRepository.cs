using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using WasteManagementAPI.Models.DomainModels;
using WasteManagementAPI.Models.Dtos;

namespace WasteManagement.Application.Repositories.IRepository
{
    public interface IShipmentsRepository 
    {
         
         void Add(Shipments entity);
        void Delete(Shipments entity);
        void Update(Shipments entity);
        Shipments? OrderByDescending<TKey>(Expression<Func<Shipments, TKey>> keySelector);
         Shipments? GetFirstObject (Expression<Func<Shipments, bool>> filterExpression);
    }
}
