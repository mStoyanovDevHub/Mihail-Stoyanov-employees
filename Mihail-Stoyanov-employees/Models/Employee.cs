namespace Mihail_Stoyanov_employees.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public List<EmployeeProject> Projects { get; set; } = new();
    }
}
