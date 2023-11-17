using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WasteManagement.Application.Dtos;
using WasteManagementAPI.Models.Dtos;

namespace WasteManagement.Application.Services.IService
{
    public interface IWasteService
    {
       Task<WasteResponseDto>  RecordWaste([FromBody] ShipmentDto shipment,IHttpContextAccessor http);
    }
}
