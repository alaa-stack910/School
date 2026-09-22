using System.Runtime.CompilerServices;
using Microsoft.EntityFrameworkCore;
using School.Model;
namespace School
{
    public class AppContexts:DbContext
    {
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<ClassRoom> ClassRooms { get; set; }
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

            modelBuilder.Entity<ClassRoom>().HasData(
        new ClassRoom
        {
            Id = 1,
            Name = "Class 1A",
            GradeLevel = 1,
            Capacity = 30
        },
        new ClassRoom
        {
            Id = 2,
            Name = "Class 2A",
            GradeLevel = 2,
            Capacity = 30
        });

            modelBuilder.Entity<Subject>().HasData(
       new Subject
       {
           Id = 1,
           Name = "Mathematics",
           Description = "Basic mathematics and problem solving",
           MaxGrade = 100,
           TeacherId = 1
       },
       new Subject
       {
           Id = 2,
           Name = "English",
           Description = "English language, grammar and literature",
           MaxGrade = 100,
           TeacherId = 2
       });
            modelBuilder.Entity<Student>().HasData(
        new Student
        {
            Id = 1,
            FirstName = "Ahmed",
            LastName = "Ali",
            Email = "ahmed.ali@gmail.com",
            PhoneNumber = "01012345678",
            DateOfBirth = new DateOnly(2008, 5, 10),
            ClassRoomId = 1
        },
        new Student
        {
            Id = 2,
            FirstName = "Mariam",
            LastName = "Hassan",
            Email = "mariam.hassan@gmail.com",
            PhoneNumber = "01123456789",
            DateOfBirth = new DateOnly(2008, 8, 15),
            ClassRoomId = 1
        });

            modelBuilder.Entity<Enrollment>().HasData(
        new Enrollment
        {
            Id = 1,
            StudentId = 1,
            SubjectId = 1,
            EnrollmentDate = new DateTime(2026, 9, 1),
            Grade = 95
        },
        new Enrollment
        {
            Id = 2,
            StudentId = 1,
            SubjectId = 2,
            EnrollmentDate = new DateTime(2026, 9, 2),
            Grade = 88
        },
        new Enrollment
        {
            Id = 3,
            StudentId = 2,
            SubjectId = 1,
            EnrollmentDate = new DateTime(2026, 9, 1),
            Grade = 92
        });


           base.OnModelCreating(modelBuilder);
        }
    }
}
