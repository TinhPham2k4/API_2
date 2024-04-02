namespace REST_API_TEMPLATE.Models
{
    public class StudentCourses
    {
        public Student? Student { get; set; }
        public Guid? StudentId { get; set; }
        public Courses? Courses { get; set; }
        public Guid? CoursesId { get; set; }
    }
}
