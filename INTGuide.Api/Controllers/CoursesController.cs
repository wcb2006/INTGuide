using INTGuide.Api.Data;
using INTGuide.Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace INTGuide.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CoursesController : ControllerBase
{
    private readonly AppDbContext _db;

    public CoursesController(AppDbContext db)
    {
        _db = db;
    }

    [HttpGet]
    public async Task<ActionResult<List<Course>>> GetCourses()
    {
        return await _db.Courses.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Course>> GetCourse(int id)
    {
        var course = await _db.Courses.FindAsync(id);
        if (course is null)
        {
            return NotFound();
        }
        return course;
    }

    [HttpPost]
    public async Task<ActionResult<Course>> CreateCourse(Course course)
    {
        _db.Courses.Add(course);
        await _db.SaveChangesAsync();
        return CreatedAtAction(nameof(GetCourse), new { id = course.Id }, course);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateCourse(int id, Course updated)
    {
        var course = await _db.Courses.FindAsync(id);
        if (course is null)
        {
            return NotFound();
        }

        course.Title = updated.Title;
        course.Description = updated.Description;
        course.Level = updated.Level;

        await _db.SaveChangesAsync();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCourse(int id)
    {
        var course = await _db.Courses.FindAsync(id);
        if (course is null)
        {
            return NotFound();
        }

        _db.Courses.Remove(course);
        await _db.SaveChangesAsync();
        return NoContent();
    }
}
