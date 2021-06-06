using System;
using System.Collections.Generic;

#nullable disable

namespace LMSbackend.Models
{
    public partial class Question
    {
        public Question()
        {
            StudentAnswers = new HashSet<StudentAnswer>();
        }

        public int Id { get; set; }
        public int ExamId { get; set; }
        public string Question1 { get; set; }
        public string Choise1 { get; set; }
        public string Choise2 { get; set; }
        public string Choise3 { get; set; }
        public string Choise4 { get; set; }
        public string Correct { get; set; }
        public int Time { get; set; }

        public virtual Exam Exam { get; set; }
        public virtual ICollection<StudentAnswer> StudentAnswers { get; set; }
    }
}
