using AutoMapper;
using Cpm.Api.Application.Interface;
using Cpm.Api.Application.Provider;
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
        [HttpPost("AddUser")]
        public async Task<ActionResult<LoginModel>> AddUsers(LoginDto loginDto)
        {
            var user = await _loginServices.GetByEmailAsync(loginDto.EmailId);
            if (user == null)
            {
                var result = _mapper.Map<LoginModel>(loginDto);
                await _loginServices.AddUser(result);
                return Ok(result);
            }
            return Ok();
        }
        [HttpPut("UpdateUser/{id}")]
        public async Task<ActionResult> UpdateUser(int id, LoginDto loginDto)
        {
            var result = _mapper.Map<LoginModel>(loginDto);
            result.LoginId = id;
            await _loginServices.UpdateUser(result);
            return Ok(result);
        }
        [HttpGet("GetByEmail/{email}")]
        public async Task<IActionResult> GetByEmail(string email)
        {
            
            var result = await _loginServices.GetByEmailAsync(email);
            if (result == null || result.LoginId == 0)
            {
                return NotFound("User not Found");
            }
            return Ok(result);
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
                new Claim("loginid",model.LoginId.ToString()),
                new Claim("email",model.EmailId),
                new Claim("roleid",model.RoleId.ToString()),
                new Claim("doctorid",model.DoctorId.ToString()),
                new Claim("password",model.Password),
                new Claim("rolename", role.RoleName)
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
