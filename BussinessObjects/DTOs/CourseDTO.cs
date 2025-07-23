using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessObjects.DTOs
{
    public class CourseDTO
    {
        public int CourseId { get; set; }
        public string Title { get; set; } = null!;
        public string CategoryName { get; set; }
        public string Author { get; set; }
        public string Description { get; set; }
    }
}
