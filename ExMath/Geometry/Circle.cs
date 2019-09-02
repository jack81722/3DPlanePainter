using ExMath.Coordinate;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExMath.Geometry
{
    [Serializable]
    public struct Circle : IGeometry2D
    {
        public float x, y, radius;
        public Vector2 Center { get { return new Vector2(x, y); } set { x = value.x; y = value.y; } }

        public Vector2 Size { get { return new Vector2(radius, radius); } set { radius = value.x; } }

        public float Area { get { return (float)(Math.PI * radius * radius); } }

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

        public Vector2 PointAtAngle(float angle)
        {
            return new Vector2(x + radius * Math.Cos(Formula.AngleToRadian(angle)), y + radius * Math.Sin(Formula.AngleToRadian(angle)));
        }

        public Vector2 PointAtAngle(double angle)
        {
            return new Vector2(x + radius * Math.Cos(Formula.AngleToRadian(angle)), y + radius * Math.Sin(Formula.AngleToRadian(angle)));
        }

        public Vector2 PointAtRadian(float radian)
        {
            return new Vector2(x + radius * Math.Cos(radian), y + radius * Math.Sin(radian));
        }

        public Vector2 PointAtRadian(double radian)
        {
            return new Vector2(x + radius * Math.Cos(radian), y + radius * Math.Sin(radian));
        }

        public bool InBound(Vector2 pos)
        {
            return (Center.x - pos.x) * (Center.x - pos.x) + (Center.y - pos.y) * (Center.y - pos.y) <= radius * radius;
        }

        public static implicit operator Circle(Ellipse ellipse)
        {
            if (ellipse.a == ellipse.b)
                throw new InvalidCastException("Cannot cast ellipse to circle because of a not equals b.");
            return new Circle(ellipse.x, ellipse.y, ellipse.a);
        }
    }
}
