using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagament.Api.Controllers
{
    [ApiController]
    [Route("api/v1")]
    public class StudentController : Controller
    {
        private readonly ILogger<StudentController> _logger;
        public StudentController(ILogger<StudentController> logger)
        {
            this._logger = logger;
        }

        [HttpGet("ping")]
        public async Task<IActionResult> Ping()
        {
            _logger.LogInformation("ping method got hit");
            return Ok(new { Message = "hai" });
        }
    }
}

//https://localhost:8081/api/v1/ping
