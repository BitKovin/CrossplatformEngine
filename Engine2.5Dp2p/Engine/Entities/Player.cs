
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

        float speed = 2f;

        public int id;

        public Player(int id = 0):base()
        {
            this.id = id;
            //PhysicsBody = Physics.PhysicsManager.CreateBox(0, 0, 50, 30, this,0);
            //PhysicsBody.FreezeRotation();

            if (GameMain.platform == Platform.Mobile||id == Network.GameClient.instance.id)
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

            sprite.color = new Color(255, 255, 255, 100);

        }

        private void ButtonRotate_onClicked()
        {

        }

        public override void Start()
        {
            base.Start();
        }

        public override void NetworkUpdate()
        {
            if (id != Network.GameClient.instance.id) return;
            //base.NetworkUpdate();
            Network.ClientSend.SetPlayerPos(Position);
        }

        public override void Update()
        {
            base.Update();


            Vector2 input = new Vector2();
            if (id != Network.GameClient.instance.id) return;
            if (buttonUp.pressing || Keyboard.GetState().IsKeyDown(Keys.W)|| buttonUpRight.pressing || buttonUpLeft.pressing)
                Position += Camera.GetVectorFromAngle(0)*Time.deltaTime * speed;

            if (buttonDown.pressing || Keyboard.GetState().IsKeyDown(Keys.S))
                Position += Camera.GetVectorFromAngle(180) * Time.deltaTime * speed;

            if (buttonDown.pressing || Keyboard.GetState().IsKeyDown(Keys.A))
                Position += Camera.GetVectorFromAngle(-90) * Time.deltaTime * speed;

            if (buttonDown.pressing || Keyboard.GetState().IsKeyDown(Keys.D))
                Position += Camera.GetVectorFromAngle(90) * Time.deltaTime * speed;

            if (buttonRight.pressing || Keyboard.GetState().IsKeyDown(Keys.Right) || buttonUpRight.pressing)
                Camera.Rotation += 90 * Time.deltaTime;

            if (buttonLeft.pressing || Keyboard.GetState().IsKeyDown(Keys.Left) || buttonUpLeft.pressing)
                Camera.Rotation -= 90 * Time.deltaTime;



            //Camera.position = new Vector2(0,0);
            Camera.Follow(this);

            if (input.Length()>0)
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


            if (Input.pressedKeys.Contains(Keys.B))
                Network.ClientSend.SetPlayerPos(Position);
            //Network.ClientSend.SendP2PPacket("pckt", new Network.Packet());

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
