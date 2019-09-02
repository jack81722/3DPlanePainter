using ExMath.Coordinate;
using System;

namespace ExMath.Geometry
{
    [Serializable]
    public struct Sphere : IGeometry3D
    {
        #region Fields
        /// <summary>
        /// Center position of sphere
        /// </summary>
        public Vector3 center;

        /// <summary>
        /// Radius of sphere
        /// </summary>
        public float radius;

        public Vector3 Center { get { return center; } set { center = value; } }
        public Vector3 Size { get { return new Vector3(radius, radius, radius); } set { radius = value.x; } }
        #endregion

        #region Properties
        public float xMin { get { return Math.Min(center.x - radius, center.x + radius); } }
        public float yMin { get { return Math.Min(center.y - radius, center.y + radius); } }
        public float zMin { get { return Math.Min(center.z - radius, center.z + radius); } }
        public float xMax { get { return Math.Max(center.x - radius, center.x + radius); } }
        public float yMax { get { return Math.Max(center.y - radius, center.y + radius); } }
        public float zMax { get { return Math.Max(center.z - radius, center.z + radius); } }
        public float Volume { get { return (float)(Math.PI * radius * radius * radius * 4.0 / 3.0); } }
        #endregion

        #region Constructors
        /// <summary>
        /// Constructor of sphere
        /// </summary>
        /// <param name="x">x-axis position</param>
        /// <param name="y">y-axis position</param>
        /// <param name="z">z-axis position</param>
        /// <param name="radius">radius of sphere</param>
        public Sphere(float x, float y, float z, float radius)
        {
            center = new Vector3(x, y, z);
            this.radius = radius;
        }

        /// <summary>
        /// Constructor of sphere
        /// </summary>
        /// <param name="center">center position of sphere</param>
        /// <param name="radius">radius of sphere</param>
        public Sphere(Vector3 center, float radius)
        {
            this.center = center;
            this.radius = radius;
        }
        #endregion
        
        #region Static Methods
        /// <summary>
        /// Check if two sphere are intersect
        /// </summary>
        /// <param name="a">Sphere a</param>
        /// <param name="b">Sphere b</param>
        public static bool isIntersect(Sphere a, Sphere b)
        {
            return 
                (a.center.x - b.center.x) * (a.center.x - b.center.x) +
                (a.center.y - b.center.y) * (a.center.y - b.center.y) +
                (a.center.z - b.center.z) * (a.center.z - b.center.z) < 
                (a.radius + b.radius) * (a.radius + b.radius);
        }

        /// <summary>
        /// Check if cube and speher are intersect
        /// </summary>
        /// <param name="cube">Cube</param>
        /// <param name="sphere">Sphere</param>
        public static bool isIntersect(Cube cube, Sphere sphere)
        {
            Vector3 closest = new Vector3(
                    Math.Max(cube.xMin, Math.Min(sphere.center.x, cube.xMax)),
                    Math.Max(cube.yMin, Math.Min(sphere.center.y, cube.yMax)),
                    Math.Max(cube.zMin, Math.Min(sphere.center.z, cube.zMax)));

            float sqrDist =
                (closest.x - sphere.center.x) * (closest.x - sphere.center.x) +
                (closest.y - sphere.center.y) * (closest.y - sphere.center.y) +
                (closest.z - sphere.center.z) * (closest.z - sphere.center.z);

            return sqrDist <= sphere.radius * sphere.radius;
        }

        /// <summary>
        /// Check if cube and speher are intersect
        /// </summary>
        /// <param name="cube">Cube</param>
        /// <param name="sphere">Sphere</param>
        public static bool isIntersect(Sphere sphere, Cube cube)
        {
            return isIntersect(cube, sphere);
        }

        public bool InBound(Vector3 pos)
        {
            return (pos.x - center.x) * (pos.x - center.x) + (pos.y - center.y) * (pos.y - center.y) + (pos.z - center.z) * (pos.z - center.z) <= radius * radius;
        }

        public bool IsIntersect(IGeometry3D other)
        {
            if(other.GetType() == typeof(Sphere))
            {
                return
                (Center.x - other.Center.x) * (Center.x - other.Center.x) +
                (Center.y - other.Center.y) * (Center.y - other.Center.y) +
                (Center.z - other.Center.z) * (Center.z - other.Center.z) <
                (radius + other.Size.x) * (radius + other.Size.x);
            }
            else
            {
                Vector3 closest = new Vector3(
                    Math.Max(xMin, Math.Min(other.Center.x, xMax)),
                    Math.Max(yMin, Math.Min(other.Center.y, yMax)),
                    Math.Max(zMin, Math.Min(other.Center.z, zMax)));
                return other.InBound(closest);
            }
        }
        #endregion
    }
}
