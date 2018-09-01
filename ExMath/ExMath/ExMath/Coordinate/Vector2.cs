using System;

namespace ExMath.Coordinate
{
    /// <summary>
    /// A vector with x-axis and y-axis values
    /// </summary>
    [Serializable]
    public struct Vector2
    {
        #region Often used vector
        public readonly static Vector2 up = new Vector2(0, 1);
        public readonly static Vector2 down = new Vector2(0, -1);
        public readonly static Vector2 left = new Vector2(-1, 0);
        public readonly static Vector2 right = new Vector2(1, 0);
        public readonly static Vector2 one = new Vector2(1, 1);
        public readonly static Vector2 zero = new Vector2(0, 0);
        #endregion

        /// <summary>
        /// x-axis & y-axis values of vector
        /// </summary>
        public float x, y;

        /// <summary>
        /// Vector length
        /// </summary>
        public float magnitude { get { return (float)Math.Sqrt(x * x + y * y); } }

        /// <summary>
        /// Vector length without sqrt
        /// </summary>
        public float sqrMagnitude { get { return x * x + y * y; } }

        /// <summary>
        /// Constuctor of Vector2
        /// </summary>
        /// <param name="x">x-axis value</param>
        /// <param name="y">y-axis value</param>
        public Vector2(float x, float y)
        {
            this.x = x;
            this.y = y;
        }

        /// <summary>
        /// Dot product between two vectors
        /// </summary>
        public static float Dot(Vector2 v1, Vector2 v2)
        {
            return v1.x * v2.x + v1.y * v2.y;
        }

        /// <summary>
        /// Cross product between two vectors
        /// </summary>
        public static float Cross(Vector2 v1, Vector2 v2)
        {
            return v1.x * v2.y - v1.y * v2.x;
        }

        /// <summary>
        /// Calculate angle between two vectors (always positive)
        /// </summary>
        public static float Angle(Vector2 from, Vector2 to)
        {
            return (float)(Math.Acos(Dot(from, to) / (from.magnitude * to.magnitude)) * 180 / Math.PI);
        }

        /// <summary>
        /// Calculate angle between two vectors (0 ~ 180 & 0 ~ -180)
        /// </summary>
        public static float SignAngle(Vector2 from, Vector2 to)
        {
            return (float) (Vector2.Cross(from, to) >= 0 ? Math.Acos(Dot(from, to) / (from.magnitude * to.magnitude)) * 180 / Math.PI : -Math.Acos(Dot(from, to) / (from.magnitude * to.magnitude)) * 180 / Math.PI);
        }
        
        /// <summary>
        /// Calculate distance between two positions
        /// </summary>
        public static float Distance(Vector2 v1, Vector2 v2)
        {
            return (float)Math.Sqrt((v1.x - v2.x) * (v1.x - v2.x) - (v1.y - v2.y) * (v1.y - v2.y));
        }

        /// <summary>
        /// Normalize a vector
        /// </summary>
        public static Vector2 Normalize(Vector2 v)
        {
            return v.magnitude == 0 ? zero : v / v.magnitude;
        }

        /// <summary>
        /// Get two orthogonal vectors
        /// </summary>
        public static Vector2[] Orthogonal(Vector2 v)
        {
            return new Vector2[] { new Vector2(v.y, -v.x), new Vector2(-v.y, v.x) };
        }

        /// <summary>
        /// Get two orthogonal normalized vectors
        /// </summary>
        public static Vector2[] Orthonormal(Vector2 v)
        {
            return new Vector2[] { Normalize(new Vector2(v.y, -v.x)), Normalize(new Vector2(-v.y, v.x)) };
        }

        /// <summary>
        /// Detect two vectors are approach to each other within tolerance
        /// </summary>
        public static bool Approach(Vector2 v1, Vector2 v2, float tolerance)
        {
            return System.Math.Abs(v1.x - v2.x) < tolerance && System.Math.Abs(v1.y - v2.y) < tolerance;
        }

        /// <summary>
        /// Truncate a vector if greater than f
        /// </summary>
        /// <param name="v">truncated vector</param>
        /// <param name="max">max value</param>
        public static Vector2 Truncate(Vector2 v, float max)
        {
            return v * (max / (v.magnitude < 1 ? max / v.magnitude : 1));
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
            return new Vector2(v.x * f, v.x * f);
        }

        public static Vector2 operator /(Vector2 v, float f)
        {
            return new Vector2(v.x / f, v.y / f);
        }

        public static implicit operator Vector2(Vector2Int v)
        {
            return new Vector2(v.x, v.y);
        }

        public static implicit operator Vector2(System.Numerics.Vector2 v)
        {
            return new Vector2(v.X, v.Y);
        }

        public static explicit operator System.Numerics.Vector2(Vector2 v)
        {
            return new System.Numerics.Vector2(v.x, v.y);
        }

        public override string ToString()
        {
            return string.Format("({0:0.0}, {1:0.0})", x, y);
        }
    }

    
}
