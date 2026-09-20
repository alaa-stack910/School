using System.Runtime.CompilerServices;
using Microsoft.EntityFrameworkCore;
using School.Model;
namespace School
{
    public class AppContexts:DbContext
    {
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Department> Departments { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\ProjectModels;Initial Catalog=SchoolDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False");
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //department

            modelBuilder.Entity<Department>().Property(b=>b.Name).IsRequired().HasMaxLength(100);
            modelBuilder.Entity<Department>().HasKey(b => b.DepartmentId);
            modelBuilder.Entity<Department>().Property(b => b.Description).HasMaxLength(500);

            //teacher
            modelBuilder.Entity<Teacher>().HasKey(a => a.TeacherId);
            modelBuilder.Entity<Teacher>().HasOne(o => o.department).WithMany(t=>t.Teachers).HasForeignKey(h => h.departmentId);

            modelBuilder.Entity<Teacher>().Property(a=>a.FirstName).IsRequired().HasMaxLength(50);
            modelBuilder.Entity<Teacher>().Property(a=>a.LastName).IsRequired().HasMaxLength(50);
            modelBuilder.Entity<Teacher>().Property(a => a.Email).IsRequired().HasMaxLength(150);
            modelBuilder.Entity<Teacher>().Property(a => a.Phone).HasMaxLength(20);
            modelBuilder.Entity<Teacher>().Property(a => a.Salary).IsRequired();

            modelBuilder.Entity<Department>().HasData(new Department { DepartmentId = 1, Name = "CS", Description = "Computer" });
            modelBuilder.Entity<Department>().HasData(new Department { DepartmentId = 2, Name = "ES", Description = "Embedded" });


            modelBuilder.Entity<Teacher>().HasData(new Teacher { TeacherId = 1, FirstName = "ALaa", LastName = "Soliman", Email = "alaa@gmail.com", Phone = "12345678910", departmentId = 1, Salary = 300 });
            modelBuilder.Entity<Teacher>().HasData(new Teacher { TeacherId = 2, FirstName = "ggg", LastName = "Soliman", Email = "alaa@gmail.com", Phone = "12345678910", departmentId = 2, Salary = 300 });

            //Subject



            base.OnModelCreating(modelBuilder);
        }
    }
}
