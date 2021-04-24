using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGame.Framework;

namespace Engine
{
    public class Entity: IDisposable
    {
        public Vector3 Position;

        public Model model;

        public Collision collision;

        public Entity()
        {
            collision = new Collision();

            //PhysicsBody = Physics.Physics.CreateBox(0, 0, 0, 0, this);

        }

        public virtual void Draw()
        {
            foreach (ModelMesh mesh in model.Meshes)
            {
                foreach (BasicEffect effect in mesh.Effects)
                {
                    effect.World = Camera.world;
                    effect.View = Camera.view;
                    effect.Projection = Camera.projection;
                }

                mesh.Draw();
            }

        }

        public virtual void Start()
        {

        }

        public virtual void Update()
        {

        }

        public virtual void LateUpdate()
        {

        }

        protected void UpdateCollision()
        {

        }

        public virtual void Destroy()
        {

        }

        public void Dispose()
        {
            // Suppress finalization.
            GC.SuppressFinalize(this);
        }
    }
}
