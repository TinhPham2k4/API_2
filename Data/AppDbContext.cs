using Microsoft.EntityFrameworkCore;
using REST_API_TEMPLATE.Models;

namespace REST_API_TEMPLATE.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<Student> Students { get; set; }
        public DbSet<Courses> Courses { get; set; }
        public DbSet<Models.StudentCourses> StudentCourses { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Models.StudentCourses>().HasKey(h => new { h.StudentId, h.CoursesId });
            builder.Entity<Models.StudentCourses>().HasOne(h => h.Courses).WithMany(h => h.StudentCourses);
            builder.Entity<Models.StudentCourses>().HasOne(h => h.Student).WithMany(h => h.StudentCourses);

            new DbInitializer(builder).Seed();
        }

        public class DbInitializer
        {
            private readonly ModelBuilder _builder;
            public DbInitializer(ModelBuilder builder)
            {
                this._builder = builder;
            }

            public void Seed()
            {
                _builder.Entity<Student>(s =>
                {
                    s.HasData(new Student
                    {
                        StudentId = new Guid("e2397972-8743-431a-9482-60292f08320e"),
                        Name = "Phạm Văn Tình"
                    });
                    s.HasData(new Student
                    {
                        StudentId = new Guid("4e79044a-988d-4488-97b7-3e474e4340d2"),
                        Name = "Nguyễn Hữu Thạch"
                    });
                });
                _builder.Entity<Courses>(c =>
                {
                    c.HasData(new Courses
                    {
                        CourseId = new Guid("9250d994-2558-4573-8465-417248667051"),
                        CourseName = "Tin Học",
                        Description = "Hổ trợ về tin học cơ bản"
                    });
                    c.HasData(new Courses
                    {
                        CourseId = new Guid("88738493-3a85-4443-8f6a-313453432192"),
                        CourseName = "Địa Lý",
                        Description = "Hiểu rõ về địa hình địa lý trong nước...",
                    });
                });
                _builder.Entity<Models.StudentCourses>(sc =>
                {
                    sc.HasData(new Models.StudentCourses
                    {
                        StudentId = new Guid("e2397972-8743-431a-9482-60292f08320e"),
                        CoursesId = new Guid("88738493-3a85-4443-8f6a-313453432192")
                    });
                    sc.HasData(new Models.StudentCourses
                    {
                        StudentId = new Guid("4e79044a-988d-4488-97b7-3e474e4340d2"),
                        CoursesId = new Guid("9250d994-2558-4573-8465-417248667051")
                    });
                });
            }
        }
    }
}
