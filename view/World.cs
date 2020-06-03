using System;
using System.Collections.Generic;
using NUnit.Framework;
using SFML.Graphics;
using SFML.System;

namespace TowerDefence
{
    class World : Transformable, Drawable
    {
        public int SizeX, SizeY;
        public int[,] intMap;
        public Tile[,] tiles;
        public Tile activeTile;
        public List<Shape> Towers;

        public List<Image> ImageTowers;

        public World(string[] srcMap)
        {
            Sources.Load();
            intMap = ConstructMap(srcMap);

            Towers = new List<Shape>();

            SizeX = srcMap[0].Length;
            SizeY = srcMap.Length;

            tiles = new Tile[SizeX, SizeY];

            for (int i = 0; i < SizeX; i++)
            {
                for (int j = 0; j < SizeY; j++)
                {
                    SetTile(i, j, intMap[i, j]);
                }
            }
        }

        public int[,] ConstructMap(string[] src)
        {
            int
                x = src[0].Length,
                y = src.Length;
            var result = new int[x, y];

            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < y; j++)
                {
                    //Console.WriteLine("calc" + x + ' ' + y);
                    if (src[j][i] != 'r')
                    {
                        result[i, j] = 0;
                        continue;
                    }

                    result[i, j] = 7;
                }
            }

            return result;
        }

        public void SetTile(int x, int y, int id)
        {
            tiles[x, y] = new Tile(id);
            tiles[x, y].Position = MathModule.ViewTransform(x, y) + Config.PositionShift;
        }

        public void Update()
        {
            foreach (var tile in tiles)
            {
                tile.shape.OutlineColor = Color.Black;
            }

            if (MathModule.CorrectVector(Controller.NormalizedMousePosition))
            {
                activeTile = tiles[Controller.NormalizedMousePosition.X, Controller.NormalizedMousePosition.Y];
                activeTile.shape.OutlineColor = Color.White;
            }

            if (Model.TowerListChanged)
            {
                Model.TowerListChanged = false;
                Towers.Clear();
                if (Model.Towers.Count != 0)
                {
                    foreach (var tower in Model.Towers)
                    {
                        Towers.Add(new CircleShape()
                        {
                            Radius = 10,
                            Origin = new Vector2f(10, -10),
                            Position = MathModule.ViewTransform((Vector2f) tower.position) + Config.PositionShift,
                            FillColor = Config.AttributeColor[(int) tower.Attribute],
                            OutlineColor = Color.Black,
                            OutlineThickness = 2
                        });

                        Towers.Add(new RectangleShape()
                        {
                            Size = new Vector2f(100, 100),
                            Origin = new Vector2f(50, 50),
                            Position = MathModule.ViewTransform((Vector2f) tower.position) + Config.PositionShift,
                            Texture = Sources.TowerTextures[1]
                        });
                    }
                }

                Towers.Sort(CompareTowersDepth);
            }
        }

        private static int CompareTowersDepth(Shape A, Shape B) => (A.Position.Y).CompareTo(B.Position.Y);

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

            if (activeTile != null)
                target.Draw(activeTile);
            foreach (var tower in Towers)
            {
                target.Draw(tower);
            }
        }
    }
}