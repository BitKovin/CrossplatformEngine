using System;
using System.Collections.Generic;
using System.Text;

namespace Engine
{
    public class Level
    {
        public List<Entity> entities;

        public Level()
        {
            entities = new List<Entity>();
        }

        public virtual void Start()
        {

        }

        public virtual void Update()
        {

        }

    }
}
