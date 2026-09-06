using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[ApiController]
[Route("api/[controller]")]
public class EmployeesController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public EmployeesController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var employees = await _context.Employees
            .Include(e => e.Department)
            .ToListAsync();
        return Ok(employees);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateEmployeeRequest request)
    {
        var department = new Department
        {
            DepartmentId = Guid.NewGuid(),
            Name = request.DepartmentName
        };

        var employee = new Employee
        {
            EmployeeId = Guid.NewGuid(),
            Name = request.Name,
            Salary = request.Salary,
            Department = department
        };

        _context.Employees.Add(employee);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetAll), new { id = employee.EmployeeId }, employee);
    }
}

public record CreateEmployeeRequest(string Name, int Salary, string DepartmentName);