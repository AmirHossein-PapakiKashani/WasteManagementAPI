using Microsoft.AspNetCore.Mvc;
using WasteManagementAPI.Models;
using WasteManagementAPI.Models.AuthModels.Login;
using WasteManagementAPI.Models.AuthModels.Register;
using WasteManagementAPI.Models.Others;

namespace WasteManagement.Application.Services.IService
{
    public interface IAuthRepository
    {
        Task<AuthResponseDto> Register(UserModel user);

        Task<AuthResponseDto> Update(UserModel Updateuser);

        Task<AuthResponseDto> Delete(UserLogin userLogin);

        Task<AuthResponseDto> Login([FromBody] UserLogin userLogin);
    }
}
