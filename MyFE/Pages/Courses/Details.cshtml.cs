using BussinessObjects;
using BussinessObjects.DTOs;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net.Http.Headers;
using System.Security.Claims;

namespace MyFE.Pages.Courses
{
    public class DetailsModel : PageModel
    {
        private readonly HttpClient _httpClient;

        public DetailsModel(IHttpClientFactory factory)
        {
            _httpClient = factory.CreateClient("ApiClient");
        }

        [BindProperty(SupportsGet = true)]
        public int Id { get; set; }

        public CourseDetailDTO? Course { get; set; }

        public EnrollmentDTO Enrollments { get; set; } = new();

        [TempData]
        public string? SuccessMessage { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            var token = User.FindFirst("Token")?.Value;

            if (string.IsNullOrEmpty(token))
            {
                await HttpContext.SignOutAsync("MyCookieAuth");
                return RedirectToPage("/Auth/Login", new { returnUrl = Request.Path });
            }

            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var coursesResponse = await _httpClient.GetAsync($"courses/{Id}");
            if (coursesResponse.StatusCode == System.Net.HttpStatusCode.Unauthorized ||
                coursesResponse.StatusCode == System.Net.HttpStatusCode.Forbidden)
            {
                await HttpContext.SignOutAsync("MyCookieAuth");
                return RedirectToPage("/Auth/Login", new { returnUrl = Request.Path });
            }
            if (coursesResponse.IsSuccessStatusCode)
            {
                Course = await coursesResponse.Content.ReadFromJsonAsync<CourseDetailDTO>();
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var token = User.FindFirst("Token")?.Value;

            if (string.IsNullOrEmpty(token))
            {
                await HttpContext.SignOutAsync("MyCookieAuth");
                return RedirectToPage("/Auth/Login", new { returnUrl = Request.Path });
            }
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);
            if (userIdClaim == null || !int.TryParse(userIdClaim.Value, out int userId))
            {
                ModelState.AddModelError("", "You need to log in to enrollment.");
                await OnGetAsync();
                return Page();
            }

            Enrollments.UserId = userId;
            Enrollments.CourseId = Id;
            Enrollments.EnrollmentDate = DateTime.Now;

            var res = await _httpClient.PostAsJsonAsync("enrollments", Enrollments);
            if (res.IsSuccessStatusCode)
            {
                SuccessMessage = "Enrollment added successfully!";
                return RedirectToPage(new { id = Id });
            }
            else if (res.StatusCode == System.Net.HttpStatusCode.Unauthorized ||
                     res.StatusCode == System.Net.HttpStatusCode.Forbidden)
            {
                await HttpContext.SignOutAsync("MyCookieAuth");
                return RedirectToPage("/Auth/Login", new { returnUrl = Request.Path });
            }

            ModelState.AddModelError("", "Failed to add enrollments");
            await OnGetAsync();
            return Page();
        }
    }
}
