using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using LMSbackend.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LMSbackend.Controllers
{
    [EnableCors("EnableCORS")]
    public abstract class AbstractController : ControllerBase
    {
        protected IMapper mapper;
        protected LmsContext Context;
        public AbstractController(LmsContext context, IMapper mapper)
        {
            this.Context = context;
            this.mapper = mapper;

        }
        protected int AuthoticateUserId()
        {
            var userIdClaim = User.Claims.ToList().Where(c => c.Type == "UserID").Single();
            return Convert.ToInt32(userIdClaim.Value);
        }
    }
}