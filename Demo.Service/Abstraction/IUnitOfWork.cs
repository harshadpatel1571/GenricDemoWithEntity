namespace Demo.Service.Abstraction;

public interface IUnitOfWork : IDisposable
{
    IStudentService StudentService { get; }
    IEmployeeService EmployeeService { get; }
    int Save();
}
