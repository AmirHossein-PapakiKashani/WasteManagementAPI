using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using WasteManagementAPI.Models;
using WasteManagementAPI.Models.AuthModels;
using WasteManagementAPI.Models.AuthModels.Login;

namespace WasteManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly WastMangementGptBaseContext _context;

        private IMapper _mapper;

        private readonly IConfiguration _config;

        public AuthController(WastMangementGptBaseContext context, IConfiguration configuration, IMapper mapper)
        {
            _context = context;
            _config = configuration;
            _mapper = mapper;
        }




        [AllowAnonymous]
        [HttpPost]
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

        private string Generate(UserModel user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(ClaimTypes.Name, user.Name),
                new Claim("UserName", user.UserName),
                new Claim(ClaimTypes.Role, user.Role)
            };

            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
              _config["Jwt:Audience"],
              claims,
              expires: DateTime.Now.AddMinutes(15),
              signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private UserModel Authenticate(UserLogin userLogin)
        {
            var currentCitizen = _context.Citizens.FirstOrDefault(c => c.CitizensUserName == userLogin.UserName && c.Password == userLogin.Password);

            UserModel mapcitizen = _mapper.Map<UserModel>(currentCitizen);

            var currentCollectionBooth = _context.CollectionBooths.FirstOrDefault(c => c.EmployeeUserName == userLogin.UserName && c.EmployeePasswored == userLogin.Password);

            UserModel mapCollection = _mapper.Map<UserModel>(currentCollectionBooth);

            var currentContractors = _context.Contractors.FirstOrDefault(c => c.ContractorsUserName == userLogin.UserName && c.Password == userLogin.Password);

            UserModel mapContractors = _mapper.Map<UserModel>(currentContractors);

            var currentMunicipality = _context.Municipality.FirstOrDefault(c => c.MunicipalitiesUserName == userLogin.UserName && c.Password == userLogin.Password);

            UserModel mapMunicipality = _mapper.Map<UserModel>(currentMunicipality);

            var currentSupervisor = _context.Supervisor.FirstOrDefault(c => c.SupervisorUserName == userLogin.UserName && c.Password == userLogin.Password);

            UserModel mapSupervisor = _mapper.Map<UserModel>(currentSupervisor);

            

            if (mapcitizen != null )
            {
                return mapcitizen;
            }


            
            if (mapCollection != null )
            {
                return mapCollection;
            }

            
            if (mapContractors != null )
            {
                return mapContractors;
            }
            
            if (mapMunicipality != null )
            {
                return mapMunicipality;
            }
            
            if (mapSupervisor != null )
            {
                return mapSupervisor;
            }


            return null!;
        }

    }
}
