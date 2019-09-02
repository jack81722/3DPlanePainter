using System;
using System.Collections.Generic;
using System.Text;

namespace ExMath.Coordinate
{
    [Serializable]
    public struct Vector3Int
    {
        #region Classic Vectors
        public readonly static Vector3Int left     = new Vector3Int(-1,  0,  0);
        public readonly static Vector3Int right    = new Vector3Int( 1,  0,  0);
        public readonly static Vector3Int up       = new Vector3Int( 0,  1,  0);
        public readonly static Vector3Int down     = new Vector3Int( 0, -1,  0);
        public readonly static Vector3Int forward  = new Vector3Int( 0,  0,  1);
        public readonly static Vector3Int backward = new Vector3Int( 0,  0, -1);
        public readonly static Vector3Int one      = new Vector3Int( 1,  1,  1);
        public readonly static Vector3Int zero     = new Vector3Int( 0,  0,  0);
        #endregion

        #region Fields
        public int x, y, z;
        #endregion

        #region Properties
        public float magnitude { get { return (float) Math.Sqrt(x * x + y * y + z * z); } }
        public float sqrMagnitude { get { return x * x + y * y + z * z; } }
        public Vector3 normalized { get { return this / magnitude; } }
        #endregion

        #region Constructors
        public Vector3Int(int x, int y)
        {
            this.x = x;
            this.y = y;
            z = 0;
        }

        public Vector3Int(int x, int y, int z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }
        #endregion

        #region Operator Methods
        public static Vector3Int operator +(Vector3Int v1, Vector3Int v2)
        {
            return new Vector3Int(v1.x + v2.x, v1.y + v2.y, v1.z + v2.z);
        }

        public static Vector3Int operator -(Vector3Int v1, Vector3Int v2)
        {
            return new Vector3Int(v1.x - v2.x, v1.y - v2.y, v1.z - v2.z);
        }

        public static Vector3Int operator *(Vector3Int v, int n)
        {
            return new Vector3Int(v.x * n, v.y * n, v.z * n);
        }

        public static Vector3 operator *(Vector3Int v, float f)
        {
            return new Vector3(v.x * f, v.y * f, v.z * f);
        }

        public static Vector3 operator /(Vector3Int v, float f)
        {
            return new Vector3(v.x / f, v.y / f, v.x / f);
        }
        #endregion

        #region Public Static Methods
        public static Vector3Int Round(Vector3 v)
        {
            return new Vector3Int((int)Math.Round(v.x), (int)Math.Round(v.y), (int)Math.Floor(v.y));
        }

        public static Vector3Int Floor(Vector3 v)
        {
            return new Vector3Int((int)Math.Floor(v.x), (int)Math.Floor(v.y), (int)Math.Floor(v.z));
        }

        public static Vector3Int Ceiling(Vector3 v)
        {
            return new Vector3Int((int)Math.Ceiling(v.x), (int)Math.Ceiling(v.y), (int)Math.Ceiling(v.z));
        }

        public static implicit operator Vector3Int(Vector2Int v)
        {
            return new Vector3Int(v.x, v.y);
        }
        #endregion
    }
}
