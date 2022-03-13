using System;
using System.Collections.Generic;
using System.Text;
using Engine.Entities;
using Microsoft.Xna.Framework;
using Engine.Network;
using System.Threading;

namespace Game
{
    public class MyGame : Engine.GameMain
    {
        protected override void Initialize()
        {
            base.Initialize();

            Box box = new Box();
            box.Position = new Vector2(0, -200);
            curentLevel.entities.Add(box);

            TileMap tileMap = new TileMap();
            curentLevel.entities.Add(tileMap);

            box.Start();

            try
            {
                Server server = new Server();
            }
            catch (SystemException ex) { }
            Thread.Sleep(1000);
            GameClient client = new GameClient();
            client.Connect("127.0.0.1");

        }
    }
}
