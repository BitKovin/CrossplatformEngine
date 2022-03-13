#define isDesktop

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using Engine.UI;
using System.Threading;
using System.Diagnostics;

namespace Engine
{

    public enum Platform
    {
        Desktop,
        Mobile
    }

    public class GameMain : Microsoft.Xna.Framework.Game
    {
        public SpriteFont font;


        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        public static ContentManager content;
        static public GameMain inst;

        public Level curentLevel;

        public int ScreenHeight;
        public int ScreenWidth;

        public static Platform platform;

        public UiElement UiManger = new UiElement();


        Stopwatch sw = new Stopwatch();
        const int TPS = 60;

        float UpdateDelay = 1f/(float)TPS;

        int HorizontalResoultion = 100;
        float FovHalf = 45;

        public GameMain()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            content = Content;
            IsMouseVisible = true;
            inst = this;
            UiElement.main = UiManger;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();

            Physics.PhysicsManager.Init();

            this.Window.AllowUserResizing = true;
            if (platform == Platform.Desktop)
            {
                _graphics.PreferredBackBufferWidth = 1280;  // set this value to the desired width of your window
                _graphics.PreferredBackBufferHeight = 720;   // set this value to the desired height of your window
            }
            this.IsFixedTimeStep = true;
            this.TargetElapsedTime = TimeSpan.FromSeconds(1d / 200d);
            _graphics.SynchronizeWithVerticalRetrace = false;

            //if (platform == Platform.Mobile)
                //_graphics.IsFullScreen = true;
            _graphics.ApplyChanges();

            curentLevel = new Level();

            //new Thread(BeginUpdateNetwork).Start();


            _texture = new Texture2D(GraphicsDevice, 1, 1);
            _texture.SetData(new Color[] { Color.White });

        }


        void BeginUpdateNetwork()
        {
            while (true)
            {
                sw.Restart();
                foreach (Entity ent in curentLevel.entities)
                    ent.NetworkUpdate();
                sw.Stop();
                float FrameTime = 1000 / TPS;
                Thread.Sleep(Math.Clamp((int)(FrameTime - (float)sw.ElapsedMilliseconds), 0, 10000));
            }
        }
        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            // TODO: use this.Content to load your game content here

            font = Content.Load<SpriteFont>("Font"); // Use the name of your sprite font file here instead of 'Score'.
        }

        protected override void Update(GameTime gameTime)
        {
            //if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            // Exit();

            Network.ThreadManager.UpdateMain();

            this.Exiting += Game1_Exiting;

            Time.deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;

            ScreenHeight = GraphicsDevice.PresentationParameters.Bounds.Height;

            ScreenWidth = GraphicsDevice.PresentationParameters.Bounds.Width;

            Input.Update();

            curentLevel.Update();

            Physics.PhysicsManager.Update();

            curentLevel.LateUpdate();


            Camera.Update();


            foreach (UiElement elem in UiElement.main.childs)
                elem.Update();
            // TODO: Add your update logic here

            UpdateDelay -= Time.deltaTime;
            if(UpdateDelay<=0)
            {
                foreach (Entity ent in curentLevel.entities)
                    ent.NetworkUpdate();

                UpdateDelay = 1f / TPS;
            }

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

            _spriteBatch.Begin(transformMatrix: Camera.Transform, sortMode: SpriteSortMode.BackToFront);

            //GameMain.inst.curentLevel.worldTileMap.Draw(gameTime, _spriteBatch);

            Draw3D(_spriteBatch, GraphicsDevice);

            _spriteBatch.End();


            _spriteBatch.Begin(transformMatrix: Camera.UiMatrix);

            UiManger.Draw(gameTime,_spriteBatch);

            _spriteBatch.End();

            _spriteBatch.Begin();

            _spriteBatch.DrawString(font, $"FPS: {(1/gameTime.ElapsedGameTime.TotalSeconds).ToString()}", new Vector2(100, 50), Color.Black);


            Physics.RayHit rayhit = Camera.RaycastFromCamera(Camera.Rotation);

            if (Network.GameClient.instance != null)
                _spriteBatch.DrawString(font, $"Distance: {rayhit.distance}", new Vector2(100, 100), Color.Black);

            _spriteBatch.End();

            //SetupFullViewport();
            base.Draw(gameTime);
        }

        public object GetView(System.Type type)
        {
            return this.Services.GetService(type);
        }

        void Draw3D(SpriteBatch spriteBatch,GraphicsDevice graphics)
        {
            /*
            float fovStep = FovHalf * 2 / Camera.GetHorizontalResolution() * 3;
            for(float x = -FovHalf; x<FovHalf; x += fovStep)
            {
                
                float LineWidth = Camera.GetHorizontalResolution()/(FovHalf/fovStep);
                
                float ScreenPosX = x/(FovHalf)* Camera.GetHorizontalResolution();
                DrawVerticalLine(spriteBatch, graphics,(int)ScreenPosX,100, (int)LineWidth);
            }
            */
            int LineWidth = 3;
            int HR = (int)Camera.GetHorizontalResolution();
            for (int x = -HR/2;x<HR/2;x+=LineWidth)
            {
                float angle = (float)x / (float)HR * (float)FovHalf;

                Physics.RayHit rayhit = Camera.RaycastFromCamera(Camera.Rotation+angle);
                int Brightness = (int)(255 - rayhit.distance*100);
                DrawVerticalLine(spriteBatch, graphics, x, (int)((500 + (int)(100 * (MathF.Sin(rayhit.hitPoint.X)))) * (1/rayhit.distance)) , (int)LineWidth,new Color(Brightness, Brightness, Brightness));
            }
            

        }

        static Texture2D _texture;

        void DrawVerticalLine(SpriteBatch spriteBatch, GraphicsDevice graphics,int PosX,int Height,int Width, Color color)
        {
            spriteBatch.Draw(_texture, new Rectangle(PosX, -Height/2, Width, Height), color);
        }

    }
}
