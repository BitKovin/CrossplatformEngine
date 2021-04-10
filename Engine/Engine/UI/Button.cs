using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace Engine.UI
{
    public class Button: UiElement
    {

        Texture2D tex;

        Color baseColor = Color.White;
        Color hoveringColor = Color.Gray;

        public bool pressing;

        public Button():base()
        {
            tex = new Texture2D(GameMain.inst.GraphicsDevice, 1, 1);
            tex.SetData(new Color[] { Color.White });
        }

        public override void Update()
        {
            base.Update();

            if (GameMain.platform == Platform.Desktop)
            {
                pressing = Mouse.GetState().LeftButton == ButtonState.Pressed && hovering;
            }
            else if(GameMain.platform==Platform.Mobile)
            {
                pressing = hovering;
            }

        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            Rectangle mainRectangle = new Rectangle();
            mainRectangle.Location = new Point((int)position.X, (int)position.Y);
            mainRectangle.Size = new Point((int)size.X, (int)size.Y);
            Color color = hoveringColor;
            if (hovering)
            {
                color = hoveringColor;
            } 
            spriteBatch.Draw(tex, mainRectangle, hovering ? hoveringColor : baseColor);

            base.Draw(gameTime, spriteBatch);

        }

    }
}
