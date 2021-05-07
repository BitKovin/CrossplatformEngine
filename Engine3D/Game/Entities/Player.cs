
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Engine.UI;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SkinnedModel;

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

        AnimationPlayer animationPlayer;

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
            }
            //Camera.Follow(this);

            collision.size = new Vector3(1,1,1);

            Position = new Vector3(-100);

            model = GameMain.content.Load<Model>("testModel2");

            SkinningData skinningData = model.Tag as SkinningData;
            animationPlayer = new AnimationPlayer(skinningData);

            Console.WriteLine(skinningData.AnimationClips.Keys.First());
            AnimationClip clip = skinningData.AnimationClips[skinningData.AnimationClips.Keys.First()];
            animationPlayer.StartClip(clip);

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

                Camera.position += Camera.rotation.GetRightVector() * input.X * speed*Time.deltaTime;
                Camera.position += Camera.rotation.GetForwardVector().XZ() * input.Y * speed * Time.deltaTime;


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

            animationPlayer.Update(GameMain.time.ElapsedGameTime,true,Matrix.Identity);

            

        }

        public override void LateUpdate()
        {
            //Camera.Follow(this);
        }

        public override void Draw()
        {
            Matrix[] bones = animationPlayer.GetSkinTransforms();

            // Render the skinned mesh.
            foreach (ModelMesh mesh in model.Meshes)
            {
                foreach (SkinnedEffect effect in mesh.Effects)
                {
                    effect.SetBoneTransforms(bones);

                    //effect.World = Matrix.CreateTranslation(Position);
                    effect.View = Camera.view;
                    effect.Projection = Camera.projection;

                    effect.EnableDefaultLighting();

                    effect.SpecularColor = new Vector3(0.25f);
                    effect.SpecularPower = 16;
                }

                mesh.Draw();
            }
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
