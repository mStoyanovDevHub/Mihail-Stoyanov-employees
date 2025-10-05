using Mihail_Stoyanov_employees.Models;

namespace Mihail_Stoyanov_employees.Services
{
    public interface ICsvProcessingService
    {
        Task<ProcessingResult> ProcessCsvAsync(IFormFile csvFile);
    }
}
