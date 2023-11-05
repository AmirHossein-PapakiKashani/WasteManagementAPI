﻿using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using WasteManagementAPI.Models;
using WasteManagementAPI.Models.DomainModels;
using WasteManagementAPI.Models.Dtos;

namespace WasteManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WasteController : ControllerBase
    {
        public int flag = 0;
        private readonly WastMangementGptBaseContext _context;
        private readonly IMapper _mapper;
        public WasteController(WastMangementGptBaseContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost("RecordWaste")]
        [Authorize(Roles ="Citizen, Admin")]
        public IActionResult RecordWaste([FromBody] ShipmentDto shipment)
        {
            //the following line retrive int data form shipment and convert it to int
            var preAprove = Convert.ToInt32(_context.Shipments.Where(p => p.ShipmentsId == shipment.ShipmentsId).FirstOrDefault( p => p.ApproveBySupervisor));
            
            //in this line we get info from shipmentdto  and map it to shipments
            var recordwaste = new Shipments()
            {
               Weight = shipment.Weight,
               WasteTypes = shipment.WasteTypes,
               ApproveBySupervisor = SupervisorAprove(shipment.Weight),
                PointsAllocated = CaculatePoint(shipment.Weight, shipment.WasteTypes) + preAprove
            };

            
            return Ok(recordwaste);

        }

        private int CaculatePoint(int weightpoint , List<WasteTypes> wastetypepoint)
        {
            const int scoreOfDryBread = 1000;
            const int scoreOfIron = 1500;
            const int scoreOfPlastic = 2000;
            
            if ( wastetypepoint.ElementAt(flag).WasteName == "Dry Bread")
            {
                return scoreOfDryBread * weightpoint /5 ;
            }
            else if ( wastetypepoint.ElementAt(flag).WasteName == "Iron")
            {
                return scoreOfIron * weightpoint /5 ;
            }
            else if ( wastetypepoint.ElementAt(flag).WasteName == "Plastic")
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