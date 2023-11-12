using AutoMapper;
using WasteManagementAPI.Models.AuthModels;
using WasteManagementAPI.Models.AuthModels.Login;
using WasteManagementAPI.Models.DomainModels;

namespace WasteManagementAPI.Profiles
{
    public class ContractorProfile : Profile
    {
        public ContractorProfile() 
            {
                CreateMap<Contractors , UserLogin>();
                CreateMap<Contractors, UserModel>();
            }

    }
}
