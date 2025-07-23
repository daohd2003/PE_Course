using BussinessObjects.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace MyAPI.Controllers
{
    [Route("api/enrollments")]
    [Authorize]
    [ApiController]
    public class EnrollmentController : ControllerBase
    {
        private readonly IEnrollmentService _commentService;

        public EnrollmentController(IEnrollmentService commentService)
        {
            _commentService = commentService;
        }

        [HttpPost]
        public async Task<IActionResult> AddEnrollment(EnrollmentDTO dto)
        {
            var comments = await _commentService.Enrollment(dto);
            return Ok(comments);
        }
    }
}
