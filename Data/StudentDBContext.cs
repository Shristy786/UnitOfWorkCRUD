using Microsoft.EntityFrameworkCore;
using UnitOfWorkCRUD.Models;

namespace UnitOfWorkCRUD.Data
{
    public class StudentDBContext : DbContext
    {
        public StudentDBContext(DbContextOptions options) : base(options)
        {


        }


        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
    }
}
