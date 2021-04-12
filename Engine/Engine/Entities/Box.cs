using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Engine.Entities
{
    public class Box:Entity
    {



        public Box():base()
        {
            sprite = new Sprite();
            sprite.texture = GameMain.content.Load<Texture2D>("block");
            sprite.Position = Position;
            sprite.Origin = new Vector2(-sprite.texture.Width / 2, -sprite.texture.Height / 2);

            collision.size = new Point(100, 100);

            PhysicsBody = Physics.Physics.CreateStaticBox(100, 100, 100, 100);

        }

        public override void Update()
        {
            base.Update();

            UpdateCollision();

        }

    }
}
