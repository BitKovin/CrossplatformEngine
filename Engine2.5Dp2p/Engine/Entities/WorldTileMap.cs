using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended.Tiled;
using MonoGame.Extended.Tiled.Renderers;

namespace Engine.Entities
{
    public class WorldTileMap
    {

        TiledMap tiledMap;
        TiledMapRenderer renderer;

        public WorldTileMap()
        {
            tiledMap = GameMain.content.Load<TiledMap>("samplemap");
            renderer = new TiledMapRenderer(GameMain.inst.GraphicsDevice, tiledMap);
        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            renderer.Draw(Camera.Transform);
        }

    }
}
