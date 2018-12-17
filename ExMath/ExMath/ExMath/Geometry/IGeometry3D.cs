using ExMath.Coordinate;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExMath.Geometry
{
    public interface IGeometry3D
    {
        Vector3 Center { get; set; }
        Vector3 Size { get; set; }

        float xMin { get; } float yMin { get; } float zMin { get; }
        float xMax { get; } float yMax { get; } float zMax { get; }
        float Volume { get; }

        bool InBound(Vector3 pos);
        bool IsIntersect(IGeometry3D other);
    }
}
