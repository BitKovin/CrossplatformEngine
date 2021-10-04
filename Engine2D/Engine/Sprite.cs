using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Engine
{
    public class Sprite
    {

        public Vector2 Position;

        public Vector2 Origin;

        public Texture2D texture;

        public float Rotation;

        public Vector2 Scale = new Vector2(1,1);

        public float depth;

        public SpriteEffects effects;


        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, Position, null, Color.White, Rotation, Origin, Scale, effects, Math.Clamp((depth + 50000f) / 100000f, 0,1));
        }

        public void CreateTexture(int x, int y)
        {
            texture = new Texture2D(GameMain.inst.GraphicsDevice, x, y);
            Color[] data = new Color[x * y];
            for(int i = 0; i<x*y; i++)
            {
                data[i] = Color.White;
            }
            texture.SetData(data);
        }

        public void SetPixel(int x, int y, Color color)
        {
            if (x < 0 || x >= texture.Width || y < 0 || y >= texture.Height) return;
            Color[] data = new Color[texture.Height*texture.Width];
            texture.GetData<Color>(data);
            data[x + texture.Width * y] = color;
            texture.SetData<Color>(data);
        }

    }
}
