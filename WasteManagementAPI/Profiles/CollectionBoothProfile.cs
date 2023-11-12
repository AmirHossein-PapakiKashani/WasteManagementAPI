using AutoMapper;
using WasteManagementAPI.Models.AuthModels;
using WasteManagementAPI.Models.AuthModels.Login;
using WasteManagementAPI.Models.DomainModels;

namespace WasteManagementAPI.Profiles
{
    public class CollectionBoothProfile : Profile
    {
        public CollectionBoothProfile()
        {
            CreateMap<CollectionBooths , UserLogin>();
            CreateMap<CollectionBooths, UserModel>();
        }
    }
}
