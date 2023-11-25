using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using WasteManagement.Application.Repositories.Repository;
using WasteManagementAPI.Models;
using WasteManagementAPI.Models.DomainModels;

namespace WasteManagement.Application.Repositories.IRepository
{
    public interface ICitizensRepository 
    {
        void Add(Citizens entity);
        void Delete(Citizens entity);
        void Update(Citizens entity);

         Citizens? GetFirstObject (Expression<Func<Citizens, bool>> filterExpression);
    }
}
