using System.ComponentModel.DataAnnotations;

namespace REST_API_TEMPLATE.Models
{
    public class Student
    {
        [Key]
        public Guid? StudentId { get; set; }
        public string? Name { get; set; }
        public List<StudentCourses>? StudentCourses { get; set; }
    }
}
