using BussinessObjects;
using BussinessObjects.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public interface ICourseService
    {
        Task<IEnumerable<CourseDTO>> GetCoursesForList();
        Task<CourseDetailDTO?> GetCourseDetails(int id);
        Task<bool> CreateCourse(CreateCourseDTO dto);
        Task<bool> UpdateCourse(UpdateCourseDTO dto);
        Task<bool> DeleteCourse(int id);
        IQueryable<Course> GetCoursesAsQueryable();
    }
}
