namespace Interview.WebApi.Services
{
    public class DrawerFactory : IDrawerFactory
    {
        public IDrawer Create(string shape)
        {
            if (shape == "square")
            {
                return new SquareDrawer();
            }
            else if (shape == "circle")
            {
                return new CircleDrawer();
            }
            else
            {
                return new TriangleDrawer();
            }
        }
    }
}