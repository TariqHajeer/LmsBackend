using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using LMSbackend.Dtos.HomeWrokDtos;
using LMSbackend.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LMSbackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class HomeWorkController : AbstractController
    {
        public HomeWorkController(LmsContext context, IMapper mapper) : base(context, mapper)
        {
        }
        [HttpPost]
        public IActionResult Add([FromForm] AddHomeWork homeWork)
        {

            //var user= Context.Users.Find(AuthoticateUserId());

            //var transaction = Context.Database.BeginTransaction();
            try
            {
                HomeWork c = new HomeWork()
                {
                    UserId = homeWork.UserId,
                    Note = homeWork.Note,
                };
                Context.Add(c);
                Context.SaveChanges();
                var fileName = homeWork.File.FileName.Split('.');
                

                var path = Path.Combine(Directory.GetCurrentDirectory(), "Files",c.Id.ToString()+"."+ fileName[fileName.Length - 1]);
                var stream = new FileStream(path, FileMode.Create);
                homeWork.File.CopyToAsync(stream);
                return Ok();
            }
            catch(Exception ex)
            {
                return BadRequest();
            }
        }

    }
}