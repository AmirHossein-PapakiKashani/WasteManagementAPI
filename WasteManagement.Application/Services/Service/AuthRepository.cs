﻿using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using WasteManagement.Application.IUnitOfWork;
using WasteManagement.Application.Services.IService;
using WasteManagementAPI.Models.AuthModels;
using WasteManagementAPI.Models.AuthModels.Login;
using WasteManagementAPI.Models.AuthModels.Register;
using WasteManagementAPI.Models.DomainModels;
using WasteManagementAPI.Models.Others;
using WasteManagementAPI.Models.Repositories;

namespace WasteManagementAPI.Models.Repositories.RepositoryService
{
    public class AuthRepository  : IAuthRepository
    {



        private readonly WastMangementDbContext _context;
        private readonly IUnitOfWorks _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IConfiguration _config;

        public AuthRepository(WastMangementDbContext context, IMapper mapper, IConfiguration config, IUnitOfWorks unitOfWork)
        {
            _context = context;
            _mapper = mapper;
            _config = config;
            _unitOfWork = unitOfWork;
        }



        public async Task<AuthResponseDto> Register(UserModel user)
        {
            var maptoCitizen = _mapper.Map<Citizens>(user);

            // var citizen = _context.Citizens.Add(maptoCitizen);

             _unitOfWork.Citizens.Add(maptoCitizen);
            _unitOfWork.Complete();

            var writeToken = Generate(user);

            

            return new AuthResponseDto
            {
                IsSucceed = true,
                Message = writeToken.ToString()
            };
        }


        public async Task<AuthResponseDto> Login([FromBody] UserLogin userLogin)
        {
            var user = Authenticate(userLogin);

            if (user != null)
            {
                var token = Generate(user);
                return new AuthResponseDto
                {
                    IsSucceed = true,
                    Message = token.ToString()
                };
            }

            return new AuthResponseDto
            {
                IsSucceed = false,
                Message = "User Not found"
            };
        }

        public async Task<AuthResponseDto> Update(UserModel Updateuser)
        {

            var mapUpdate = _mapper.Map<Citizens>(Updateuser);
            _unitOfWork.Citizens.Update(mapUpdate);
            _unitOfWork.Complete();
            return new AuthResponseDto
            {
                IsSucceed = true,
                Message = "User successfully updated."
            };

        }

        [Authorize(Roles = "Admin")]
        public async Task<AuthResponseDto> Delete(UserLogin userLogin)
        {
            var mapUpdate = _mapper.Map<Citizens>(userLogin);
            _unitOfWork.Citizens.Delete(mapUpdate);
            _unitOfWork.Complete();
            return new AuthResponseDto
            {
                IsSucceed = false,
                Message = "User successfully deleted."
            };
        }




        #region Gererate
        private string Generate(UserModel user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["JWT:Secret"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var compare = _context.Citizens.FirstOrDefault(a => a.UserName == user.UserName);

            var claims = new[]
           {
                new Claim(ClaimTypes.Name, user.Name),
                new Claim("UserName", user.UserName),
                new Claim(ClaimTypes.Role, user.Role),
                new Claim ("CitizensId", Convert.ToString(compare?.CitizensId))
            };

            var token = new JwtSecurityToken(_config["JWT:ValidIssuer"],
              _config["JWT:ValidAudience"],
              claims,
              expires: DateTime.Now.AddMinutes(15),
              signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
        #endregion 

        #region Authenticate
        private UserModel Authenticate(UserLogin userLogin)
        {
            var currentCitizen = _unitOfWork.Citizens.GetFirstObject(c => c.UserName.ToLower() == userLogin.UserName.ToLower() && c.Password == userLogin.Password);

            UserModel mapcitizen = _mapper.Map<UserModel>(currentCitizen);




            if (mapcitizen != null)
            {
                return mapcitizen;
            }





            return new UserModel()
            {
                UserName = userLogin.UserName,
                Password = userLogin.Password,


            };

        }

        #endregion

    }
}
