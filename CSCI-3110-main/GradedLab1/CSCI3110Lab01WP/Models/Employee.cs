namespace CSCI3110Lab01WP.Models;

public class Employee
{
    public Employee(string name, Department department)
    {
        Name = name;
        Department = department;
    }

    public string? Name { get; set; }
    public Department Department { get; set; }
}
