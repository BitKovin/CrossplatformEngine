using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Engine
{

    class Camera
    {

        static float HtW;

        public static Matrix Transform { get; private set; }

        public static void Update()
        {
            HtW = Game1.inst.Window.ClientBounds.Width / Game1.inst.Window.ClientBounds.Height;
        }

        public static void Follow(Entity target)
        {
            float ScaleY = (float)Game1.inst.Window.ClientBounds.Height / Constants.ResoultionY;
            var scale = Matrix.CreateScale(ScaleY * HtW, ScaleY, 1);

            var position = Matrix.CreateTranslation(
              -target.Position.X ,
              -target.Position.Y ,
              0);

            var offset = Matrix.CreateTranslation(
                Game1.inst.ScreenWidth / ScaleY / 2,
                Game1.inst.ScreenHeight / ScaleY /2,
                0);


            Transform = position * offset * scale;
        }
    }
}
