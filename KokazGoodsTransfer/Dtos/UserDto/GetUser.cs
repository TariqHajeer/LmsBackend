using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LMSbackend.Dtos.UserDto
{
    public class GetUser
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string EMail { get; set; }
    }
}
