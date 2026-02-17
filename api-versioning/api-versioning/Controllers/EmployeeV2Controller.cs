using Microsoft.AspNetCore.Mvc;

namespace api_versioning.Controllers
{
    [Route("api/employee")]
    [ApiController]
    public class EmployeeV2Controller : ControllerBase
    {
        [HttpGet]
        [MapToApiVersion("2.0")]
        public IActionResult Get()
        {
            return new OkObjectResult("Employee V2");
        }
    }
}
