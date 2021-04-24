﻿
using System;
using System.Collections.Generic;
using System.Text;
using Engine.UI;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;


namespace Engine.Entities
{
    public class Player:Entity
    {

        Button buttonUp = new Button();
        Button buttonUpRight = new Button();
        Button buttonUpLeft = new Button();
        Button buttonDown = new Button();
        Button buttonLeft = new Button();
        Button buttonRight = new Button();
        Button buttonRotate = new Button();

        float speed = 2;

        public Player():base()
        {

            if (GameMain.platform == Platform.Mobile)
            {

                buttonLeft = new Button();
                buttonLeft.position = new Vector2(59, 601);
                buttonLeft.size = new Vector2(100, 100);
                UiElement.main.childs.Add(buttonLeft);

                buttonRight = new Button();
                buttonRight.position = new Vector2(112 + 50, 601);
                buttonRight.size = new Vector2(100, 100);
                UiElement.main.childs.Add(buttonRight);

                buttonRotate = new Button();
                buttonRotate.position = new Vector2(-200, 601);
                buttonRotate.size = new Vector2(100, 100);
                buttonRotate.originH = Origin.Right;
                UiElement.main.childs.Add(buttonRotate);

                Position = new Vector3(-100);

            }
            //Camera.Follow(this);

            collision.size = new Vector3(1,1,1);

            model = GameMain.content.Load<Model>("testModel");

            buttonRotate.onClicked += ButtonRotate_onClicked;

        }

        private void ButtonRotate_onClicked()
        {
            Jump();
        }

        public override void Start()
        {
            base.Start();
        }

        public override void Update()
        {
            base.Update();


            Vector2 input = new Vector2();

            if (buttonUp.pressing || Keyboard.GetState().IsKeyDown(Keys.W)|| buttonUpRight.pressing || buttonUpLeft.pressing)
                input += new Vector2(0, -100)*Time.deltaTime;

            if (buttonDown.pressing || Keyboard.GetState().IsKeyDown(Keys.S))
                input -= new Vector2(0, -100) * Time.deltaTime;

            if (buttonRight.pressing || Keyboard.GetState().IsKeyDown(Keys.D) || buttonUpRight.pressing)
                input += new Vector2(100, 0) * Time.deltaTime;

            if (buttonLeft.pressing || Keyboard.GetState().IsKeyDown(Keys.A) || buttonUpLeft.pressing)
                input -= new Vector2(100, 0) * Time.deltaTime;

            Camera.rotation += new Vector3(Input.MouseDelta.Y, -Input.MouseDelta.X, 0)/2f;
            Camera.rotation = new Vector3(Math.Clamp(Camera.rotation.X, -90, 90), Camera.rotation.Y, 0);
            if (input.Length()>0)
            {
                input.Normalize();

                Camera.position += new Vector3(input.X,0, input.Y) *speed*Time.deltaTime;


                for (int i = 0; i < 10; i++)
                {
                    //Position += new Vector2((input * speed * Time.deltaTime).X, 0)*0.1f;
                    UpdateCollision();
                    if (IsCollide())
                    {
                        //Position -= new Vector2((input * speed * Time.deltaTime).X, 0) * 0.1f;
                    }

                    //Position += new Vector2(0, (input * speed * Time.deltaTime).Y) * 0.1f;
                    UpdateCollision();
                    if (IsCollide())
                    {
                        //Position -= new Vector2(0, (input * speed * Time.deltaTime).Y) * 0.1f;
                    }
                    UpdateCollision();
                }
            }
            else
            {
                
            }


            if (Input.pressedKeys.Contains(Keys.W))
                Jump();

        }

        public override void LateUpdate()
        {
            //Camera.Follow(this);
        }

        void Jump()
        {

        }


        bool IsCollide()
        {
            foreach(Entity entity in GameMain.inst.curentLevel.entities)
            {
                if(entity!=this)
                if(Collision.MakeCollionTest(collision, entity.collision))
                    return true;
            }
            return false;
        }



    }
}