using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using System.Security.Claims;
using WasteManagement.Application.IUnitOfWork;
using WasteManagement.Application.Services.IService;
using WasteManagementAPI.Models;
using WasteManagementAPI.Models.DomainModels;
using WasteManagementAPI.Models.Dtos;
using WasteManagementAPI.Models.Others;

namespace WasteManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WasteController : ControllerBase
    {
        public int flag = 0;
        private readonly WastMangementDbContext _context;
        private readonly IUnitOfWorks _unitOFWork;
        private readonly IWasteService _wasteService;
        private readonly IHttpContextAccessor _httpContext;
        public WasteController(WastMangementDbContext context, IMapper mapper, IUnitOfWorks unitOFWork, IWasteService wasteService, IHttpContextAccessor httpContext)
        {
            _context = context;

            _unitOFWork = unitOFWork;
            _wasteService = wasteService;
            _httpContext = httpContext;
        }

        [HttpPost("RecordWaste")]
        [Authorize(Roles ="Citizen, Admin")]
        public async Task<IActionResult> RecordWaste([FromBody] ShipmentDto shipment)
        {
            var response = await _wasteService.RecordWaste(shipment, _httpContext);
            return Ok(response);



        }

    }
}
