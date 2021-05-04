using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LMSbackend.Dtos.Common
{
    public class AuthDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Token { get; set; }
        public bool IsAdmin { get; set; }
        public string EMail { get; set; }
        public string Password {  get; set; }
    }
}
