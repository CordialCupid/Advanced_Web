public class Employee
{
    public string Name {get;set;} = string.Empty;
    public Department Department {get; set;}

    public Employee(string name, Department dept)
    {
        Name = name;
        Department = dept;
    }
}