using Microsoft.EntityFrameworkCore;
public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    // Define your DbSets here
    public DbSet<Employee> Employees { get; set; }
    public DbSet<Department> Departments { get; set; }
}

public class Employee{
    public Guid EmployeeId { get; set; }
    public string Name { get; set; }
    public Guid DepartmentId { get; set; }
    public Department Department { get; set; }
    public int Salary { get; set; }
}
public class Department{
    public Guid DepartmentId { get; set; }
    public string Name { get; set; }
}