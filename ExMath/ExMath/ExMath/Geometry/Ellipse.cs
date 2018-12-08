using ExMath.Coordinate;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExMath.Geometry
{
    [Serializable]
    public struct Ellipse : IGeometry2D
    {
        public float x, y;
        public float a, b;

        #region Properties
        public Vector2 size { get { return new Vector2(a, b); } set { a = value.x; b = value.y; } }

        public float area { get { return (float) Math.Abs(Math.PI * a * b); } }

        public Vector2 center { get { return new Vector2(x, y); } set { x = value.x; y = value.y; } }
        #endregion

        #region Constructor
        public Ellipse(float x, float y, float a, float b)
        {
            this.x = x;
            this.y = y;
            this.a = a;
            this.b = b;
        }

        public Ellipse(double x, double y, double a, double b)
        {
            this.x = (float)x;
            this.y = (float)y;
            this.a = (float)a;
            this.b = (float)b;
        }

        public Ellipse(Vector2 center, Vector2 size)
        {
            x = center.x;
            y = center.y;
            a = size.x;
            b = size.y;
        }
        #endregion

        public Vector2 PointAtAngle(float angle)
        {
            return new Vector2(x + a * Math.Cos(Formula.AngleToRadian(angle)), y + b * Math.Sin(Formula.AngleToRadian(angle)));
        }

        public Vector2 PointAtAngle(double angle)
        {
            return new Vector2(x + a * Math.Cos(Formula.AngleToRadian(angle)), y + b * Math.Sin(Formula.AngleToRadian(angle)));
        }

        public Vector2 PointAtRadian(float radian)
        {
            return new Vector2(x + a * Math.Cos(radian), y + b * Math.Sin(radian));
        }

        public Vector2 PointAtRadian(double radian)
        {
            return new Vector2(x + a * Math.Cos(radian), y + b * Math.Sin(radian));
        }

        public bool InBound(Vector2 pos)
        {
            Vector2 vector = pos - center;
            float radian = Vector2.Radian(Vector2.right, vector);
            Vector2 ellipsePoint1 = new Vector2(x + a * Math.Cos(radian), y + b * Math.Sin(radian));
            Vector2 ellipsePoint2 = new Vector2(x + a * Math.Cos(radian - Math.PI), y + b * Math.Sin(radian - Math.PI));
            return pos.x >= Math.Min(ellipsePoint1.x, ellipsePoint2.x) &&
                pos.x <= Math.Max(ellipsePoint1.x, ellipsePoint2.x) &&
                pos.y >= Math.Min(ellipsePoint1.y, ellipsePoint2.y) &&
                pos.y <= Math.Max(ellipsePoint1.y, ellipsePoint2.y);
        }

        public static implicit operator Ellipse(Circle circle)
        {
            return new Ellipse(circle.x, circle.y, circle.radius, circle.radius);
        }
    }
}
