using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace Engine.Entities
{
    public class TileMap : Entity
    {
        public bool autoBorder;
        short[,] map;
        Vector2 size;
        public Vector2 tileSize = new Vector2(10);
        List<Texture2D> tiles = new List<Texture2D>();

        public TileMap(int sx = 100, int sy = 100)
        {
            size = new Vector2(sx, sy);
            LoadTiles();
            map = new short[sx, sy];
            map[5, 5] = 1;
        }

        void LoadTiles()
        {
            tiles.Add(GameMain.content.Load<Texture2D>("testTiles"));
            tiles.Add(GameMain.content.Load<Texture2D>("testTiles"));
        }

        public override void Update()
        {
            base.Update();

            if (Input.pressedKeys.Contains(Keys.H))
            {
                Point pos = WorldToTile(Camera.position);
                SetTile(pos.X, pos.Y, 1);
            }

        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            for (int x = 0; x < size.X; x++)
                for (int y = 0; y < size.Y; y++)
                {
                    DrawTile(x, y, spriteBatch);
                }
        }

        void DrawTile(int x, int y, SpriteBatch spriteBatch)
        {
            Point spriteLocation = GetTileSprite(x, y);
            Point spritePoint = new Point(spriteLocation.X/ (int)tileSize.X, spriteLocation.Y / (int)tileSize.Y);
            Vector2 tileLocation = new Vector2(x * tiles[map[x, y]].Width / 3, y * tiles[map[x, y]].Height / 3);
            Rectangle rect = new Rectangle(spriteLocation, new Point(tiles[map[x, y]].Width / 3, tiles[map[x, y]].Height / 3));
            spriteBatch.Draw(tiles[map[x, y]], Position + tileLocation, rect, Color.White, 0.0f, Vector2.Zero, 1, SpriteEffects.None, 1);
        }

        Point GetTileSprite(int x, int y, int size = 10)
        {
            //return Point.Zero;
            int X,Y;
            if (GetTile(x, y) == GetTile(x - 1, y) && GetTile(x, y) == GetTile(x + 1, y))
            {
                X = 1;
            }
            else if (GetTile(x, y) == GetTile(x - 1, y))
            {
                X = 2;
            }
            else if (GetTile(x, y) == GetTile(x + 1, y))
            {
                X = 0;
            }
            else X = 3;

            if (GetTile(x, y) == GetTile(x, y - 1) && GetTile(x, y) == GetTile(x, y + 1))
            {
                Y = 1;
            }
            else if (GetTile(x, y) == GetTile(x, y - 1))
            {
                Y = 2;
            }
            else if (GetTile(x, y) == GetTile(x, y + 1))
            {
                Y = 0;
            }
            else Y = 2;

            return new Point(X * size, Y * size);

        }

        int GetTile(int x, int y)
        {
            if (x >= 0 && x < size.X)
                if (y >= 0 && y < size.Y)
                {
                    return map[x, y];
                }
            return -1;

        }

        bool SetTile(int x, int y, short val)
        {
            x = (x / 2) * 2;
            y = (y / 2) * 2;

            if (x >= 0 && x < size.X)
                if (y >= 0 && y < size.Y)
                {
                    map[x, y] = val;
                }
            if (x+1 >= 0 && x + 1 < size.X)
                if (y >= 0 && y < size.Y)
                {
                    map[x + 1, y] = val;
                }
            if (x >= 0 && x < size.X)
                if (y >= 0 && y + 1 < size.Y)
                {
                    map[x, y + 1] = val;
                }
            if (x+1 >= 0 && x < size.X)
                if (y >= 0 && y + 1 < size.Y)
                {
                    map[x+1, y + 1] = val;
                }
            return false;

        }

        public Point WorldToTile(Vector2 pos)
        {
            Point p;

            Vector2 localPos = pos - Position;

            p = new Point((int)(localPos.X / tileSize.X), (int)(localPos.Y / tileSize.Y));

            return p;
        }

    }
}
