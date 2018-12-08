using ExMath.Coordinate;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExMath.Geometry
{
    [Serializable]
    public struct RectInt
    {
        public int x, y, width, height;
        public Vector2Int position { get { return new Vector2Int(x, y); } }
        public Vector2Int size { get { return new Vector2Int(width, height); } }
        public int xMin { get { return Math.Min(x, x + width); } }
        public int yMin { get { return Math.Min(y, y + height); } }
        public Vector2Int min { get { return new Vector2Int(xMin, yMin); } }
        public int xMax { get { return Math.Max(x, x + width); } }
        public int yMax { get { return Math.Max(y, y + height); } }
        public Vector2Int max { get { return new Vector2Int(xMax, yMax); } }

        public RectInt(int x, int y, int width, int height)
        {
            this.x = x;
            this.y = y;
            this.width = width;
            this.height = height;
        }

        public RectInt(Vector2Int position, int width, int height)
        {
            this.x = position.x;
            this.y = position.y;
            this.width = width;
            this.height = height;
        }

        public RectInt(Vector2Int position, Vector2Int size)
        {
            this.x = position.x;
            this.y = position.y;
            this.width = size.x;
            this.height = size.y;
        }

        public RectInt(int x, int y, Vector2Int size)
        {
            this.x = x;
            this.y = y;
            this.width = size.x;
            this.height = size.y;
        }

        public bool inBound(Vector2Int position)
        {
            return (position.x >= xMin && position.x <= xMax) && (position.y >= yMin && position.y <= yMin);
        }
    }
}
