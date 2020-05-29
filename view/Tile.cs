using SFML.Graphics;

namespace TowerDefence
{
    class Tile : Transformable, Drawable
    {
        public ConvexShape shape;

        public Tile(int id)
        {
            shape = new ConvexShape(4)
            {
                OutlineColor = Color.Black,
                OutlineThickness = 2,
                FillColor = getTileColor(id)
            };
            shape.SetPoint(0, MathModule.ViewTransform(0, 0));
            shape.SetPoint(1, MathModule.ViewTransform(0, 1));
            shape.SetPoint(2, MathModule.ViewTransform(1, 1));
            shape.SetPoint(3, MathModule.ViewTransform(1, 0));
        }

        private Color getTileColor(int id)
        {
            if (id == TileID.Field) return Color.Green;
            if (id == TileID.Road) return Color.Yellow;
            return Color.Black;
        }

        public void Draw(RenderTarget target, RenderStates states)
        {
            states.Transform *= Transform;
            target.Draw(shape, states);
        }
        
        //private static void MouseHover(object sender, EventArgs e) => shape;

    }

    struct TileID
    {
        public static int Field = 0;
        public static int Road = 1;
    }
}