using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessObjects.DTOs
{
    public class EnrollmentDTO
    {
        public int CourseId { get; set; }

        public int UserId { get; set; }

        public DateTime EnrollmentDate { get; set; }
    }
}
