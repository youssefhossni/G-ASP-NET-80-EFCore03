using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp28.Models
{
    public class Instructor
    {

        public int Id { get; set; }
        public string FullName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string? Bio { get; set; }
        public DateTime JoinedAt { get; set; }

        public ICollection<Course> Courses { get; set; } = new List<Course>();
    }
}
