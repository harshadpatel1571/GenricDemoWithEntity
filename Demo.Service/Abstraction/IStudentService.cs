using System;

namespace Demo.Service.Abstraction;

public interface IStudentService : IGenericService<StudentDto>
{
    Task<IEnumerable<StudentDto>> FindByMobile(string mobile);

    Task<IEnumerable<CourseDto>> GetStudentWiseCourseList();
}
