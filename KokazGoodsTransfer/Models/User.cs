using System;
using System.Collections.Generic;

#nullable disable

namespace LMSbackend.Models
{
    public partial class User
    {
        public User()
        {
            StudentAnswers = new HashSet<StudentAnswer>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool IsAdmin { get; set; }

        public virtual ICollection<StudentAnswer> StudentAnswers { get; set; }
    }
}
