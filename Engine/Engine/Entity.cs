using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGame.Framework;

namespace Engine
{
    public class Entity
    {
        public Vector2 Position;
        public Sprite sprite;

        public Collision collision;

        public Entity()
        {
            collision = new Collision();
            sprite = new Sprite();
            sprite.texture = GameMain.content.Load<Texture2D>("test");
            sprite.Position = Position;
            sprite.Origin = new Vector2(-sprite.texture.Width / 2, -sprite.texture.Height / 2);
        }

        public virtual void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            sprite.Position = Position;
            sprite.Origin = new Vector2(sprite.texture.Width/2,sprite.texture.Height/2);

            sprite.Draw(gameTime, spriteBatch);


            Texture2D tex = new Texture2D(GameMain.inst.GraphicsDevice, 1, 1);
            tex.SetData(new Color[] { Color.White });

            Rectangle mainRectangle = new Rectangle();
            mainRectangle.Location = collision.position.ToPoint();
            mainRectangle.Size = collision.size;

            spriteBatch.Draw(tex, mainRectangle, new Color(255, 255, 255,100));

        }

        public virtual void Start()
        {

        }

        public virtual void Update()
        {

        }

        protected void UpdateCollision()
        {
            collision.position = (Position - new Vector2(sprite.Origin.X, sprite.Origin.Y)*2);
        }


    }
}
