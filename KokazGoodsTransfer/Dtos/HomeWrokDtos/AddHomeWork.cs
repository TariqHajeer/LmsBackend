using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LMSbackend.Dtos.HomeWrokDtos
{
    public class AddHomeWork
    {
        public string Note { get; set; }
        public IFormFile File { get; set; }
        public int UserId { get; set; }
    }
}
