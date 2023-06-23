namespace Demo.Db.Dto;

public class CourseDto
{
    public int Id { get; set; }
    public string CourseName { get; set; } = string.Empty;
    public DateTime CourseDate { get; set; }

    public int StudentId {get; set;}

    public StudentDto Student { get; set; }
}
