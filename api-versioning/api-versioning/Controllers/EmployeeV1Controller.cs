using Microsoft.AspNetCore.Mvc;

namespace api_versioning.Controllers
{
    [Route("api/employee")]
    [ApiController]
    [ApiVersion("1.0")]
    [ApiVersion("2.0")]
    public class EmployeeV1Controller : ControllerBase
    {
        [HttpGet]
        [MapToApiVersion("1.0")]
        public IActionResult Get()
        {
            return new OkObjectResult("Employee V1");
        }
    }
}
