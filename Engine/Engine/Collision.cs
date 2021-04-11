using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Engine
{
    public class Collision
    {

        public Vector2 position;
        public Point size;
        public Entity owner;

        const int Acuracy = 500;

        public static bool MakeCollionTest(Collision col1, Collision col2)
        {
            Point pos1 = new Point((int)(col1.position.X* Acuracy), (int)(col1.position.Y * Acuracy));
            Point pos2 = new Point((int)(col2.position.X * Acuracy), (int)(col2.position.Y * Acuracy));
            Rectangle Col1 = new Rectangle(new Point(pos1.X, pos1.Y), new Point(col1.size.X* Acuracy, col1.size.Y * Acuracy));
            Rectangle Col2 = new Rectangle(new Point(pos2.X, pos2.Y), new Point(col2.size.X * Acuracy, col2.size.Y * Acuracy));

            return Col1.Intersects(Col2);

        }
    }
}
