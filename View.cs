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
            tiles[x, y].Position = new Vector2f(x * Tile.TILE_SIZE, y * Tile.TILE_SIZE);
        }

        public void Draw(RenderTarget target, RenderStates states)
        {
            states.Transform *= Transform;
            for (int i = 0; i < SizeX; i++)
            {
                for (int j = 0; j < SizeY; j++)
                {
                    if (tiles[i, j] == null) continue;

                    target.Draw(tiles[i, j]);
                }
            }
        }
    }

    class Tile : Transformable, Drawable
    {
        public const int TILE_SIZE = 50;
        public RectangleShape shape;
        public int ID;

        public Tile(int id)
        {
            shape = new RectangleShape(new Vector2f(TILE_SIZE, TILE_SIZE));

            this.ID = id;

            if (id == TileID.Field)
            {
                shape.FillColor = Color.Green;
            }
            else if (id == TileID.Road)
            {
                shape.FillColor = Color.Yellow;
            }
        }


        public void Draw(RenderTarget target, RenderStates states)
        {
            states.Transform *= Transform;

            target.Draw(shape, states);
        }
    }

    struct TileID
    {
        public static int Field = 0;
        public static int Road = 1;
    }
}
