using System;
using System.Collections.Generic;
using System.Text;
using Raylib;
using rl = Raylib.Raylib;

namespace ConsoleApp1
{
    class Sphere
    {
        public Vector2 center;
        public float radius;
        public Sphere(Vector2 p, float r)
        {
            this.center = p;
            this.radius = r;
        }

        public void Fit(List<Vector2> points)
        {
            // invalidate extents
            Vector2 min = new Vector2(float.MaxValue, float.MaxValue);
            Vector2 max = new Vector2(float.MinValue, float.MinValue);
            // find min and max of the points
            foreach (Vector2 p in points)
            {
                min = Vector2.Min(min, p);
                max = Vector2.Max(max, p);
            }
            // put a circle around the min/max box
            center = (min + max) * 0.5f;
            radius = center.Distance(max);

        }
        public bool Overlaps(Vector2 p)
        {
            Vector2 toPoint = p - center;
            return toPoint.MagnitudeSqr() <= (radius * radius);
        }
        public bool Overlaps(Sphere other)
        {
            Vector2 diff = other.center - center;
            // compare distance between spheres to combined radii
            float r = radius + other.radius;
            return diff.MagnitudeSqr() <= (r * r);
        }
        public bool Overlaps(AABB aabb)
        {

            Vector2 diff = aabb.ClosestPoint(center) - center;
            return diff.Dot(diff) <= (radius * radius);

        }
        Vector2 ClosestPoint(Vector2 p)
        {
            // distance from center
            Vector2 toPoint = p - center;
            // if outside of radius bring it back to the radius
            if (toPoint.MagnitudeSqr() > radius * radius)
            {
                toPoint = toPoint.GetNormalised() * radius;
            }
            return center + toPoint;
        }

    }
}
