using System;
using ExMath.Coordinate;

namespace ExMath.Geometry
{
    public struct Cube
    {
        public Vector3 center;
        public Vector3 size;

        public float xMin { get { return Math.Min(center.x, center.x + size.x); } }
        public float yMin { get { return Math.Min(center.y, center.y + size.y); } }
        public float zMin { get { return Math.Min(center.z, center.z + size.z); } }
        public Vector3 min { get { return new Vector3(xMin, yMin, zMin); } }
        public float xMax { get { return Math.Max(center.x, center.x + size.x); } }
        public float yMax { get { return Math.Max(center.y, center.y + size.y); } }
        public float zMax { get { return Math.Max(center.z, center.z + size.z); } }
        public Vector3 max { get { return new Vector3(xMax, yMax, zMax); } }
        public float volume { get { return size.magnitude; } }

        public Cube(float x, float y, float z, float xSize, float ySize, float zSize)
        {
            center = new Vector3(x, y, z);
            size = new Vector3(xSize, ySize, zSize);
        }

        public Cube(float x, float y, float z, Vector3 size)
        {
            center = new Vector3(x, y, z);
            this.size = size;
        }

        public Cube(Vector3 center, float xSize, float ySize, float zSize)
        {
            this.center = center;
            size = new Vector3(xSize, ySize, zSize);
        }

        public Cube(Vector3 center, Vector3 size)
        {
            this.center = center;
            this.size = size;
        }

        public bool inBound(Vector3 pos)
        {
            return (pos.x >= xMin && pos.x <= xMax) && (pos.y >= yMin && pos.y <= yMax) && (pos.z >= zMin && pos.z <= zMax);
        }
    }
}
