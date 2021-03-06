using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Engine
{
    public static class MathHelper
    {
        public static Vector3 GetForwardVector(this Vector3 rot)
        {
            double X = Math.Sin(rot.Y / 180d * Math.PI);
            double Y = -Math.Tan(rot.X / 180d * Math.PI);
            double Z = Math.Cos(rot.Y / 180d * Math.PI);
            //Console.WriteLine(Z);
            return new Vector3((float)X, (float)Y, (float)Z);
        }

        public static Vector3 XZ(this Vector3 vector)
        {
            return new Vector3(vector.X, 0, vector.Z);
        }

            public static Vector3 GetRightVector(this Vector3 rot)
        {
            double X = Math.Sin((rot.Y+90) / 180d * Math.PI);
            double Y = 0;//-Math.Tan(rot.X / 180d * Math.PI);
            double Z = Math.Cos((rot.Y + 90) / 180d * Math.PI);
            //Console.WriteLine(Z);
            Vector3 rotation = new Vector3((float)X, (float)Y, (float)Z);
            rotation.Normalize();
            return rotation;
        }

    }
}
