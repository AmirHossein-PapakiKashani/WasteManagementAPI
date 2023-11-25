using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WasteManagement.Application.Dtos;
using WasteManagement.Application.IUnitOfWork;
using WasteManagement.Application.Services.IService;
using WasteManagement.Domain.Models.UnitOfWork;
using WasteManagementAPI.Models.DomainModels;
using WasteManagementAPI.Models.Dtos;
using WasteManagementAPI.Models.Others;

namespace WasteManagement.Application.Services.Service
{
    public class WasteService : IWasteService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWorks _unitOfWork;
       

        public async Task<WasteResponseDto> RecordWaste([FromBody] ShipmentDto shipment,IHttpContextAccessor http)
        {
            var currentUser = http.HttpContext.User;

            //the following line retrive int data form shipment and convert it to int
            
            
            //in this line we get info from shipmentdto  and map it to shipments
            var recordwaste = new Shipments()
            {
               Weight = shipment.Weight,
               ApproveBySupervisor = SupervisorAprove(shipment.Weight),
                   
            };
            recordwaste.CitizensId = Convert.ToInt32(currentUser.Claims.FirstOrDefault(p => p.Type == "CitizensId" )?.Value);
            
            int convertToInt = Convert.ToInt32(recordwaste.CitizensId);

            var query = _unitOfWork.Shipments.GetFirstObject(x => x.CitizensId == convertToInt);
           
            
            


            if (query != null)
            {
                int prepoints = query.PointsAllocated ;
                recordwaste.PointsAllocated +=  CaculatePoint(shipment.Weight, shipment.WasteTypes) + prepoints ;
            }

            else
            {
                recordwaste.PointsAllocated +=  CaculatePoint(shipment.Weight, shipment.WasteTypes) + 0 ;
            }
            
            _unitOfWork.Shipments.Add(recordwaste);
            _unitOfWork.Complete(); 
            return new WasteResponseDto
            {
                IsSucceed = true,
                Message = "User succefully added"
            };
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
