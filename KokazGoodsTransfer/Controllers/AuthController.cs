using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using LMSbackend.Dtos.Common;
using LMSbackend.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace LMSbackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : AbstractController
    {
        public AuthController(LmsContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public IActionResult Auth([FromBody] AuthDto authDto)
        {
            var user = this.Context.Users.Where(c => c.Email == authDto.EMail && c.Password == authDto.Password).FirstOrDefault();
            if (user == null)
                return NotFound();
            else
            {
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Expires = DateTime.UtcNow.AddDays(1),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes("this is my custom Secret key for authnetication")), SecurityAlgorithms.HmacSha256Signature)
                };
                var tokenHandler = new JwtSecurityTokenHandler();
                var securityToken = tokenHandler.CreateToken(tokenDescriptor);
                var token = tokenHandler.WriteToken(securityToken);
                return Ok(new AuthDto()
                {
                    Id = user.Id,
                    EMail = user.Email,
                    IsAdmin = user.IsAdmin,
                    Name = user.Name,
                    Token = token
                });
            }
        }
    }
}