using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LMSbackend.Dtos.ExamDto
{
    public class DateTimeDto
    {
        public int Year { get; set; }
        public int Month { get; set; }
        public int Day { get; set; }
        public int Hour { get; set; }
        public int Minit { get; set; }
        public int UserId { get; set; }
    }
}
