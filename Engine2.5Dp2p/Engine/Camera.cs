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
        public static float Rotation;
        public static Matrix Transform;
        public static Matrix UiMatrix;

        public static void Update()
        {
            HtW = 1; //GameMain.inst.Window.ClientBounds.Width / GameMain.inst.Window.ClientBounds.Height;

            float ScaleY = (float)GameMain.inst.Window.ClientBounds.Height / Constants.ResoultionY;
            var scale = Matrix.CreateScale(ScaleY * HtW, ScaleY, 1);

            var offset = Matrix.CreateTranslation(
                GameMain.inst.ScreenWidth / ScaleY / 2,
                GameMain.inst.ScreenHeight / ScaleY / 2,
                0);


            Transform = offset * scale;
            UiMatrix = scale;

        }

        

        public static Physics.RayHit RaycastFromCamera(float angle)
        {

            angle *= MathF.PI / 180f;

            Physics.RayHit hit = new Physics.RayHit();

            Box2DX.Common.Vec2 start = new Box2DX.Common.Vec2(position.X, position.Y);
            Box2DX.Common.Vec2 dir = new Box2DX.Common.Vec2(MathF.Cos(angle), MathF.Sin(angle));

            float lambda;
            Box2DX.Common.Vec2 normal;

            Box2DX.Collision.Segment segment = new Box2DX.Collision.Segment();
            segment.P1 = start;
            segment.P2 = start + dir * 100;

            bool hited = Physics.PhysicsManager.world.RaycastOne(segment, out lambda, out normal, true, null)!=null;

            //Console.WriteLine("dir " + dir.X.ToString() + "    " + dir.Y.ToString());
            //Console.WriteLine("normal " + normal.X.ToString()+"    " + normal.Y.ToString());
            //Console.WriteLine("lambda " + lambda.ToString());

            Box2DX.Common.Vec2 hitPoint = segment.P1 + lambda * segment.P2;
            float distance = Box2DX.Common.Vec2.Distance(segment.P1, hitPoint);

            hit.lambda = lambda;
            hit.nomal = new Vector2(normal.X,normal.Y);
            hit.hitPoint = new Vector2(hitPoint.X, hitPoint.Y);
            hit.distance = distance;

            return hit;
        }

        public static float GetHorizontalResolution()
        {
            return Constants.ResoultionY * GameMain.inst.Window.ClientBounds.Width / GameMain.inst.Window.ClientBounds.Height;
        }

        public static Vector2 GetVectorFromAngle(float angle)
        {
            angle += Rotation;
            angle *= MathF.PI / 180f;
            return new Vector2(MathF.Cos(angle), MathF.Sin(angle));
        }

        public static void Follow(Entity target)
        {
            position = target.Position;
        }
    }
}
