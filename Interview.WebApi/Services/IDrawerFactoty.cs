using System.Text;

namespace Interview.WebApi.Services
{
    public interface IDrawer
    {
        public string Draw(int size, char c);
    }
    public class SquareDrawer : IDrawer
    {
        public string Draw(int size, char c)
        {
            var sb = new StringBuilder();
            sb.Append(c, size);

            var line = sb.ToString();
            sb.Clear();
            for (var i = 0; i < size; i += 1)
            {

                sb.Append(line);
                sb.AppendLine();
            }
            return sb.ToString();
        }
    }
    public class CircleDrawer : IDrawer
    {
        private string BuildLine(int radius, int height, char c)
        {
            var dump = Math.Sqrt((radius * radius) - (radius - height) * (radius - height));
            var lineLength = 2 * Convert.ToInt32(dump);
            var paddingCount = (2 * radius - lineLength) / 2;
            var lineBuilder = new StringBuilder();
            lineBuilder.Append(c, lineLength);
            var line = lineBuilder.ToString();
            var padding = string.Concat(Enumerable.Repeat(" ", paddingCount));
            line = padding + line + padding;
            return line;
        }
        public string Draw(int size, char c)
        {
            var sb = new StringBuilder();
            var radius = size;
            for (var i = 0; i < radius; i++)
            {
                var line = BuildLine(radius, i, c);
                sb.Append(line);
                sb.AppendLine();
            }
            for (var i = radius; i >= 0; i--)
            {
                var line = BuildLine(radius, i, c);
                sb.Append(line);
                sb.AppendLine();
            }

            return sb.ToString();


        }
    }
    public class TriangleDrawer : IDrawer
    {
        public string Draw(int size, char c)
        {
            var sb = new StringBuilder();

            for (var i = 0; i < size; i += 1)
            {
                var lineBuilder = new StringBuilder();
                lineBuilder.Append(c, i + 1);
                sb.Append(lineBuilder.ToString());
                sb.AppendLine();
            }
            return sb.ToString();
        }
    }
    public interface IDrawerFactory
    {
        public IDrawer Create(string shape);
    }
}