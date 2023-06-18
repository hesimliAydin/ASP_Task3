using ASP_Task3.Entities;
using Microsoft.EntityFrameworkCore;

namespace ASP_Task3.Models
{
    public class StudentDbContext:DbContext
    {
        public StudentDbContext(DbContextOptions<StudentDbContext> options)
            :base(options) { }

        public DbSet<Student> Students { get; set; }
        
    }
}
