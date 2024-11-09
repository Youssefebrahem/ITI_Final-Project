using ITI_Project.Models;
using Microsoft.EntityFrameworkCore;

namespace ITI_Project.Data
{
    public class ITIContext:DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Account> Accounts { get; set; }

        public ITIContext(DbContextOptions options) : base(options) { }
        public ITIContext() { } 

            protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {
                optionsBuilder.UseSqlServer("Server =YOUSSEFEBRAHEM\\SQLEXPRESS;Database=ITI_MVC;Integrated Security=True;Trust Server Certificate=True;Trusted_Connection=True;");
                base.OnConfiguring(optionsBuilder);
            }

    }
}
