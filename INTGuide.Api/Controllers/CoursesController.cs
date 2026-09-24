using INTGuide.Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace INTGuide.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CoursesController : ControllerBase
{
    [HttpGet]
    public IActionResult GetCourses()
    {
        var courses = new List<Course>
        {
            new Course
            {
                Id = 1,
                Title = "C# Fundementals",
                Description = "Learn the fundementals of C#",
                Level = "Beginner"
            },
            new Course 
            {
                Id = 2,
                Title = "ASP.NET Core",
                Description = "Learn how to build APIs with ASP.Net Core",
                Level = "Intermediate"
            }
        };
        return Ok(courses);
    }
}
