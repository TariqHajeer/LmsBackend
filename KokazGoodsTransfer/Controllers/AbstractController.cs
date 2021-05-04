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
    }
}