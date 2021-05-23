using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LMSbackend.Dtos.ExamDto
{
    public class CreateExamDto
    {
        public string Title { get; set; }
        public DateTime Date { get; set; }
        public List<CreateQuestionDto> Quetions { get; set; }
    }
    public class CreateQuestionDto
    {
        public string Question { get; set; }
        public string Choise1 { get; set; }
        public string Choise2 { get; set; }
        public string Choise3 { get; set; }
        public string Choise4 { get; set; }
        public string Correct { get; set; }
    }
}
