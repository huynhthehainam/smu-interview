using System.Text;
using Interview.WebApi.Commands;
using Interview.WebApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace Interview.WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TestController : ControllerBase
{
    private readonly ILogger<TestController> logger;
    private readonly IDrawerFactory drawerFactory;

    public TestController(ILogger<TestController> logger, IDrawerFactory drawerFactory)
    {
        this.logger = logger;
        this.drawerFactory = drawerFactory;
    }

    [HttpPost("DrawSquare")]
    public IActionResult DrawSquare([FromBody] DrawSquareCommand command)
    {

        // For task only task 1
        var sb = new StringBuilder();
        sb.Append('*', command.Size);

        var line = sb.ToString();
        sb.Clear();
        for (var i = 0; i < command.Size; i += 1)
        {

            sb.Append(line);
            sb.AppendLine();
        }
        return Ok(sb.ToString());
    }
    [HttpPost("DrawTriangle")]
    public IActionResult DrawTriangle([FromBody] DrawTriangleCommand command)
    {
        // After finishing task 1, I recognize that I can reuse command for task 2
        var sb = new StringBuilder();
        for (var i = 0; i < command.Size; i += 1)
        {
            var lineBuilder = new StringBuilder();
            lineBuilder.Append('*', i + 1);
            sb.Append(lineBuilder.ToString());
            sb.AppendLine();
        }
        return Ok(sb.ToString());
    }
    [HttpPost("DrawShape")]
    public IActionResult DrawShape([FromBody] DrawShapeCommand command)
    {
        // After finishing task 2, I recognize that we can implement some design pattern here: Factory, Composite
        // I duplicate drawing code to say that all task is in series. After I got task 3, I just decide to implement design pattern
        var drawer = drawerFactory.Create(command.Shape);

        return Ok(drawer.Draw(command.Size, command.Symbol));
    }
}
