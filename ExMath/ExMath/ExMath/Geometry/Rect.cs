using ExMath.Coordinate;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExMath.Geometry
{
    public struct Rect
    {
        public float x, y, width, height;
        public Vector2 position { get { return new Vector2(x, y); } }
        public Vector2 size { get { return new Vector2(width, height); } }
        public float xMin { get { return Math.Min(x, x + width); } }
        public float yMin { get { return Math.Min(y, y + height); } }
        public Vector2 min { get { return new Vector2(xMin, yMin); } }
        public float xMax { get { return Math.Max(x, x + width); } }
        public float yMax { get { return Math.Max(y, y + height); } }
        public Vector2 max { get { return new Vector2(xMax, yMax); } }

        public Rect(float x, float y, float width, float height)
        {
            this.x = x;
            this.y = y;
            this.width = width;
            this.height = height;
        }

        public Rect(Vector2 position, Vector2 size)
        {
            this.x = position.x;
            this.y = position.y;
            this.width = size.x;
            this.height = size.y;
        }

        public bool inBound(Vector2 position)
        {
            return (position.x >= xMin && position.x <= xMax) && (position.y >= yMin && position.y <= yMin);
        }
    }

}
