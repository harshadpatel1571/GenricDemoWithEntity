namespace Demo.Service.Service;

class EmployeeService : GenericService<EmployeeDto>, IEmployeeService
{
    public EmployeeService(DemoContext context) : base(context)
    {
    }
}
