using SFML.Graphics;
using SFML.System;

namespace TowerDefence
{
    class World : Transformable, Drawable
    {
        public int SizeX, SizeY;
        public Tile[,] tiles;

        public World(string[] map)
        {
            char
                Field = '_',
                Road = 'r';

            SizeX = map[0].Length;
            SizeY = map.Length;

            tiles = new Tile[SizeX, SizeY];

            for (int i = 0; i < SizeX; i++)
            {
                for (int j = 0; j < SizeY; j++)
                {
                    if (map[j][i] == Field)
                    {
                        SetTile(i, j, TileID.Field);
                    }
                    else if (map[j][i] == Road)
                    {
                        SetTile(i, j, TileID.Road);
                    }
                }
            }
        }

        public Tile GetTile(int x, int y)
        {
            if (x < 0 || x >= SizeX || y < 0 || y >= SizeY) return null;
            return tiles[x, y];
        }

        public void SetTile(int x, int y, int id)
        {
            tiles[x, y] = new Tile(id);
            tiles[x, y].Position = MathModule.ViewTransform(x, y) + Config.PositionShift;
        }

        public void Draw(RenderTarget target, RenderStates states)
        {
            states.Transform *= Transform;
            for (int i = 0; i < SizeX; i++)
            {
                for (int j = 0; j < SizeY; j++)
                {
                    target.Draw(tiles[i, j]);
                }
            }
            target.Draw(new CircleShape
            {
                Radius = 5,
                Position = Controller.MousePosition,
                FillColor = Controller.Click ? Color.Red : Color.Cyan,
            });
        }
    }
}
