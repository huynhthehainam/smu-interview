
using System.ComponentModel.DataAnnotations;

namespace Interview.WebApi.Commands
{
    public class DrawSquareCommand
    {
        public string Shape { get; set; } = "square";
        [Range(0, 100)]
        public int Size { get; set; } = 1;
    }
    public class DrawTriangleCommand : DrawSquareCommand
    {
        public new string Shape { get; set; } = "triangle";
    }
    public class DrawShapeCommand : DrawSquareCommand
    {
        public char Symbol { get; set; } = '*';
    }
}