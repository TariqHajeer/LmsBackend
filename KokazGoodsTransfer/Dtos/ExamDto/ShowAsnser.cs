using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LMSbackend.Dtos.ExamDto
{
    public class ShowAsnser
    {
        public int Id { get; set; }
        public string StudnetName { get; set; }
        public string Question { get; set; }
        public string Answer { get; set; }
        public bool Valid { get; set; }
    }
}
