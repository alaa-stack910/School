using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using School.DTO;
using School.Model;
using School.Repo.Interface;

namespace School.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IConfiguration configuration;

        public UserController(IUnitOfWork unitOfWorks, IConfiguration configurations)
        {
unitOfWork= unitOfWorks;
         configuration= configurations;

        }


        [HttpPost("Login")]

        public IActionResult Log(LoginDTO loginDTO)
        {
            var u=unitOfWork.user.GetbyUserName(loginDTO.UserName);
            if (u == null)
            {
                return Unauthorized();
            }
            if(u.PasswordHash!=loginDTO.PasswordHash)
            {
                return Unauthorized();

            }
            var token = GenerateToken(u);
            return Ok();
        }


        private string GenerateToken(User user)
        {
            //payload
            var claims = new List<Claim> {
            new Claim(ClaimTypes.NameIdentifier,user.Id.ToString()),
            new Claim(ClaimTypes.Name,user.UserName),
                        new Claim(ClaimTypes.Role,user.Role),


            };

            //signature
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]));
            var cred=new SigningCredentials (key,SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: configuration["Jwt:Issuer"],
                audience: configuration["Jwt:Audience"],
                claims: claims,
                signingCredentials: cred,
                expires:DateTime.Now.AddHours(2)

                ) ;
return new JwtSecurityTokenHandler().WriteToken(token) ;
        }


    }
}
