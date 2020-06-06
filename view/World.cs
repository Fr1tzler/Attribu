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
        public List<Shape> Mobs;

        public List<Image> ImageTowers;

        public World(string[] srcMap)
        {
            Sources.Load();
            intMap = ConstructMap(srcMap);

            Towers = new List<Shape>();
            Mobs = new List<Shape>();

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
                    if (src[j][i] != 'r')
                    {
                        result[i, j] = MathModule.RandInt(0, 3);
                        continue;
                    }

                    var up = false;
                    var down = false;
                    var left = false;
                    var right = false;

                    if (0 < i)
                    {
                        if (src[j][i - 1] == 'r')
                        {
                            left = true;
                        }
                    }

                    if (i < x - 1)
                    {
                        if (src[j][i + 1] == 'r')
                        {
                            right = true;
                        }
                    }

                    if (0 < j)
                    {
                        if (src[j - 1][i] == 'r')
                        {
                            up = true;
                        }
                    }

                    if (j < y - 1)
                    {
                        if (src[j + 1][i] == 'r')
                        {
                            down = true;
                        }
                    }

                    if (up && down && !left && !right)
                    {
                        result[i, j] = 3;
                        continue;
                    }

                    if (!up && !down && left && right)
                    {
                        result[i, j] = 4;
                        continue;
                    }

                    if (up && !down && !left && right)
                    {
                        result[i, j] = 6;
                        continue;
                    }

                    if (!up && down && !left && right)
                    {
                        result[i, j] = 7;
                        continue;
                    }

                    if (!up && down && left && !right)
                    {
                        result[i, j] = 8;
                        continue;
                    }

                    if (up && !down && left && !right)
                    {
                        result[i, j] = 9;
                        continue;
                    }

                    result[i, j] = 5;
                }
            }

            return result;
        } // хуита но робит и влом менять

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
                        Towers.Add(new RectangleShape()
                        {
                            Size = new Vector2f(100, 100),
                            Origin = new Vector2f(50, 50),
                            Position = MathModule.ViewTransform((Vector2f) tower.position) + Config.PositionShift,
                            Texture = tower.configs.texture
                        });
                    }
                }

                Towers.Sort(CompareSpriteDepth);
            }

            Mobs.Clear();
            if (Model.Wave.Count != 0)
            {
                foreach (var mob in Model.Wave)
                {
                    /*Mobs.Add(new CircleShape()
                    {
                        Radius = 10,
                        Origin = new Vector2f(10, -10),
                        Position = MathModule.ViewTransform(mob.position) + mob.shift + Config.PositionShift,
                        FillColor = Color.Black,
                        OutlineColor = Color.Black,
                        OutlineThickness = 2
                    });*/

                    Mobs.Add(new RectangleShape()
                    {
                        Size = new Vector2f(40, 50),
                        Origin = new Vector2f(20, 20),
                        Position = MathModule.ViewTransform((Vector2f) mob.position) + Config.PositionShift,
                        Texture = mob.configs.texture
                    });
                }
            }
            Mobs.Sort(CompareSpriteDepth);
        }

        private static int CompareSpriteDepth(Shape A, Shape B) => (A.Position.Y).CompareTo(B.Position.Y);

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

            foreach (var mob in Mobs)
            {
                target.Draw(mob);
            }
        }
    }
}