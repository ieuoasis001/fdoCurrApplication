using fdoCurrApp.Models;
using System.Data.Entity;

namespace fdoCurrApp.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext() : base(@"Data Source=10.0.50.27;Initial Catalog=currDept;User ID=oasis;Password=Zx5gENmhYNjg9+T@") { }

        public DbSet<Lecturer> lecturerInfo { get; set; }
        public DbSet<Course> course { get; set; }
        public DbSet<Curr> curr { get; set; }
        public DbSet<Fdo> fdo { get; set; }
        public DbSet<School> school { get; set; }
        public DbSet<CurrElecStuCount> currElecStuCount { get; set; }
        public DbSet<CurrElecCourses> currElecCourses { get; set; }
    }
}
