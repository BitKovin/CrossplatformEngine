using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Box2DX.Dynamics;
using Box2DX.Collision;
using Box2DX.Common;
using Engine;
using Microsoft.Xna.Framework;

namespace Engine.Physics
{
    public static class Physics
    {
        public static World world;
        public static Solver solver;

        public static Vector2 gravity { set { world.Gravity = new Vec2(value.X, value.Y); } }

        public static void Init()
        {
            AABB aabb = new AABB();
            aabb.LowerBound.Set(-100000, -10000);
            aabb.UpperBound.Set(100000,100000);
            world = new World(aabb, new Vec2(0,-9.8f*42f*0), false);
            solver = new Solver();
            world.SetContactListener(solver);
            solver.OnAdd += Solver_OnAdd;

        }

        private static void Solver_OnAdd(Entity body1, Entity body2, ContactPoint point)
        {
            /*
            if(body1!=null)
                if(body1.active)
                    body1.OnHit(body2);
            if(body2!=null)
                if (body2.active)
                    body2.OnHit(body1);
            */
        }

        public static void Test(Entity entity)
        {
            BodyDef bDef = new BodyDef();
            bDef.Position.Set(0, 0);
            bDef.Angle = 0;
            // Наш полигон который описывает вершины			
            PolygonDef pDef = new PolygonDef();
            pDef.Restitution =1;
            pDef.Friction = 1;
            pDef.Density = 1;
            pDef.SetAsBox(2, 2);
            // Создание самого тела
            Body body = world.CreateBody(bDef);
            body.CreateShape(pDef);
            body.SetMassFromShapes();
            body.SetUserData(entity);
        }

        public static void Update()
        {
            world.Step(Time.deltaTime, 100,300);

            for (Body list = world.GetBodyList(); list != null; list = list.GetNext())
            {
                if (list.GetUserData() != null)
                {
                    
                    Entity entity = list.GetUserData() as Entity;
                    Vector2 pos = new Vector2(list.GetPosition().X, list.GetPosition().Y);
                    //pos += entity.sprite.Origin*2;
                    entity.Position = pos;
                    entity.sprite.Rotation = list.GetAngle();

                }
            }

        }

        public static float GetRotation(this Body body)
        {
            return body.GetAngle() * -57.2958f;
        }

        public static Body CreateStaticBox(float x, float y, float sx, float sy)
        {
            BodyDef bDef = new BodyDef();
            bDef.Position.Set(x, y);
            bDef.Angle = 0;
            // Наш полигон который описывает вершины			
            PolygonDef pDef = new PolygonDef();

            pDef.SetAsBox(sx/2f, sy/2f);
            // Создание самого тела
            Body body = world.CreateBody(bDef);
            body.CreateShape(pDef);
            body.IsStatic();
            body.SetMassFromShapes();
            body.IsStatic();
            

            //body.SetUserData(entity);

            return body;
        }

        public static Body CreateBox(float x, float y, float sx, float sy,Entity entity)
        {
            BodyDef bDef = new BodyDef();
            bDef.Position.Set(x, y);
            bDef.Angle = 0;
            // Наш полигон который описывает вершины			
            PolygonDef pDef = new PolygonDef();
            pDef.Restitution = 0;
            pDef.Friction = 0.95f;
            pDef.Density = 7f;
            pDef.SetAsBox(sx/2f, sy/2f);
            // Создание самого тела
            Body body = world.CreateBody(bDef);
            body.CreateShape(pDef);

            body.SetMassFromShapes();
            body.SetUserData(entity);

            return body;
        }

        public static Body CreateBox(float x, float y, float sx, float sy, Entity entity,float f)
        {
            BodyDef bDef = new BodyDef();
            bDef.Position.Set(x, y);
            bDef.Angle = 0;
            // Наш полигон который описывает вершины			
            PolygonDef pDef = new PolygonDef();
            pDef.Restitution = 0;
            pDef.Friction = f;
            pDef.Density = 200f;
            pDef.SetAsBox(sx / 2f, sy / 2f);
            // Создание самого тела
            Body body = world.CreateBody(bDef);
            body.CreateShape(pDef);

            body.SetMassFromShapes();
            body.SetUserData(entity);


            return body;
        }

        public static void Clear()
        {
            for (Body list = world.GetBodyList(); list != null; list = list.GetNext())
            {
                world.DestroyBody(list);
                
            }
        }

        public static void FreezeRotation(this Body body)
        {
            MassData massData = new MassData();
            massData.Mass = body.GetMass();
            massData.I = 0;
            body.SetMass(massData);
        }

        public static Shape Raycast(Vec2 start, Vec2 end, out float lambda, out Vec2 normal, bool solidShapes, object userData)
        {
            Segment segment = new Segment();
            segment.P1 = start;
            segment.P2 = end;
            return world.RaycastOne(segment, out lambda,out normal, solidShapes, userData);
        }

    }
}
