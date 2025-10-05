namespace Mihail_Stoyanov_employees.Models
{
    public class Project
    {
        public int Id { get; set; }
        public List<EmployeeProject> Employees { get; set; } = new();
    }
}
