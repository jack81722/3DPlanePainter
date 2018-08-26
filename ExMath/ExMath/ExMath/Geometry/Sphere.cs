using ExMath.Coordinate;
using System;

namespace ExMath.Geometry
{
    public struct Sphere
    {
        public float x, y, z;
        public float radius;

        public Vector3 center { get { return new Vector3(x, y, z); } }

        public Sphere(float x, float y, float z, float radius)
        {
            this.x = x;
            this.y = y;
            this.z = z;
            this.radius = radius;
        }

        public Sphere(Vector3 center, float radius)
        {
            x = center.x;
            y = center.y;
            z = center.z;
            this.radius = radius;
        }

        public bool inBound(Vector3 pos)
        {
            return (pos.x - x) * (pos.x - x) + (pos.y - y) * (pos.y - y) + (pos.z - z) * (pos.z - z) <= radius * radius;
        }
    }
}
