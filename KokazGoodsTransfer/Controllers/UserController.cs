using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using LMSbackend.Dtos.UserDto;
using LMSbackend.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LMSbackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : AbstractController
    {
        public UserController(LmsContext context, IMapper mapper) : base(context, mapper)
        {
        }
        [HttpPost]
        public IActionResult Create([FromBody]CreateUser createUser)
        {
            User u = new User()
            {
                Email = createUser.Mail,
                IsAdmin = false,
                Name = createUser.Name,
                Password = createUser.Passowrd
            };
            this.Context.Users.Add(u);
            this.Context.SaveChanges();

            return Ok(u);
        }
        [HttpGet]
        public IActionResult Get()
        {
            var userslist = this.Context.Users.Where(c => c.IsAdmin == false).ToList();
            List<GetUser> getUsers = new List<GetUser>();
            userslist.ForEach(c =>
            {
                getUsers.Add(new GetUser()
                {
                    EMail = c.Email,
                    Name = c.Name,
                    Id = c.Id
                });
            });
            return Ok(getUsers);
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            this.Context.Users.Remove(this.Context.Users.Find(id));
            this.Context.SaveChanges();
            return Ok();
        }
    }
}