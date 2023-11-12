using AutoMapper;
using WasteManagementAPI.Models.AuthModels;
using WasteManagementAPI.Models.AuthModels.Login;
using WasteManagementAPI.Models.DomainModels;

namespace WasteManagementAPI.Profiles
{
    public class MunicipalitiesProfile : Profile
    {
        public MunicipalitiesProfile()
        {
            CreateMap<Municipalities , UserLogin>();
            CreateMap<Municipalities, UserModel>();
        }
    }
}
