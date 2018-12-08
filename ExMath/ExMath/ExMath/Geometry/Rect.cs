using ExMath.Coordinate;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExMath.Geometry
{
    [Serializable]
    public struct Rect : IGeometry2D
    {
        #region Fields
        public float x, y, width, height;
        #endregion

        #region Properties
        public float xMin { get { return Math.Min(x, x + width); } }
        public float yMin { get { return Math.Min(y, y + height); } }
        public Vector2 min { get { return new Vector2(xMin, yMin); } }
        public float xMax { get { return Math.Max(x, x + width); } }
        public float yMax { get { return Math.Max(y, y + height); } }
        public Vector2 max { get { return new Vector2(xMax, yMax); } }

        public Vector2 center { get { return new Vector2(x, y); } set { x = value.x; y = value.y; } }
        public Vector2 size { get { return new Vector2(width, height); } set { width = value.x; height = value.y; } }

        public float area { get { return Math.Abs(width * height); } }
        #endregion

        #region Constructors
        public Rect(float x, float y, float width, float height)
        {
            this.x = x;
            this.y = y;
            this.width = width;
            this.height = height;
        }

        public Rect(double x, double y, double width, double height)
        {
            this.x = (float)x;
            this.y = (float)y;
            this.width = (float)width;
            this.height = (float)height;
        }

        public Rect(Vector2 position, Vector2 size)
        {
            this.x = position.x;
            this.y = position.y;
            this.width = size.x;
            this.height = size.y;
        }
        #endregion

        public bool InBound(Vector2 pos)
        {
            return (pos.x >= xMin && pos.x <= xMax) && (pos.y >= yMin && pos.y <= yMin);
        }
    }

}
