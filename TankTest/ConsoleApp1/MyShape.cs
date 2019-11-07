using System;
using System.Collections.Generic;
using System.Text;
using Raylib;
using rl = Raylib.Raylib;
namespace ConsoleApp1
{
    class MyShape
    {

        public Color NoCollision = Color.GREEN;
        public Color Collision = Color.RED;
        public AABB blankHitBox = new AABB(Vector2.Zero, Vector2.Zero);
        public List<Vector2> MyTankPoints = new List<Vector2>();

        public void Draw(bool HitBoxCollision)
        {
            blankHitBox.Fit(MyTankPoints);
            if (HitBoxCollision == false)
            {

                rl.DrawLine((int)blankHitBox.min.x, (int)blankHitBox.min.y, (int)blankHitBox.min.x, (int)blankHitBox.max.y, NoCollision);
                rl.DrawLine((int)blankHitBox.min.x, (int)blankHitBox.max.y, (int)blankHitBox.max.x, (int)blankHitBox.max.y, NoCollision);
                rl.DrawLine((int)blankHitBox.max.x, (int)blankHitBox.max.y, (int)blankHitBox.max.x, (int)blankHitBox.min.y, NoCollision);
                rl.DrawLine((int)blankHitBox.max.x, (int)blankHitBox.min.y, (int)blankHitBox.min.x, (int)blankHitBox.min.y, NoCollision);
            }
            if (HitBoxCollision == true)
            {
                rl.DrawLine((int)blankHitBox.min.x, (int)blankHitBox.min.y, (int)blankHitBox.min.x, (int)blankHitBox.max.y, Collision);
                rl.DrawLine((int)blankHitBox.min.x, (int)blankHitBox.max.y, (int)blankHitBox.max.x, (int)blankHitBox.max.y, Collision);
                rl.DrawLine((int)blankHitBox.max.x, (int)blankHitBox.max.y, (int)blankHitBox.max.x, (int)blankHitBox.min.y, Collision);
                rl.DrawLine((int)blankHitBox.max.x, (int)blankHitBox.min.y, (int)blankHitBox.min.x, (int)blankHitBox.min.y, Collision);
                

            }

        }

    }
}
