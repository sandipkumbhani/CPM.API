using AutoMapper;
using Cpm.Api.Application.Interface;
using Cpm.Api.Contracts.RequestDtos;
using Cpm.Api.Domain.Interface;
using Cpm.Api.Domain.Model;
using Cpm.Api.Inftrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Numerics;
using System.Security.Claims;
using System.Text;

namespace Cpm.Api.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ILoginServices _loginServices;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;
        private readonly IPasswordHasher _passwordHasher;
        public LoginController(ILoginServices loginServices, IConfiguration configuration, IMapper mapper, IPasswordHasher passwordHasher )
        {
           _loginServices = loginServices;
            _mapper = mapper;
            _configuration = configuration;
            _passwordHasher = passwordHasher;
        }

        [HttpPost]
        public IActionResult LogIn([FromBody] LoginDto loginDto)
        {
            IActionResult response = Unauthorized();
            var result = Authentication(loginDto);
            if (result != null)
            {
                var tokenstring = GenerateJSONWebToken(result);
                response = Ok(new {token = tokenstring});
            }
            return response;
        }
        private string GenerateJSONWebToken(LoginModel model)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var role = _loginServices.GetRoleByID(Convert.ToInt32(model.RoleId));
            var claims = new[]
            {                
                new Claim("email",model.EmailId),
                new Claim("userid",model.UserId.ToString()),
                new Claim("roleid",model.RoleId.ToString()),
                new Claim(ClaimTypes.Role, role.RoleName)
            };
            var token = new JwtSecurityToken(_configuration["Jwt:Issuer"],
                _configuration["Jwt:Issuer"],
                claims,
                expires: DateTime.Now.AddMinutes(60),
                signingCredentials: credentials
            );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
        private LoginModel? Authentication (LoginDto loginDto)
        {  
            var result = _mapper.Map<LoginModel>(loginDto);
            return _loginServices.GetAuthentication(result.EmailId, loginDto.Password).Result;            
        }
       
    }
}
