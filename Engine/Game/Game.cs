using System;
using System.Collections.Generic;
using System.Text;
using Engine.Entities;
using Microsoft.Xna.Framework;

namespace Game
{
    public class Game : Engine.GameMain
    {
        protected override void Initialize()
        {
            base.Initialize();


            curentLevel.entities.Add(new Player());

            Box box = new Box();
            box.Position = new Vector2(0, 200);
            curentLevel.entities.Add(box);

            box.Start();
        }
    }
}
