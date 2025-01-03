public class Course
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty; // Initialized with a default value
    public string Description { get; set; } = string.Empty; // Initialized with a default value
    public List<Student> EnrolledStudents { get; set; } = new List<Student>(); // Initialized with an empty list
}
