using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Engine
{
    class Collision
    {

        public Point position;
        public Point size;
        public Entity owner;
        public static bool MakeCollionTest(Collision col1, Collision col2)
        {

            Rectangle Col1 = new Rectangle(new Point(col1.position.X - col1.size.X, col1.position.Y - col1.size.Y), col1.size);
            Rectangle Col2 = new Rectangle(new Point(col2.position.X - col2.size.X, col2.position.Y - col2.size.Y), col2.size);

            return Col1.Intersects(Col2);

        }
    }
}
