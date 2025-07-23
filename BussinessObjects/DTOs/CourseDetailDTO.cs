using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessObjects.DTOs
{
    public class CourseDetailDTO
    {
        public string Title { get; set; } = null!;

        public string? Description { get; set; }

        public int CategoryId { get; set; }

        public int UserId { get; set; }

        public decimal Price { get; set; }

        public DateTime CreatedAt { get; set; }

        public string CategoryName { get; set; }
        public string Author { get; set; }
    }
}
