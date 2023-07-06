
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