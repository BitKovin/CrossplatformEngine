
using System;
using System.Collections.Generic;
using System.Text;
using Engine.UI;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Engine.Physics;


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

        public int id;

        public Player():base()
        {

            //PhysicsBody = Physics.PhysicsManager.CreateBox(0, 0, 50, 30, this,0);
           // PhysicsBody.FreezeRotation();

            if (GameMain.platform == Platform.Mobile||true)
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

                Position = new Vector2(-100);

            }
            //Camera.Follow(this);

            collision.size = new Point(50, 30);

            buttonRotate.onClicked += ButtonRotate_onClicked;

        }

        private void ButtonRotate_onClicked()
        {
           
        }

        public override void Start()
        {
            base.Start();
        }

        public override void Update()
        {
            base.Update();

            if (Input.releasedKeys.Contains(Keys.B))
                Network.ClientSend.SendP2PPacket("pckt", new Network.Packet());

            Vector2 input = new Vector2();

            if (buttonUp.pressing || Keyboard.GetState().IsKeyDown(Keys.W)|| buttonUpRight.pressing || buttonUpLeft.pressing)
                Position += new Vector2(0, -100)*Time.deltaTime;

            if (buttonDown.pressing || Keyboard.GetState().IsKeyDown(Keys.S))
                Position -= new Vector2(0, -100) * Time.deltaTime;

            if (buttonRight.pressing || Keyboard.GetState().IsKeyDown(Keys.D) || buttonUpRight.pressing)
                Position += new Vector2(100, 0) * Time.deltaTime;

            if (buttonLeft.pressing || Keyboard.GetState().IsKeyDown(Keys.A) || buttonUpLeft.pressing)
                Position -= new Vector2(100, 0) * Time.deltaTime;

            
            if(input.Length()>0)
            {
                input.Normalize();
                PhysicsBody.SetLinearVelocity(new Box2DX.Common.Vec2((input * speed).X, PhysicsBody.GetLinearVelocity().Y));


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
                //PhysicsBody.SetLinearVelocity(new Box2DX.Common.Vec2(0, PhysicsBody.GetLinearVelocity().Y));
            }




        }

        public override void LateUpdate()
        {
            //Camera.Follow(this);
        }

        void Jump()
        {
            //PhysicsBody.ApplyImpulse(new Box2DX.Common.Vec2(0, -100), PhysicsBody.GetWorldCenter());
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
