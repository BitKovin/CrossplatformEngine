#define isDesktop

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using Engine.UI;

namespace Engine
{

    public enum Platform
    {
        Desktop,
        Mobile
    }

    public class GameMain : Game
    {
        SpriteFont font;


        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        public static ContentManager content;
        static public GameMain inst;

        public Level curentLevel;

        public int ScreenHeight;
        public int ScreenWidth;

        public static Platform platform;

        public UiElement UiManger = new UiElement();

        public static GameTime time;

        public GameMain()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            inst = this;
            curentLevel = new Level();
            UiElement.main = UiManger;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();


            this.Window.AllowUserResizing = true;
            if (platform == Platform.Desktop)
            {
                _graphics.PreferredBackBufferWidth = 1280;  // set this value to the desired width of your window
                _graphics.PreferredBackBufferHeight = 720;   // set this value to the desired height of your window
            }
            this.IsFixedTimeStep = true;
            this.TargetElapsedTime = TimeSpan.FromSeconds(1d / 500d);
            _graphics.SynchronizeWithVerticalRetrace = false;

            //if (platform == Platform.Mobile)
                //_graphics.IsFullScreen = true;
            _graphics.ApplyChanges();
        }



        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            content = Content;
            // TODO: use this.Content to load your game content here

            font = Content.Load<SpriteFont>("Font"); // Use the name of your sprite font file here instead of 'Score'.
        }

        protected override void Update(GameTime gameTime)
        {
            //if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            // Exit();

            time = gameTime;

            this.Exiting += Game1_Exiting;

            Time.deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;

            ScreenHeight = GraphicsDevice.PresentationParameters.Bounds.Height;

            ScreenWidth = GraphicsDevice.PresentationParameters.Bounds.Width;

            Input.Update();

            curentLevel.Update();

            curentLevel.LateUpdate();


            Camera.Update();


            foreach (UiElement elem in UiElement.main.childs)
                elem.Update();
            // TODO: Add your update logic here


            base.Update(gameTime);
        }

        private void Game1_Exiting(object sender, System.EventArgs e)
        {
            Environment.Exit(0);
        }

        public void SetupFullViewport()
        {
            var vp = new Viewport();
            vp.X = vp.Y = 0;
            vp.Width = ScreenWidth;
            vp.Height = ScreenHeight;
            GraphicsDevice.Viewport = vp;
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);


            foreach(Entity ent in curentLevel.entities)
            {
                ent.Draw();
            }



            _spriteBatch.Begin(transformMatrix: Camera.UiMatrix);

            UiManger.Draw(gameTime,_spriteBatch);

            _spriteBatch.End();

            _spriteBatch.Begin();

            _spriteBatch.DrawString(font, $"FPS: {(1f/Time.deltaTime).ToString()}", new Vector2(100, 100), Color.Black);
            _spriteBatch.DrawString(font, $"Camera Position: {Camera.position.ToString()}", new Vector2(100, 200), Color.Black);
            _spriteBatch.DrawString(font, $"Camera Vector: {Camera.rotation.GetForwardVector()}", new Vector2(100, 300), Color.Black);


            _spriteBatch.End();

            //SetupFullViewport();
            base.Draw(gameTime);
        }

        public object GetView(System.Type type)
        {
            return this.Services.GetService(type);
        }

    }
}
