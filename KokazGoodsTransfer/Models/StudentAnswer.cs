using System;
using System.Collections.Generic;

#nullable disable

namespace LMSbackend.Models
{
    public partial class StudentAnswer
    {
        public int StudentId { get; set; }
        public int QuestionId { get; set; }
        public string Answer { get; set; }

        public virtual Question Question { get; set; }
        public virtual User Student { get; set; }
    }
}
