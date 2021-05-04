using System;
using System.Collections.Generic;

#nullable disable

namespace LMSbackend.Models
{
    public partial class Ad
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
