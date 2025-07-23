using BussinessObjects;
using BussinessObjects.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Services;

namespace MyAPI.Controllers
{
    [Route("api/courses")]
    [Authorize]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly ICourseService _articleService;

        public CourseController(ICourseService articleService)
        {
            _articleService = articleService;
        }

        [HttpGet("/odata/Courses")]
        [EnableQuery]
        public ActionResult<IQueryable<Course>> GetODataCourses()
        {
            var articles = _articleService.GetCoursesAsQueryable();
            return Ok(articles);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCourses()
        {
            var articles = await _articleService.GetCoursesForList();
            return Ok(articles);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAllCourses(int id)
        {
            var articles = await _articleService.GetCourseDetails(id);
            return Ok(articles);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCourse([FromBody] CreateCourseDTO dto)
        {
            var articles = await _articleService.CreateCourse(dto);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCourse([FromBody] UpdateCourseDTO dto)
        {
            var articles = await _articleService.UpdateCourse(dto);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCourse(int id)
        {
            var articles = await _articleService.DeleteCourse(id);
            return Ok();
        }
    }
}
