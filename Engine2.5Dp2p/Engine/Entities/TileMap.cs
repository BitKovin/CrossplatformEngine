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
        public Vector2 tileSize = new Vector2(13);
        List<Texture2D> tiles = new List<Texture2D>();

        public TileMap(int sx = 500, int sy = 500)
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

            int xStart = (int)Math.Clamp(WorldToTile(Camera.position).X - 60,0,size.X);
            int xEnd = (int)Math.Clamp(WorldToTile(Camera.position).X + 60, 0, size.X);

            int yStart = (int)Math.Clamp(WorldToTile(Camera.position).Y - 60, 0, size.X);
            int yEnd = (int)Math.Clamp(WorldToTile(Camera.position).Y + 60, 0, size.X);

            for (int x = xStart; x < xEnd; x++)
                for (int y = (int)Math.Clamp(WorldToTile(Camera.position).Y - 40, 0, size.Y); y < (int)Math.Clamp(WorldToTile(Camera.position).Y + 40, 0, size.Y); y++)
                {
                    DrawTile(x, y, spriteBatch);
                }
            spriteBatch.DrawString(GameMain.inst.font, Camera.position.ToString(), Camera.position - new Vector2(0,100), Color.Black);
            spriteBatch.DrawString(GameMain.inst.font, (WorldToTile(Camera.position)).ToString() , Camera.position, Color.Black);
        }

        void DrawTile(int x, int y, SpriteBatch spriteBatch)
        {

            if (map[x, y] == 0) return;

            Vector2 tileLocation = new Vector2(x * tileSize.X, y * tileSize.Y);
            //if (Vector2.Distance(Camera.position, tileLocation) > 500) return;
            Point spriteLocation = GetTileSprite(x, y);
            Rectangle rect = new Rectangle(new Point(Math.Clamp(spriteLocation.X,0,(int)(tileSize.X*4-1)), Math.Clamp(spriteLocation.Y, 0, (int)(tileSize.Y * 4 - 1))), new Point((int)tileSize.X, (int)tileSize.Y));
            spriteBatch.Draw(tiles[map[x, y]], Position + tileLocation, rect, Color.White, 0.0f, Vector2.Zero, 1, SpriteEffects.None, 1);
        }

        Point GetTileSprite(int x, int y, int size = 13)
        {
            //return Point.Zero;
            int X,Y;
            if (GetTile(x, y) == GetTile(x - 1, y) && GetTile(x, y) == GetTile(x + 1, y))
            {
                X = 1 + x%2;
            }
            else if (GetTile(x, y) == GetTile(x - 1, y))
            {
                X = 3;
            }
            else if (GetTile(x, y) == GetTile(x + 1, y))
            {
                X = 0;
            }
            else X = 3;

            if (GetTile(x, y) == GetTile(x, y - 1) && GetTile(x, y) == GetTile(x, y + 1))
            {
                Y = 1 + y%2;
            }
            else if (GetTile(x, y) == GetTile(x, y - 1))
            {
                Y = 3;
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

            //Vector2 localPos = pos*1.143f;

            p = new Point((int)(localPos.X / tileSize.X), (int)(localPos.Y / tileSize.Y));

            return p;
        }

    }
}
