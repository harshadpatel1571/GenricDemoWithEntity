namespace Demo.Db.Context;

public class DemoContext : DbContext
{
    public DemoContext(DbContextOptions options) : base(options) { }
    public DbSet<EmployeeDto> Employee { get; set; }
    public DbSet<StudentDto> Student { get; set; }
    public DbSet<CourseDto> StudentCourse { get; set; }
}
