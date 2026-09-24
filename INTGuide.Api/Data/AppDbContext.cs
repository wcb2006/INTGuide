using INTGuide.Api.Controllers;
using INTGuide.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace INTGuide.Api.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
        
    }
    
    public DbSet<Course> Courses => Set<Course>(); 
}