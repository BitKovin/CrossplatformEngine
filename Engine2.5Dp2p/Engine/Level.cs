using System;
using System.Collections.Generic;
using System.Text;

namespace Engine
{
    public class Level
    {
        public List<Entity> entities;

        public Engine.Entities.Player[] players = new Entities.Player[5];

        public Entities.WorldTileMap worldTileMap;

        public Level()
        {
            entities = new List<Entity>();
            //worldTileMap = new Entities.WorldTileMap();
        }

        public virtual void Start()
        {

        }

        public virtual void Update()
        {
            foreach (Entity entity in entities)
                entity.Update();
        }


        public virtual void LateUpdate()
        {
            foreach (Entity entity in entities)
                entity.LateUpdate();
        }


    }
}
