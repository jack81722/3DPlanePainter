﻿using System;

namespace ExMath.Coordinate
{
    [Serializable]
    public struct Vector2
    {
        public static readonly Vector2 up    = new Vector2( 0,  1, true);
        public static readonly Vector2 down  = new Vector2( 0, -1, true);
        public static readonly Vector2 left  = new Vector2(-1,  0, true);
        public static readonly Vector2 right = new Vector2( 1,  0, true);
        public static readonly Vector2 one   = new Vector2( 1,  1, true);
        public static readonly Vector2 zero  = new Vector2( 0,  0, true);

        #region Fields
        public float _x, _y;
        private float _magnitude;
        private bool _isChanged, _isNormalized;
        #endregion

        #region Properties
        public float x
        {
            get { return _x; }
            set
            {
                _x = value;
                _isChanged = true;
                _isNormalized = false;
            }
        }
        public float y
        {
            get { return _y; }
            set
            {
                _y = value;
                _isChanged = true;
                _isNormalized = false;
            }
        }
        public float magnitude
        {
            get
            {
                if (_isChanged)
                {
                    _magnitude = (float)Math.Sqrt(_x * _x + _y * _y);
                    _isChanged = false;
                    if (_magnitude == 1)
                        _isNormalized = true;
                }
                return _magnitude;
            }
        }
        public float sqrMagnitude { get { return x * x + y * y; } }
        public Vector2 normalized
        {
            get
            {
                if (!_isNormalized)
                {
                    var x = _x / magnitude;
                    var y = _y / magnitude;
                    return new Vector2(x, y, true);
                }
                else
                {
                    return this;
                }
            }
        }
        #endregion

        #region Constructor
        private Vector2(float x, float y, bool isNormalized)
        {   
            _x = x;
            _y = y;
            _magnitude = 0;
            _isChanged = true;
            _isNormalized = isNormalized;
        }

        public Vector2(float x, float y)
        {
            _x = x;
            _y = y;
            _magnitude = 0;
            _isChanged = true;
            _isNormalized = false;
        }

        public Vector2(double x, double y)
        {
            _x = (float)x;
            _y = (float)y;
            _magnitude = 0;
            _isChanged = true;
            _isNormalized = false;
        }
        #endregion

        #region Public Methods
        public enum Plane
        {
            XY,
            YZ,
            XZ
        }

        public Vector3 ToVector3(Plane plane = Plane.XY)
        {
            Vector3 v = new Vector3(x, y, 0);
            switch (plane)
            {
                case Plane.XY:
                    v = new Vector3(x, y, 0);
                    break;
                case Plane.YZ:
                    v = new Vector3(0, x, y);
                    break;
                case Plane.XZ:
                    v = new Vector3(x, 0, y);
                    break;
                default:
                    throw new InvalidOperationException("Unknown axis-plane.");
            }
            return v;
        }
        
        public void Plus(Vector2 v)
        {
            x += v.x;
            y += v.y;
        }

        public void Sub(Vector2 v)
        {
            x -= v.x;
            y -= v.y;
        }

        public void Mul(float f)
        {
            x *= f;
            y *= f;
        }

        public void Mul(double f)
        {
            x = (float)(x * f);
            y = (float)(y * f);
        }

        public void Div(float f)
        {
            x /= f;
            y /= f;
        }

        public void Div(double f)
        {
            x = (float)(x / f);
            y = (float)(y / f);
        }

        public void Inverse()
        {
            x = -x;
            y = -y;
        }

        public float Dot(Vector2 v)
        {
            return x * v.x + y * v.y;
        }

        public float Cross(Vector2 v)
        {
            return x * v.y - y * v.x;
        }

        public float DistanceWith(Vector2 v)
        {
            return (float)Math.Sqrt((x - v.x) * (x - v.x) - (y - v.y) * (y - v.y));
        }

        public void Normalize()
        {
            if (magnitude == 0)
            {
                _x = 0;
                _y = 0;
            }
            else
            {
                _x = _x / magnitude;
                _y = _y / magnitude;
            }
            _isNormalized = true;
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
                //throw new InvalidOperationException("Vector length must be greater than zero.");
                return 0;
            return (float)Math.Acos(Dot(from, to) / dist);
        }

        public static float Angle(Vector2 from, Vector2 to)
        {
            float dist = (from.magnitude * to.magnitude);
            if (dist == 0)
                //throw new InvalidOperationException("Vector length must be greater than zero.");
                return 0;
            return (float)(Math.Acos(Dot(from, to) / dist) * 180 / Math.PI);
        }

        public static float SignedAngle(Vector2 from, Vector2 to)
        {
            return Cross(from, to) >= 0 ? Angle(from, to) : -Angle(from, to);
        }

        public static float Distance(Vector2 v1, Vector2 v2)
        {
            return (float)Math.Sqrt((v1.x - v2.x) * (v1.x - v2.x) + (v1.y - v2.y) * (v1.y - v2.y));
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
            v1.Plus(v2);
            return v1;
        }

        public static Vector2 operator -(Vector2 v1, Vector2 v2)
        {
            v1.Sub(v2);
            return v1;
        }

        public static Vector2 operator *(Vector2 v, float f)
        {
            v.Mul(f);
            return v;
        }

        public static Vector2 operator *(Vector2 v, double f)
        {
            v.Mul(f);
            return v;
        }

        public static Vector2 operator /(Vector2 v, float f)
        {
            v.Div(f);
            return v;
        }

        public static Vector2 operator /(Vector2 v, double f)
        {
            v.Div(f);
            return v;
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
