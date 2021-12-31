using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Engine
{

    class Camera
    {

        public static float HtW;
        public static Vector2 position;
        public static Matrix Transform;
        public static Matrix UiMatrix;

        public static void Update()
        {
            HtW = 1; //GameMain.inst.Window.ClientBounds.Width / GameMain.inst.Window.ClientBounds.Height;

            float ScaleY = (float)GameMain.inst.Window.ClientBounds.Height / Constants.ResoultionY;
            var scale = Matrix.CreateScale(ScaleY * HtW, ScaleY, 1);

            var position = Matrix.CreateTranslation(
              -Camera.position.X,
              -Camera.position.Y,
              0);

            var offset = Matrix.CreateTranslation(
                GameMain.inst.ScreenWidth / ScaleY / 2,
                GameMain.inst.ScreenHeight / ScaleY / 2,
                0);


            Transform = position * offset * scale;
            UiMatrix = scale;

        }

        public static void Follow(Entity target)
        {
            position = target.Position;
        }
    }
}
