using Microsoft.EntityFrameworkCore;
using DotVVM.Samples.NestedViewModel.DAL.Entities;
namespace DotVVM.Samples.NestedViewModel.DAL
{
    public class StudentDbContext : DbContext
    {
        public StudentDbContext(DbContextOptions options) : base(options)
        {
            Database.EnsureCreated();
        }
        public DbSet<Student> Students { get; set; }
    }
}
