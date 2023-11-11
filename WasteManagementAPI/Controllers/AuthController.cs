using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using WasteManagementAPI.Models;
using WasteManagementAPI.Models.AuthModels;
using WasteManagementAPI.Models.AuthModels.Login;
using WasteManagementAPI.Models.DomainModels;
using WasteManagementAPI.Models.Others;
using WasteManagementAPI.Models.Repositories.IRepositoryService;

namespace WasteManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {       
       
        
        private readonly IAuthRepository _authRepository;

        public AuthController(IAuthRepository authRepository)
        {
            _authRepository = authRepository;
        }
       

        #region Register
        [HttpPost("Register")]
        public async Task<IActionResult> Register(UserModel user)
        {
            var response = await _authRepository.Register(user);
            return Ok(response);

        }
        #endregion


        #region Login      
        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] UserLogin userLogin)
        {
           var response = _authRepository.Login(userLogin);

           return Ok(response);
        }
        #endregion 

        #region Update
        [HttpPut("Update")]
        public IActionResult Update(UserModel Updateuser)
        {
          var response = _authRepository.Update(Updateuser);
          return Ok(response);
        }
        #endregion
        #region Delete
        [HttpDelete]
        public IActionResult Delete(UserLogin userLogin)
        {
          var response = _authRepository.Delete(userLogin);
          return Ok(response);
        } 

        #endregion

     
    }
}
