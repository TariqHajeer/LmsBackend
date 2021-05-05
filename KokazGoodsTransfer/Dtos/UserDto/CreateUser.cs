using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LMSbackend.Dtos.UserDto
{
    public class CreateUser
    {
        public string Name { get; set; }
        public string Mail { get; set; }
        public string Passowrd { get; set; }
    }
}
