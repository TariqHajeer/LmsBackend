using System;
using System.Collections.Generic;

#nullable disable

namespace LMSbackend.Models
{
    public partial class Exam
    {
        public Exam()
        {
            Questions = new HashSet<Question>();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime Date { get; set; }
        public string Pwassowrd { get; set; }

        public virtual ICollection<Question> Questions { get; set; }
    }
}
