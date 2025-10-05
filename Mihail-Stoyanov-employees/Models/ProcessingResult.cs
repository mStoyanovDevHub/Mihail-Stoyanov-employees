namespace Mihail_Stoyanov_employees.Models
{
    public class ProcessingResult
    {
        public PairResultDto TopPair { get; set; }
        public List<PairResultDto> AllPairs { get; set; } = new();
    }
}
