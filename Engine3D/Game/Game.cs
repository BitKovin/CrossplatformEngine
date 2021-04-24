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
            box.Position = new Vector3(0, 200,0);
            //curentLevel.entities.Add(box);

            box.Start();
        }
    }
}
