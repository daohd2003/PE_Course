using BussinessObjects;
using DataAccessObjects;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class CourseRepository : ICourseRepository
    {
        private readonly Sp25Prn231Pe1Context _context;

        public CourseRepository(Sp25Prn231Pe1Context context) { _context = context; }

        public async Task<bool> CreateCourse(Course course)
        {
            try
            {
                await _context.Courses.AddAsync(course);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }
        }

        public async Task<bool> DeleteCourse(int id)
        {
            try
            {
                var course = await _context.Courses.FindAsync(id);
                if (course == null) return false;
                _context.Courses.Remove(course);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error deleting course: {ex.Message}");
                return false;
            }
        }

        public IQueryable<Course> GetAllCoursesAsQueryable()
        {
            return _context.Courses;
        }

        public async Task<Course?> GetCourseById(int id)
        {
            return await _context.Courses
                     .Include(c => c.Category)
                     .Include(c => c.User)
                     .Include(c =>c.Enrollments)
                     .FirstOrDefaultAsync(c => c.CourseId == id);
        }

        public async Task<IEnumerable<Course>> GetCourses()
        {
            return await _context.Courses
                     .Include(c => c.Category)
                     .Include(c => c.User)
                     .ToListAsync();
        }

        public async Task<bool> UpdateCourse(Course course)
        {
            try
            {
                _context.Entry<Course>(course).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error updating course: {ex.Message}");
                return false;
            }
        }
    }
}
