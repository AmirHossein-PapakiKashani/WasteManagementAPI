using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using System.Security.Claims;
using WasteManagement.Application.IUnitOfWork;
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
        private readonly IUnitOfWork _unitOFWork;
        private readonly IMapper _mapper;
        public WasteController(WastMangementDbContext context, IMapper mapper, IUnitOfWork unitOFWork)
        {
            _context = context;
            _mapper = mapper;
            _unitOFWork = unitOFWork;
        }

        [HttpPost("RecordWaste")]
        [Authorize(Roles ="Citizen, Admin")]
        public IActionResult RecordWaste([FromBody] ShipmentDto shipment)
        {
            var currentUser = HttpContext.User;

            //the following line retrive int data form shipment and convert it to int
            
            
            //in this line we get info from shipmentdto  and map it to shipments
            var recordwaste = new Shipments()
            {
               Weight = shipment.Weight,
               ApproveBySupervisor = SupervisorAprove(shipment.Weight),
                   
            };
            recordwaste.CitizensId = Convert.ToInt32(currentUser.Claims.FirstOrDefault(p => p.Type == "CitizensId" )?.Value);
            
            int convertToInt = Convert.ToInt32(recordwaste.CitizensId);

            var query = _context.Shipments.OrderByDescending( p => p.PointsAllocated).FirstOrDefault(c => c.CitizensId == convertToInt);
            
            if (query != null)
            {
                int prepoints = query.PointsAllocated ;
                recordwaste.PointsAllocated +=  CaculatePoint(shipment.Weight, shipment.WasteTypes) + prepoints ;
            }

            else
            {
                recordwaste.PointsAllocated +=  CaculatePoint(shipment.Weight, shipment.WasteTypes) + 0 ;
            }
            
            _unitOFWork.Shipments.Add(recordwaste);
            _unitOFWork.Complete(); 
            return Ok(recordwaste);



        }

        private int CaculatePoint(int weightpoint , string wastetype)
        {
            
            const int scoreOfDryBread = 1000;
            const int scoreOfIron = 1500;
            const int scoreOfPlastic = 2000;
            
            if(WasteType.DryBread == wastetype)
            {
                return scoreOfDryBread * weightpoint /5 ;
            }
            else if (wastetype == WasteType.Iron)
            {
                return scoreOfIron * weightpoint /5 ;
            }
            else if (wastetype   ==WasteType.Plastic)
            {
               return scoreOfPlastic * weightpoint /5;
            }
            else
            {
              return 0;
            }
          
        }

        private bool SupervisorAprove(int IsAproove)
        {
            if (IsAproove >= 20)
            {
                return false;
            } 
            return true;
        }
    }
}
