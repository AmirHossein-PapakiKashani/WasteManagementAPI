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

namespace WasteManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {       
        private readonly WastMangementDbContext _context;

        private IMapper _mapper;

        private readonly IConfiguration _config;
        
        public AuthController(WastMangementDbContext context, IConfiguration configuration, IMapper mapper)
        {
            _context = context;
            _config = configuration;
            _mapper = mapper;
        }
       

        #region Register
        [HttpPost("Register")]
        public IActionResult Register(UserModel user)
        {
            var citizen = _context.Citizens.Add(new Models.DomainModels.Citizens { Name = user.Name , UserName = user.UserName , Password = user.Password , Role = user.Role});

           var writeToken =   Generate(user);

            _context.SaveChanges();

            return Ok(writeToken);

        }
        #endregion


        #region Login      
        [HttpPost("Login")]
        public IActionResult Login([FromBody] UserLogin userLogin)
        {
            var user = Authenticate(userLogin);

            if (user != null)
            {
                var token = Generate(user);
                return Ok(token);
            }

            return NotFound("User not found");
        }
        #endregion 

        #region Update
        [HttpPut("Update")]
        public IActionResult Update(UserModel Updateuser)
        {
            var mapUpdate = _mapper.Map<Citizens>(Updateuser);
            _context.Update(mapUpdate);
           _context.SaveChanges(); 
            return NoContent();
              
        }
        #endregion
        #region Delete
        [HttpDelete]
        public IActionResult Delete(UserLogin userLogin)
        {
             var mapUpdate = _mapper.Map<Citizens>(userLogin);
           _context.Remove(mapUpdate);
           _context.SaveChanges(); 
            return NoContent();
        } 

        #endregion

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
            var currentCitizen = _context.Citizens.FirstOrDefault(c => c.UserName.ToLower() == userLogin.UserName.ToLower() && c.Password == userLogin.Password);

            UserModel mapcitizen = _mapper.Map<UserModel>(currentCitizen);

         
            

            if (mapcitizen != null )
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
