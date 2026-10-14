using INTGuide.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace INTGuide.Api.Data;

public static class SeedData
{
    private static List<Course> Courses() =>
    [
        new Course
        {
            Title = "C# Fundamentals",
            Description = "Learn the fundamentals of C#",
            Level = "Beginner"
        },
        new Course
        {
            Title = "ASP.NET Core",
            Description = "Learn how to build APIs with ASP.NET Core",
            Level = "Intermediate"
        }
    ];

    public static void Seed(DbContext context, bool _)
    {
        var courses = context.Set<Course>();
        if (courses.Any())
        {
            return;
        }

        courses.AddRange(Courses());
        context.SaveChanges();
    }

    public static async Task SeedAsync(DbContext context, bool _, CancellationToken cancellationToken)
    {
        var courses = context.Set<Course>();
        if (await courses.AnyAsync(cancellationToken))
        {
            return;
        }

        courses.AddRange(Courses());
        await context.SaveChangesAsync(cancellationToken);
    }
}
