using System;

namespace ExMath.Coordinate
{
    [Serializable]
    public struct Vector2
    {
        #region Classic Vectors
        public readonly static Vector2 up    = new Vector2( 0,  1);
        public readonly static Vector2 down  = new Vector2( 0, -1);
        public readonly static Vector2 left  = new Vector2(-1,  0);
        public readonly static Vector2 right = new Vector2( 1,  0);
        public readonly static Vector2 one   = new Vector2( 1,  1);
        public readonly static Vector2 zero  = new Vector2( 0,  0);
        #endregion

        #region Fields
        public float x, y;
        #endregion

        #region Properties
        public float magnitude { get { return (float)Math.Sqrt(x * x + y * y); } }
        public float sqrMagnitude { get { return x * x + y * y; } }
        public Vector2 normalized { get { return this / magnitude; } }
        #endregion

        #region Constructor
        public Vector2(float x, float y)
        {
            this.x = x;
            this.y = y;
        }

        public Vector2(double x, double y)
        {
            this.x = (float)x;
            this.y = (float)y;
        }
        #endregion

        #region Public Static Methods
        public static float Dot(Vector2 v1, Vector2 v2)
        {
            return v1.x * v2.x + v1.y * v2.y;
        }

        public static float Cross(Vector2 v1, Vector2 v2)
        {
            return v1.x * v2.y - v1.y * v2.x;
        }

        public static float Radian(Vector2 from, Vector2 to)
        {
            float dist = (from.magnitude * to.magnitude);
            if (dist == 0)
                dist = 1;
            return (float)Math.Acos(Dot(from, to) / dist);
        }

        public static float Angle(Vector2 from, Vector2 to)
        {
            float dist = (from.magnitude * to.magnitude);
            if (dist == 0)
                dist = 1;
            return (float)(Math.Acos(Dot(from, to) / dist) * 180 / Math.PI);
        }

        public static float SignedAngle(Vector2 from, Vector2 to)
        {
            return Cross(from, to) >= 0 ? Angle(from, to) : -Angle(from, to);
        }

        public static float Distance(Vector2 v1, Vector2 v2)
        {
            return (float)Math.Sqrt((v1.x - v2.x) * (v1.x - v2.x) - (v1.y - v2.y) * (v1.y - v2.y));
        }

        public static Vector2 Normalize(Vector2 v)
        {
            return v.magnitude == 0 ? zero : v / v.magnitude;
        }

        public static Vector2[] Orthogonal(Vector2 v)
        {
            return new Vector2[] { new Vector2(v.y, -v.x), new Vector2(-v.y, v.x) };
        }

        public static Vector2[] Orthonormal(Vector2 v)
        {
            return new Vector2[] { Normalize(new Vector2(v.y, -v.x)), Normalize(new Vector2(-v.y, v.x)) };
        }

        public static bool Approach(Vector2 v1, Vector2 v2, float tolerance)
        {
            return System.Math.Abs(v1.x - v2.x) < tolerance && System.Math.Abs(v1.y - v2.y) < tolerance;
        }

        public static Vector2 Truncate(Vector2 v, float f)
        {
            var n = f;
            n = f / v.magnitude;
            n = n < 1 ? n : 1;
            return v * n;
        }

        public static Vector2 operator +(Vector2 v1, Vector2 v2)
        {
            return new Vector2(v1.x + v2.x, v1.y + v2.y);
        }

        public static Vector2 operator -(Vector2 v1, Vector2 v2)
        {
            return new Vector2(v1.x - v2.x, v1.y - v2.y);
        }

        public static Vector2 operator *(Vector2 v, float f)
        {
            return new Vector2(v.x * f, v.y * f);
        }

        public static Vector2 operator *(Vector2 v, double f)
        {
            return new Vector2((float)(v.x * f), (float)(v.y * f));
        }

        public static Vector2 operator /(Vector2 v, float f)
        {
            return new Vector2(v.x / f, v.y / f);
        }

        public static Vector2 operator /(Vector2 v, double f)
        {
            return new Vector2((float)(v.x / f), (float)(v.x / f));
        }
        
        public static implicit operator Vector2(Vector2Int v)
        {
            return new Vector2(v.x, v.y);
        }
        #endregion

        #region Public Override Methods
        public override string ToString()
        {
            return string.Format("({0:0.0}, {1:0.0})", x, y);
        }
        #endregion
    }


}
