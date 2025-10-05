namespace Mihail_Stoyanov_employees.Models
{
    public class Assignment
    {
        public int EmpId { get; set; }
        public int ProjectId { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; } 
    }
}
