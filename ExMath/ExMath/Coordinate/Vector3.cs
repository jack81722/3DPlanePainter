using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExMath.Coordinate
{
    [Serializable]
    public struct Vector3
    {
        #region Classic Vectors
        public readonly static Vector3 left = new Vector3(-1, 0, 0);
        public readonly static Vector3 right = new Vector3(1, 0, 0);
        public readonly static Vector3 up = new Vector3(0, 1, 0);
        public readonly static Vector3 down = new Vector3(0, -1, 0);
        public readonly static Vector3 forward = new Vector3(0, 0, 1);
        public readonly static Vector3 backward = new Vector3(0, 0, -1);
        public readonly static Vector3 one = new Vector3(1, 1, 1);
        public readonly static Vector3 zero = new Vector3(0, 0, 0);
        #endregion

        #region Fields
        public float x;
        public float y;
        public float z;
        #endregion

        #region Properties
        public float magnitude { get { return (float)Math.Sqrt(x * x + y * y + z * z); } }
        public float sqrMagnitude { get { return x * x + y * y + z * z; } }
        public Vector3 normalized { get { return this / magnitude; } }
        #endregion

        #region Constructors
        public Vector3(float x, float y)
        {
            this.x = x;
            this.y = y;
            z = 0;
        }

        public Vector3(double x, double y)
        {
            this.x = (float)x;
            this.y = (float)y;
            z = 0;
        }

        public Vector3(float x, float y, float z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        public Vector3(double x, double y, double z)
        {
            this.x = (float)x;
            this.y = (float)y;
            this.z = (float)z;
        }
        #endregion

        #region Public Methods
        public enum Plane
        {
            XY,
            YZ,
            XZ
        }

        /// <summary>
        /// Turn vector3 into vector2 by specific axis-plane
        /// </summary>
        /// <param name="plane">Axis-plane</param>
        public Vector2 ToVector2(Plane plane = Plane.XY)
        {
            Vector2 v = new Vector2(x, y);
            switch (plane)
            {
                case Plane.XY:
                    v = new Vector2(x, y);
                    break;
                case Plane.YZ:
                    v = new Vector2(y, z);
                    break;
                case Plane.XZ:
                    v = new Vector2(x, z);
                    break;
                default:
                    throw new InvalidOperationException("Unknown axis plane.");
            }
            return v;
        }

        public void Plus(Vector3 v)
        {
            x += v.x;
            y += v.y;
            z += v.z;
        }

        public void Sub(Vector3 v)
        {
            x -= v.x;
            y -= v.y;
            z -= v.z;
        }

        public void Mul(float f)
        {
            x *= f;
            y *= f;
            z *= f;
        }

        public void Mul(double f)
        {
            x = (float)(x * f);
            y = (float)(y * f);
            z = (float)(z * f);
        }

        public void Div(float f)
        {
            x /= f;
            y /= f;
            z /= f;
        }

        public void Div(double f)
        {
            x = (float)(x / f);
            y = (float)(y / f);
            z = (float)(z / f);
        }

        public void Inverse()
        {
            x = -x;
            y = -y;
            z = -z;
        }

        public float Dot(Vector3 v)
        {
            return x * v.x + y * v.y + z * v.z;
        }

        public float DistanceWith(Vector3 v)
        {
            return (float)Math.Sqrt((x - v.x) * (x - v.x) + (y - v.y) * (y - v.y) + (z - v.z) * (z - v.z));
        }
        #endregion

        #region Public Static Methods
        public static float Dot(Vector3 v1, Vector3 v2)
        {
            return v1.x * v2.x + v1.y * v2.y + v1.z * v2.z;
        }

        public static Vector3 Cross(Vector3 v1, Vector3 v2)
        {
            return new Vector3(v1.y * v2.z - v1.z * v2.y, v1.z * v2.x - v1.x * v2.z, v1.x * v2.y - v1.y * v2.z);
        }

        public static float Angle(Vector3 from, Vector3 to)
        {
            if (from.sqrMagnitude * to.sqrMagnitude <= 0)
                throw new InvalidOperationException("Vector length must be greater than zero.");
            return (float)(Math.Acos(Dot(from, to) / Math.Sqrt(from.sqrMagnitude * to.sqrMagnitude)) * 180 / Math.PI);
        }

        public static float SignAngle(Vector3 from, Vector3 to)
        {
            if (from.sqrMagnitude * to.sqrMagnitude <= 0)
                throw new InvalidOperationException("Vector length must be greater than zero.");
            var n = Cross(from, new Vector3(from.x, from.y + 1, from.z));
            if (Dot(Cross(n, from), to) / Math.Sqrt(from.sqrMagnitude * to.sqrMagnitude) >= 0)
                return Angle(from, to);
            else
                return -Angle(from, to);
        }

        public static float Radian(Vector3 from, Vector3 to)
        {
            if (from.sqrMagnitude * to.sqrMagnitude <= 0)
                throw new InvalidOperationException("Vector length must be greater than zero.");
            return (float)Math.Acos(Dot(from, to) / Math.Sqrt(from.sqrMagnitude * to.sqrMagnitude));
        }

        public static float Distance(Vector3 v1, Vector3 v2)
        {
            return (float)Math.Sqrt((v1.x - v2.x) * (v1.x - v2.x) + (v1.y - v2.y) * (v1.y - v2.y) + (v1.z - v2.z) * (v1.z - v2.z));
        }

        public static Vector3 Normalize(Vector3 v)
        {
            return v.magnitude == 0 ? zero : v / v.magnitude;
        }

        public static bool Approach(Vector3 v1, Vector3 v2, float tolerance)
        {
            return System.Math.Abs(v1.x - v2.x) < tolerance && System.Math.Abs(v1.y - v2.y) < tolerance && System.Math.Abs(v1.z - v2.z) < tolerance;
        }

        public static Vector3 Truncate(Vector3 v, float f)
        {
            var n = f;
            n = f / v.magnitude;
            n = n < 1 ? n : 1;
            return v * n;
        }
        #endregion

        #region Operator Methods
        public static Vector3 operator +(Vector3 v1, Vector3 v2)
        {
            return new Vector3(v1.x + v2.x, v1.y + v2.y, v1.z + v2.z);
        }

        public static Vector3 operator -(Vector3 v1, Vector3 v2)
        {
            return new Vector3(v1.x - v2.x, v1.y - v2.y, v1.z - v2.z);
        }

        public static Vector3 operator *(Vector3 v, float f)
        {
            return new Vector3(v.x * f, v.y * f, v.z * f);
        }

        public static Vector3 operator *(float f, Vector3 v)
        {
            return new Vector3(v.x * f, v.y * f, v.z * f);
        }

        public static Vector3 operator *(Vector3 v, double f)
        {
            return new Vector3(v.x * f, v.y * f, v.z * f);
        }

        public static Vector3 operator *(double f, Vector3 v)
        {
            return new Vector3(v.x * f, v.y * f, v.z * f);
        }

        public static Vector3 operator /(Vector3 v, float f)
        {
            return new Vector3(v.x / f, v.y / f, v.z / f);
        }

        public static Vector3 operator /(Vector3 v, double f)
        {
            return new Vector3(v.x / f, v.y / f, v.z / f);
        }

        public static implicit operator Vector3(Vector2 v)
        {
            return new Vector3(v.x, v.y);
        }

        public static implicit operator Vector3(Vector3Int v)
        {
            return new Vector3(v.x, v.y, v.z);
        }
        #endregion

        #region Public Overrid Methods
        public override string ToString()
        {
            return string.Format("({0:0.0}, {1:0.0}, {2:0.0})", x, y, z);
        }
        #endregion
    }
}
