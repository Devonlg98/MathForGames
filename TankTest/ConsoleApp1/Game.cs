using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Raylib.Raylib;
using Raylib;

namespace ConsoleApp1
{
    class Game
    {
        SceneObject tankObject1 = new SceneObject();
        SceneObject turretObject1 = new SceneObject();
        SpriteObject tankSprite1 = new SpriteObject();
        SpriteObject turretSprite1 = new SpriteObject();


        SceneObject tankHitBoxBL1 = new SceneObject();
        SceneObject tankHitBoxBR1 = new SceneObject();
        SceneObject tankHitBoxTL1 = new SceneObject();
        SceneObject tankHitBoxTR1 = new SceneObject();

        SceneObject tankBulletObject1 = new SceneObject();
        SpriteObject tankBulletSprite1 = new SpriteObject();

        SceneObject tankBulletHitBoxBL1 = new SceneObject();
        SceneObject tankBulletHitBoxBR1 = new SceneObject();
        SceneObject tankBulletHitBoxTL1 = new SceneObject();
        SceneObject tankBulletHitBoxTR1 = new SceneObject();


        SceneObject tankObject2 = new SceneObject();
        SceneObject turretObject2 = new SceneObject();
        SpriteObject tankSprite2 = new SpriteObject();
        SpriteObject turretSprite2 = new SpriteObject();

        SceneObject tankHitBoxBL2 = new SceneObject();
        SceneObject tankHitBoxBR2 = new SceneObject();
        SceneObject tankHitBoxTL2 = new SceneObject();
        SceneObject tankHitBoxTR2 = new SceneObject();



        MyShape tank1 = new MyShape();
        MyShape tankBullet1 = new MyShape();

        MyShape tank2 = new MyShape();
        MyShape tankBullet2 = new MyShape();


        Timer gameTime = new Timer();
        private float timer = 0;
        private int fps = 1;
        private int frames;
        private float deltaTime;
        private float bulletSpeed = 250;
        public float bulletCoolDown1 = 0;
        public bool tankBulletFired1 = false;

        public void Init()
        {
            //P1

            tankSprite1.Load("Resources/topdowntanks/PNG/Tanks/tankGreen_outline.png");
            // sprite is facing the wrong way... fix that here
            tankSprite1.SetRotate(-90 * (float)(Math.PI / 180.0f));
            // sets an offset for the base, so it rotates around the centre
            tankSprite1.SetPosition(-tankSprite1.Width / 2.0f, tankSprite1.Height /2.0f);
            
            turretSprite1.Load("Resources/topdowntanks/PNG/Tanks/barrelGreen.png");
            turretSprite1.SetRotate(-90 * (float)(Math.PI / 180.0f));
            // set the turret offset from the tank base
            turretSprite1.SetPosition(0, turretSprite1.Width / 2.0f);
            
            // set up the scene object hierarchy - parent the turret to the base,
            // then the base to the tank sceneObject
            turretObject1.AddChild(turretSprite1);
            tankObject1.AddChild(tankSprite1);
            tankObject1.AddChild(turretObject1);
            tankObject1.AddChild(tankHitBoxTL1);
            tankObject1.AddChild(tankHitBoxTR1);
            tankObject1.AddChild(tankHitBoxBR1);
            tankObject1.AddChild(tankHitBoxBL1);

            tankObject1.SetPosition((GetScreenWidth() / 2.0f) - 100f, GetScreenHeight() / 2.0f);

            tankHitBoxTL1.SetPosition((-tankSprite1.Height / 2.0f), -tankSprite1.Width / 2.0f);    //(0,0)
            tankHitBoxTR1.SetPosition((-tankSprite1.Height / 2.0f), tankSprite1.Width / 2.0f);     //(1,0)
            tankHitBoxBR1.SetPosition((tankSprite1.Height / 2.0f), tankSprite1.Width / 2.0f);      //(1,1)
            tankHitBoxBL1.SetPosition((tankSprite1.Height / 2.0f), -tankSprite1.Width / 2.0f);     //(0,1)

            tank1.MyTankPoints.Add(new Vector2(tankHitBoxTL1.Position.x, tankHitBoxTL1.Position.y));
            tank1.MyTankPoints.Add(new Vector2(tankHitBoxTR1.Position.x, tankHitBoxTR1.Position.y));
            tank1.MyTankPoints.Add(new Vector2(tankHitBoxBR1.Position.x, tankHitBoxBR1.Position.y));
            tank1.MyTankPoints.Add(new Vector2(tankHitBoxBL1.Position.x, tankHitBoxBL1.Position.y));

            //P1 Bullet
            tankBulletSprite1.Load("Resources/topdowntanks/PNG/Bullets/bulletGreen.png");
            tankBulletSprite1.SetRotate(-90 * (float)(Math.PI / 180.0f));
            tankBulletSprite1.SetPosition(-tankBulletSprite1.Width / 2.0f, tankBulletSprite1.Height / 2.0f);
            tankBulletObject1.AddChild(tankBulletSprite1);
            tankBulletObject1.AddChild(tankBulletHitBoxTL1);
            tankBulletObject1.AddChild(tankBulletHitBoxTR1);
            tankBulletObject1.AddChild(tankBulletHitBoxBR1);
            tankBulletObject1.AddChild(tankBulletHitBoxBL1);

            tankBulletObject1.SetPosition((GetScreenWidth() / 2.0f) - 100f, GetScreenHeight() / 2.0f);

            tankBulletHitBoxTL1.SetPosition((-tankBulletSprite1.Height / 2.0f), -tankBulletSprite1.Width / 2.0f);    //(0,0)
            tankBulletHitBoxTR1.SetPosition((-tankBulletSprite1.Height / 2.0f), tankBulletSprite1.Width / 2.0f);     //(1,0)
            tankBulletHitBoxBR1.SetPosition((tankBulletSprite1.Height / 2.0f),  tankBulletSprite1.Width / 2.0f);      //(1,1)
            tankBulletHitBoxBL1.SetPosition((tankBulletSprite1.Height / 2.0f), -tankBulletSprite1.Width / 2.0f);     //(0,1)

            tankBullet1.MyTankPoints.Add(new Vector2(tankBulletHitBoxTL1.Position.x, tankBulletHitBoxTL1.Position.y));
            tankBullet1.MyTankPoints.Add(new Vector2(tankBulletHitBoxTR1.Position.x, tankBulletHitBoxTR1.Position.y));
            tankBullet1.MyTankPoints.Add(new Vector2(tankBulletHitBoxBR1.Position.x, tankBulletHitBoxBR1.Position.y));
            tankBullet1.MyTankPoints.Add(new Vector2(tankBulletHitBoxBL1.Position.x, tankBulletHitBoxBL1.Position.y));

            //P2

            tankSprite2.Load("Resources/topdowntanks/PNG/Tanks/tankBlue_outline.png");
            tankSprite2.SetRotate(-90 * (float)(Math.PI / 180.0f));
            tankSprite2.SetPosition(-tankSprite2.Width / 2.0f, tankSprite2.Height /2.0f);
            turretSprite2.Load("Resources/topdowntanks/PNG/Tanks/barrelBlue.png");
            turretSprite2.SetRotate(-90 * (float)(Math.PI / 180.0f));
            turretSprite2.SetPosition(0, turretSprite2.Width / 2.0f);
            turretObject2.AddChild(turretSprite2);
            tankObject2.AddChild(tankSprite2);
            tankObject2.AddChild(turretObject2);
            tankObject2.AddChild(tankHitBoxTL2);
            tankObject2.AddChild(tankHitBoxTR2);
            tankObject2.AddChild(tankHitBoxBR2);
            tankObject2.AddChild(tankHitBoxBL2);
            tankObject2.SetPosition((GetScreenWidth() / 2.0f)+100f, GetScreenHeight() / 2.0f);

            tankHitBoxTL2.SetPosition((-tankSprite2.Height / 2.0f), -tankSprite2.Width / 2.0f);    //(0,0)
            tankHitBoxTR2.SetPosition((-tankSprite2.Height / 2.0f), tankSprite2.Width / 2.0f);     //(1,0)
            tankHitBoxBR2.SetPosition((tankSprite2.Height / 2.0f), tankSprite2.Width / 2.0f);      //(1,1)
            tankHitBoxBL2.SetPosition((tankSprite2.Height / 2.0f), -tankSprite2.Width / 2.0f);     //(0,1)

            tank2.MyTankPoints.Add(new Vector2(tankHitBoxTL2.Position.x, tankHitBoxTL2.Position.y));
            tank2.MyTankPoints.Add(new Vector2(tankHitBoxTR2.Position.x, tankHitBoxTR2.Position.y));
            tank2.MyTankPoints.Add(new Vector2(tankHitBoxBR2.Position.x, tankHitBoxBR2.Position.y));
            tank2.MyTankPoints.Add(new Vector2(tankHitBoxBL2.Position.x, tankHitBoxBL2.Position.y));


        }
        public void Shutdown()
        {

        }
        public void Update()
        {
            tankBulletObject1.Set(turretObject1);

            tank1.MyTankPoints[0] = new Vector2(tankHitBoxTL1.Position.x , tankHitBoxTL1.Position.y );
            tank1.MyTankPoints[1] = new Vector2(tankHitBoxTR1.Position.x , tankHitBoxTR1.Position.y );
            tank1.MyTankPoints[2] = new Vector2(tankHitBoxBR1.Position.x , tankHitBoxBR1.Position.y );
            tank1.MyTankPoints[3] = new Vector2(tankHitBoxBL1.Position.x , tankHitBoxBL1.Position.y );

            tankBullet1.MyTankPoints[0] = new Vector2(tankBulletHitBoxTL1.Position.x, tankBulletHitBoxTL1.Position.y);
            tankBullet1.MyTankPoints[1] = new Vector2(tankBulletHitBoxTR1.Position.x, tankBulletHitBoxTR1.Position.y);
            tankBullet1.MyTankPoints[2] = new Vector2(tankBulletHitBoxBR1.Position.x, tankBulletHitBoxBR1.Position.y);
            tankBullet1.MyTankPoints[3] = new Vector2(tankBulletHitBoxBL1.Position.x, tankBulletHitBoxBL1.Position.y);

            tank2.MyTankPoints[0] = new Vector2(tankHitBoxTL2.Position.x, tankHitBoxTL2.Position.y);
            tank2.MyTankPoints[1] = new Vector2(tankHitBoxTR2.Position.x, tankHitBoxTR2.Position.y);
            tank2.MyTankPoints[2] = new Vector2(tankHitBoxBR2.Position.x, tankHitBoxBR2.Position.y);
            tank2.MyTankPoints[3] = new Vector2(tankHitBoxBL2.Position.x, tankHitBoxBL2.Position.y);



            deltaTime = gameTime.GetDeltaTime();
            timer += deltaTime;
            if (timer >= 1)
            {
                fps = frames;
                frames = 0;
                timer -= 1;
            }
            frames++;

            if (IsKeyPressed(KeyboardKey.KEY_SPACE))
            {
                tankBulletFired1 = true;
                tankBulletObject1.Rotate(-deltaTime);

                bulletCoolDown1 -= deltaTime;
                do
                {
                    Vector3 facing = new Vector3(
                    tankObject1.LocalTransform.m1,
                    tankObject1.LocalTransform.m2, 1) * deltaTime * 100;
                    tankObject1.Translate(facing.x, facing.y);
                } while (bulletCoolDown1 > deltaTime);


            }
            if(deltaTime > bulletCoolDown1)
            {
                tankBulletFired1 = false;
            }
            //Player 1 movement
            if (IsKeyDown(KeyboardKey.KEY_A))
            {
                tankObject1.Rotate(-deltaTime);
                
            }
            if (IsKeyDown(KeyboardKey.KEY_D))
            {
                tankObject1.Rotate(deltaTime);
            }
            if (IsKeyDown(KeyboardKey.KEY_W))
            {
                Vector3 facing = new Vector3(
                tankObject1.LocalTransform.m1,
                tankObject1.LocalTransform.m2, 1) * deltaTime * 100;
                tankObject1.Translate(facing.x, facing.y);
            }
            if (IsKeyDown(KeyboardKey.KEY_S))
            {
                Vector3 facing = new Vector3(
               tankObject1.LocalTransform.m1,
               tankObject1.LocalTransform.m2, 1) * deltaTime * -100;
                tankObject1.Translate(facing.x, facing.y);
            }
            tankObject1.Update(deltaTime);

            if (IsKeyDown(KeyboardKey.KEY_Q))
            {
                turretObject1.Rotate(-deltaTime);
            }
            if (IsKeyDown(KeyboardKey.KEY_E))
            {
                turretObject1.Rotate(deltaTime);
            }

            //Player 2 movement

            if (IsKeyDown(KeyboardKey.KEY_KP_4))
            {
                tankObject2.Rotate(-deltaTime);
            }
            if (IsKeyDown(KeyboardKey.KEY_KP_6))
            {
                tankObject2.Rotate(deltaTime);
            }
            if (IsKeyDown(KeyboardKey.KEY_KP_8))
            {
                Vector3 facing = new Vector3(
                tankObject2.LocalTransform.m1,
                tankObject2.LocalTransform.m2, 1) * deltaTime * 100;
                tankObject2.Translate(facing.x, facing.y);
            }
            if (IsKeyDown(KeyboardKey.KEY_KP_5))
            {
                Vector3 facing = new Vector3(
               tankObject2.LocalTransform.m1,
               tankObject2.LocalTransform.m2, 1) * deltaTime * -100;
                tankObject2.Translate(facing.x, facing.y);
            }
            tankObject2.Update(deltaTime);

            if (IsKeyDown(KeyboardKey.KEY_KP_7))
            {
                turretObject2.Rotate(-deltaTime);
            }
            if (IsKeyDown(KeyboardKey.KEY_KP_9))
            {
                turretObject2.Rotate(deltaTime);
            }


        }


    public void Draw()
        {
            BeginDrawing();
            ClearBackground(Color.WHITE);
            DrawText(fps.ToString(), 10, 10, 12, Color.RED);
            tankObject1.Draw();
            tankObject2.Draw();
            tankBulletObject1.Draw();
            tankBullet1.Draw(tankBullet1.blankHitBox.Overlaps(tank2.blankHitBox));
            tank1.Draw(tank1.blankHitBox.Overlaps(tank2.blankHitBox));
            tank2.Draw(tank2.blankHitBox.Overlaps(tank1.blankHitBox));

            EndDrawing();

        }

    }
}