using Microsoft.AspNetCore.Mvc;
using OnlineAccountingServer.Presentation.Abstraction;

namespace OnlineAccountingServer.Presentation.Controllers;

public sealed class TestsController : ApiController
{
    [HttpGet]
    public IActionResult Get()
    {
        return Ok("Hello from OnlineAccountingServer.Presentation.Controllers.TestsController!");
    }
}
