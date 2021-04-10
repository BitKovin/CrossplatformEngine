using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace Engine
{
    public static class Input
    {
        public static Vector2 MousePos;

        public static void Update()
        {
            float ScaleY = (float)GameMain.inst.Window.ClientBounds.Height / Constants.ResoultionY;
            MousePos = new Vector2(Mouse.GetState().X, Mouse.GetState().Y) / ScaleY;
        }

    }
}
