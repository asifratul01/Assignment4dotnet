public class Student
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty; // Initialized with a default value
    public string Email { get; set; } = string.Empty; // Initialized with a default value
    public List<Course> EnrolledCourses { get; set; } = new List<Course>(); // Initialized with an empty list
}
