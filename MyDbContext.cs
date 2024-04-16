using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApplication1;

public class MyDbContext : DbContext
{
    public MyDbContext(DbContextOptions<MyDbContext> options)
        : base(options)
    {
    }

    // Correct the DbSet property names to match the actual table names including their schema
    public DbSet<Employee> Employees { get; set; } // Assuming Employee is under HumanResources schema.
    public DbSet<Person> People { get; set; } // Assuming Person is under Person schema.
    public DbSet<EmployeeDepartmentHistory> EmployeeDepartmentHistories { get; set; } // Assuming EmployeeDepartmentHistory is under HumanResources schema.

    // ... Rest of your code ...

    // Remember to configure the model to match the schema and table names in OnModelCreating method if it's not done by convention or annotations.
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Employee>().ToTable("Employee", schema: "HumanResources");
        modelBuilder.Entity<Person>().ToTable("Person", schema: "Person");
        modelBuilder.Entity<EmployeeDepartmentHistory>().ToTable("EmployeeDepartmentHistory", schema: "HumanResources");

        // ... Any additional configuration ...
    }

    // Method to fetch all employees from the database
    public async Task<List<Employee>> GetAllEmployeesAsync()
    {
        return await Employees
            .Join(
                People,
                emp => emp.BusinessEntityID,
                person => person.BusinessEntityID,
                (emp, person) => new { emp, person }
            )
            .Join(
                EmployeeDepartmentHistories,
                joinResult => joinResult.emp.BusinessEntityID,
                deptHistory => deptHistory.BusinessEntityID,
                (joinResult, deptHistory) => new Employee
                {
                    BusinessEntityID = joinResult.emp.BusinessEntityID,
                    NationalIDNumber = joinResult.emp.NationalIDNumber,
                    LoginID = joinResult.emp.LoginID,
                    //OrganizationNode = joinResult.emp.OrganizationNode,
                    OrganizationLevel = joinResult.emp.OrganizationLevel,
                    JobTitle = joinResult.emp.JobTitle,
                    BirthDate = joinResult.emp.BirthDate,
                    MaritalStatus = joinResult.emp.MaritalStatus,
                    Gender = joinResult.emp.Gender,
                    HireDate = joinResult.emp.HireDate,
                    SalariedFlag = joinResult.emp.SalariedFlag,
                    VacationHours = joinResult.emp.VacationHours,
                    SickLeaveHours = joinResult.emp.SickLeaveHours,
                    CurrentFlag = joinResult.emp.CurrentFlag,
                    rowguid = joinResult.emp.rowguid,
                    ModifiedDate = joinResult.emp.ModifiedDate,
                    FirstName = joinResult.person.FirstName,
                    LastName = joinResult.person.LastName,
                    DepartmentID = deptHistory.DepartmentID
                }
            )
            .Skip(1)
            .ToListAsync();
    }

}
