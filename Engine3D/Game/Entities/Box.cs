using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;
using System;
using System.Collections.Generic;
using System.Text;

namespace Engine.Entities
{
    public class Box:Entity
    {

        public Box():base()
        {

        }


        public override void Start()
        {
            base.Start();

        }

        public override void Update()
        {
            base.Update();

            UpdateCollision();
               

        }

    }
}
