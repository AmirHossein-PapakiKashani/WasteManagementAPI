using AutoMapper;
using WasteManagementAPI.Models.AuthModels;
using WasteManagementAPI.Models.AuthModels.Login;
using WasteManagementAPI.Models.DomainModels;

namespace WasteManagementAPI.Profiles
{
    public class CitizenProfile : Profile
    {
        public CitizenProfile() 
            {
                CreateMap<Citizens ,UserModel >();
                CreateMap<Citizens, UserLogin>();
            }
    }
}
