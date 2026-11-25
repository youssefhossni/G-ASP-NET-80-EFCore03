using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp28.Models
{
    public class Enrollment
    {
        public int CourseId { get; set; }
        public Course Course { get; set; }

        public int StudentId { get; set; }
        public Student Student { get; set; }
        public DateTime EnrolledAt { get; set; }
        public int ProgressPercentage { get; set; }
        public EnrollmentStatus Status { get; set; }
        public decimal? FinalGrade { get; set; }
    }
}
