using System;
using System.Collections.Generic;

#nullable disable

namespace LMSbackend.Models
{
    public partial class HomeWork
    {
        public int Id { get; set; }
        public string Path { get; set; }
        public string Note { get; set; }
        public int UserId { get; set; }

        public virtual User User { get; set; }
    }
}
