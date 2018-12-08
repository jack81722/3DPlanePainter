﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ExMath.Coordinate
{
    /// <summary>
    /// A vector with x-axis and y-axis integer values
    /// </summary>
    [Serializable]
    public struct Vector2Int
    {
        #region Classic Vectors
        public readonly static Vector2Int up = new Vector2Int(0, 1);
        public readonly static Vector2Int down = new Vector2Int(0, -1);
        public readonly static Vector2Int left = new Vector2Int(-1, 0);
        public readonly static Vector2Int right = new Vector2Int(1, 0);
        public readonly static Vector2Int one = new Vector2Int(1, 1);
        public readonly static Vector2Int zero = new Vector2Int(0, 0);
        #endregion

        #region Fields
        public int x, y;
        #endregion

        #region Properties
        public float magnitude { get { return (float)Math.Sqrt(x * x + y * y); } }
        public float sqrMagnitude { get { return x * x + y * y; } }
        public Vector2 normalized { get { return this / magnitude; } }
        #endregion

        #region Constructor
        public Vector2Int(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
        #endregion

        #region Public Static Methods
        public static Vector2Int operator +(Vector2Int v1, Vector2Int v2)
        {
            return new Vector2Int(v1.x + v2.x, v1.y + v2.y);
        }

        public static Vector2Int operator -(Vector2Int v1, Vector2Int v2)
        {
            return new Vector2Int(v1.x - v2.x, v1.y - v2.y);
        }

        public static Vector2Int operator *(Vector2Int v, int n)
        {
            return new Vector2Int(v.x * n, v.y * n);
        }

        public static Vector2 operator *(Vector2Int v, float f)
        {
            return new Vector2(v.x * f, v.y * f);
        }
        
        public static Vector2 operator /(Vector2Int v, float f)
        {
            return new Vector2(v.x / f, v.y / f);
        }

        public static Vector2Int Round(Vector2 v)
        {
            return new Vector2Int((int)Math.Round(v.x), (int)Math.Round(v.y));
        }

        public static Vector2Int Floor(Vector2 v)
        {
            return new Vector2Int((int)Math.Floor(v.x), (int)Math.Floor(v.y));
        }

        public static Vector2Int Ceiling(Vector2 v)
        {
            return new Vector2Int((int)Math.Ceiling(v.x), (int)Math.Ceiling(v.y));
        }
        #endregion

    }
}
