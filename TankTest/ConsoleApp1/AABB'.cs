using System;
using System.Collections.Generic;
using System.Text;
using Raylib;
using rl = Raylib.Raylib;

namespace ConsoleApp1
{
    class AABB
    {
        public Vector2 min = new Vector2(float.NegativeInfinity,
       float.NegativeInfinity);
        public Vector2 max = new Vector2(float.PositiveInfinity,
       float.PositiveInfinity);


        //Finding minimum and maximum of vector2
        public AABB(Vector2 min, Vector2 max)
        {
            this.min = min;
            this.max = max;
        }

        //Finding the center of the box
        public Vector2 Center()
        {
            return (min + max) * 0.5f;
        }
        public Vector2 Extents()
        {
            return new Vector2(Math.Abs(max.x - min.x) * 0.5f,
            Math.Abs(max.y - min.y) * 0.5f);
        }
        public void Fit(List<Vector2> points)
        {
            // invalidate the extents
            min = new Vector2(float.PositiveInfinity,
           float.PositiveInfinity);
            max = new Vector2(float.NegativeInfinity,
           float.NegativeInfinity);
            // find min and max of the points
            foreach (Vector2 p in points)
            {
                min = Vector2.Min(min, p);
                max = Vector2.Max(max, p);
            }
        }

        public bool Overlaps(Vector2 p)
        {
            // test for not overlapped as it exits faster
            return !(p.x < min.x || p.y < min.y ||
            p.x > max.x || p.y > max.y);
        }
        public bool Overlaps(AABB other)
        {
            // test for not overlapped as it exits faster
            return !(max.x < other.min.x || max.y < other.min.y ||
            min.x > other.max.x || min.y > other.max.y);
        }
        public Vector2 ClosestPoint(Vector2 p)
        {
            return Vector2.Clamp(p, min, max);
        }


        public List<Vector2> Corners()
        {
            // ignoring z axis for 2D
            List<Vector2> corners = new List<Vector2>(4);
            corners[0] = min;
            corners[1] = new Vector2(min.x, max.y);
            corners[2] = max;
            corners[3] = new Vector2(max.x, min.y);
            return corners;
        }

    }
}
