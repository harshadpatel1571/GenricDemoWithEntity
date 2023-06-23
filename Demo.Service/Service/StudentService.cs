namespace Demo.Service.Service;

class StudentService : GenericService<StudentDto>, IStudentService
{
    public StudentService(DemoContext context) : base(context)
    {
    }

    async Task<IEnumerable<StudentDto>> IStudentService.FindByMobile(string mobile)
    {
        return await _context.Student.Where(x=>x.MobileNo.Contains(mobile)).ToListAsync().ConfigureAwait(false);
    }     

    async Task<IEnumerable<CourseDto>> IStudentService.GetStudentWiseCourseList()
    {
        return await _context.StudentCourse.Select(x => new CourseDto
        {
            Id = x.Id,
            CourseDate = x.CourseDate,
            CourseName = x.CourseName,
            StudentId = x.StudentId,
            Student = x.Student
            
        }).ToListAsync().ConfigureAwait(false);
    }
}
