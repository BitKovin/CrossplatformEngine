using System;
using System.Collections.Generic;
using System.Text;
using Engine.UI;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Engine.Entities
{
    public class Player:Entity
    {

        Button buttonUp = new Button();
        Button buttonDown = new Button();
        Button buttonLeft = new Button();
        Button buttonRight = new Button();

        float speed = 100;

        public Player():base()
        {
            if (GameMain.platform == Platform.Mobile)
            {
                buttonUp = new Button();
                buttonUp.position = new Vector2(61, 600);
                buttonUp.size = new Vector2(50, 50);
                UiElement.main.childs.Add(buttonUp);

                buttonDown = new Button();
                buttonDown.position = new Vector2(61, 651);
                buttonDown.size = new Vector2(50, 50);
                UiElement.main.childs.Add(buttonDown);

                buttonLeft = new Button();
                buttonLeft.position = new Vector2(10, 651);
                buttonLeft.size = new Vector2(50, 50);
                UiElement.main.childs.Add(buttonLeft);

                buttonRight = new Button();
                buttonRight.position = new Vector2(112, 651);
                buttonRight.size = new Vector2(50, 50);
                UiElement.main.childs.Add(buttonRight);
            }
            Camera.Follow(this);
        }

        public override void Start()
        {
            base.Start();
        }

        public override void Update()
        {
            base.Update();

            Vector2 input = new Vector2();

            if (buttonUp.pressing||Keyboard.GetState().IsKeyDown(Keys.W))
                input += new Vector2(0, -100)*Time.deltaTime;

            if (buttonDown.pressing || Keyboard.GetState().IsKeyDown(Keys.S))
                input -= new Vector2(0, -100) * Time.deltaTime;

            if (buttonRight.pressing || Keyboard.GetState().IsKeyDown(Keys.D))
                input += new Vector2(100, 0) * Time.deltaTime;

            if (buttonLeft.pressing || Keyboard.GetState().IsKeyDown(Keys.A))
                input -= new Vector2(100, 0) * Time.deltaTime;

            if(input.Length()>0)
            {
                input.Normalize();
                Position += input * speed * Time.deltaTime;
            }
        }

    }
}
