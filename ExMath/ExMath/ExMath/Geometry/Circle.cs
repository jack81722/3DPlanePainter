using ExMath.Coordinate;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExMath.Geometry
{
    public struct Circle
    {
        public float x, y, radius;
        public Vector2 center { get { return new Vector2(x, y); } }

        public Circle(float x, float y, float radius)
        {
            this.x = x;
            this.y = y;
            this.radius = radius;
        }

        public Circle(Vector2 center, float radius)
        {
            x = center.x;
            y = center.y;
            this.radius = radius;
        }

        public bool inBound(Vector2 pos)
        {
            return (center.x - pos.x) * (center.x - pos.x) + (center.y - pos.y) * (center.y - pos.y) <= radius * radius;
        }
    }
}
