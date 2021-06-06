using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LMSbackend.Dtos.ExamDto
{
    public class GetQuestionStudnetDto
    {
        public int Id { get; set; }
        public string Question { get; set; }
        public string Choise1 { get; set; }
        public string Choise2 { get; set; }
        public string Choise3 { get; set; }
        public string Choise4 { get; set; }
        public int Time { get; set; }
    }
}
