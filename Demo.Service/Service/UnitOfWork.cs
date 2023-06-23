namespace Demo.Service.Service;

public class UnitOfWork : IUnitOfWork
{
    private DemoContext _context;
    public UnitOfWork(DemoContext context)
    {
        _context = context;
        StudentService = new StudentService(context);
        EmployeeService = new EmployeeService(context);
    }

    public IStudentService StudentService { get; private set; }
    public IEmployeeService EmployeeService { get; private set; }

    public void Dispose()
    {
        _context.Dispose();
    }
    public int Save()
    {
        return _context.SaveChanges();
    }

}
