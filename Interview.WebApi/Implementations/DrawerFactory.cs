
using Interview.WebApi.Services;

namespace Interview.WebApi.Implementations
{
    public class DrawerFactory : IDrawerFactory
    {
        public IDrawer Create(string shape)
        {
            if (shape == "square")
            {
                return new SquareDrawer();
            }
            else
            {
                return new TriangleDrawer();
            }
        }
    }
}