using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Engine.Entities
{
    public class Box:Entity
    {

        public Box():base()
        {
            sprite = new Sprite();
            //sprite.texture = GameMain.content.Load<Texture2D>("block");
            sprite.CreateTexture(100, 100);
            sprite.Position = Position;
            sprite.Origin = new Vector2(-sprite.texture.Width / 2, -sprite.texture.Height / 2);

            collision.size = new Point(100, 100);

        }

        void DrawUpdate()
        {
            sprite.CreateTexture(100,100);

            if (GameMain.inst.curentLevel.players.Length >= Network.GameClient.instance.id)
            if (GameMain.inst.curentLevel.players[Network.GameClient.instance.id] != null)
            for (int x = 0; x < sprite.texture.Width; x++)
            {
                int y = (int)(Math.Cos((x - (int)GameMain.inst.curentLevel.players[Network.GameClient.instance.id].Position.X) / 20f) * 20f) + 30 + (int)GameMain.inst.curentLevel.players[Network.GameClient.instance.id].Position.Y;
                sprite.SetPixel(x, y, Color.Red);
            }
        }


        public override void Start()
        {
            base.Start();

            PhysicsBody = Physics.PhysicsManager.CreateStaticBox(Position.X, Position.Y, 100, 100, this);
        }

        public override void Update()
        {
            base.Update();

            UpdateCollision();

            if (Input.pressedKeys.Contains(Microsoft.Xna.Framework.Input.Keys.H))
                DrawUpdate();

        }

    }
}
