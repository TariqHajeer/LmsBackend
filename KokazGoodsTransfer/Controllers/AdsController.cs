using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using LMSbackend.Dtos.AdsDto;
using LMSbackend.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LMSbackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdsController : AbstractController
    {
        public AdsController(LmsContext context, IMapper mapper) : base(context, mapper)
        {
        }
        [HttpPost]
        public IActionResult Create([FromBody]CreateAds createAds)
        {
            Ad ad = new Ad()
            {
                CreateDate = createAds.Date,
                Description = createAds.Desc,
                Link = createAds.Link,
                Name = createAds.Name
            };
            this.Context.Add(ad);
            this.Context.SaveChanges();
            return Ok(ad);

        }
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(this.Context.Ads.ToList());
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            this.Context.Remove(this.Context.Ads.Find(id));
            this.Context.SaveChanges();
            return Ok();
        }
    }
}