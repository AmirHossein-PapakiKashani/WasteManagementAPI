using AutoMapper;
using WasteManagementAPI.Models.AuthModels;
using WasteManagementAPI.Models.AuthModels.Login;
using WasteManagementAPI.Models.DomainModels;

namespace WasteManagementAPI.Profiles
{
    public class SupervisorProfile : Profile
    {
        public SupervisorProfile() 
            {
                CreateMap<Supervisors, UserModel>();
                CreateMap<Supervisors, UserLogin>();
            }
    }
}
