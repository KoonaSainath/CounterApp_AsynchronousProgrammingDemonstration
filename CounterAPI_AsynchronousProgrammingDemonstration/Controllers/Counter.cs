using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CounterAPI_AsynchronousProgrammingDemonstration.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Counter : ControllerBase
    {
        [HttpGet]
        [Route(template: "IncrementCount/{currentCount}", Name = "IncrementCount")]
        public IActionResult IncrementCount(int currentCount)
        {
            Thread.Sleep(5000);
            return Ok(++currentCount);
        }
    }
}
