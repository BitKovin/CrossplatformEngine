using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework.Input;
using Engine;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input.Touch;

namespace Engine.UI
{

    public class UiElement
    {
        public List<UiElement> childs = new List<UiElement>();

        public static UiElement main;

        public bool hovering;
        public Collision col = new Collision();

        public Vector2 size;

        public Vector2 position;

        public UiElement()
        {
        }

        public virtual void Update()
        {

            if (GameMain.platform == Platform.Desktop)
            {

                col.size = new Point((int)size.X, (int)size.Y);
                col.position = new Point((int)position.X, (int)position.Y);
                Collision mouseCol = new Collision();
                mouseCol.size = new Point(2, 2);
                mouseCol.position = new Point((int)Input.MousePos.X, (int)Input.MousePos.Y);
                hovering = Collision.MakeCollionTest(col, mouseCol);
            }else if(GameMain.platform == Platform.Mobile)
            {
                hovering = false;
                var touchCol = TouchPanel.GetState();
                float ScaleY = (float)GameMain.inst.Window.ClientBounds.Height / Constants.ResoultionY;
                Vector2 pos;
                foreach (var touch in touchCol)
                {
                    pos = touch.Position / ScaleY;

                    col.size = new Point((int)size.X, (int)size.Y);
                    col.position = new Point((int)position.X, (int)position.Y);
                    Collision mouseCol = new Collision();
                    mouseCol.size = new Point(2, 2);
                    mouseCol.position = new Point((int)pos.X, (int)pos.Y);
                    if (Collision.MakeCollionTest(col, mouseCol))
                        hovering = true;

                }
            }

        }

        public virtual void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            foreach (UiElement element in childs)
                element.Draw(gameTime,spriteBatch);
        }
    }
}
