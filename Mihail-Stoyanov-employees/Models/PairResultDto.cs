namespace Mihail_Stoyanov_employees.Models
{
    public class PairResultDto
    {
        public int EmpId1 { get; set; }
        public int EmpId2 { get; set; }
        public int TotalDays { get; set; }
        public List<PairProjectDetail> Projects { get; set; } = new();
    }
}
