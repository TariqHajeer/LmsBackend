using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LMSbackend.Dtos.ExamDto
{
    public class AnswerQuestion
    {
        public int Id { get; set; }
        public string Answer { get; set; }
        public int UserId { get; set; }

    }
}
