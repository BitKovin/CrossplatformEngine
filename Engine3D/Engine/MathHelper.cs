using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Engine
{
    public static class MathHelper
    {
        public static Vector3 GetForwardRotation(Vector3 rot)
        {
            double Y = -Math.Tan(rot.X / 180d * Math.PI);
            double X = Math.Sin(rot.Y / 180d * Math.PI);
            double Z = Math.Cos(rot.Y / 180d * Math.PI);
            //Console.WriteLine(Z);
            return new Vector3((float)X, (float)Y, (float)Z);
        }
    }
}
