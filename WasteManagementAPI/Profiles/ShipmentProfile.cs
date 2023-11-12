using AutoMapper;
using WasteManagementAPI.Models.DomainModels;
using WasteManagementAPI.Models.Dtos;

namespace WasteManagementAPI.Profiles
{
    public class ShipmentProfile : Profile
    {
        public ShipmentProfile()
        {
            CreateMap<Shipments , ShipmentDto>();
        }
    }
}
