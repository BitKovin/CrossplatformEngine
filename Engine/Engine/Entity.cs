﻿using System;
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

        public Entity()
        {
            sprite = new Sprite();
            sprite.texture = Game1.content.Load<Texture2D>("test");
            sprite.Position = Position;
            sprite.Origin = new Vector2(-sprite.texture.Width / 2, -sprite.texture.Height / 2);
        }

        public virtual void Draw()
        {
            sprite.Position = Position;
            sprite.Origin = new Vector2(-sprite.texture.Width/2,-sprite.texture.Height/2);
        }

    }
}
