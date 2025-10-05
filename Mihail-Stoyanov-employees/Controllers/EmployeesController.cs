using Microsoft.AspNetCore.Mvc;
using Mihail_Stoyanov_employees.Models;
using Mihail_Stoyanov_employees.Services;

namespace Mihail_Stoyanov_employees.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeesController : ControllerBase
    {
        private readonly ICsvProcessingService _service;

        public EmployeesController(ICsvProcessingService service)
        {
            _service = service;
        }
        [HttpPost("upload")]
        public async Task<IActionResult> Upload([FromForm] IFormFile file)
        {
            if (file == null || file.Length == 0)
                return Ok(new { error = true, message = "CSV file is required." });

            try
            {
                ProcessingResult result = await _service.ProcessCsvAsync(file);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return Ok(new { error = true, message = ex.Message });
            }
        }

    }
}

