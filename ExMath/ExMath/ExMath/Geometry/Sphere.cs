using ExMath.Coordinate;
using System;

namespace ExMath.Geometry
{
    public struct Sphere
    {
        public Vector3 center;
        public float radius;

        public Sphere(float x, float y, float z, float radius)
        {
            center = new Vector3(x, y, z);
            this.radius = radius;
        }

        public Sphere(Vector3 center, float radius)
        {
            this.center = center;
            this.radius = radius;
        }

        public bool inBound(Vector3 pos)
        {
            return (pos.x - center.x) * (pos.x - center.x) + (pos.y - center.y) * (pos.y - center.y) + (pos.z - center.z) * (pos.z - center.z) <= radius * radius;
        }
    }
}
