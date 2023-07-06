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
        var drawer = drawerFactory.Create(command.Shape);
        
        return Ok(drawer.Draw(command.Size, command.Symbol));
    }
}
