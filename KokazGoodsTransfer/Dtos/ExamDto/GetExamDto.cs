using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LMSbackend.Dtos.ExamDto
{
    public class GetExamDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime Date { get; set; }
        public List<GetQuestionDto > Questions { get; set; }
    }
    public class GetQuestionDto 
    {
        public int Id { get; set; }
        public string Question { get; set; }
        public string Choise1 { get; set; }
        public string Choise2 { get; set; }
        public string Choise3 { get; set; }
        public string Choise4 { get; set; }
        public string Correct { get; set; }
    }
}
