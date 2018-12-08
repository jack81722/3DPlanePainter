using ExMath.Coordinate;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExMath.Geometry
{
    public interface IGeometry2D
    {
        Vector2 center { get; set; }
        Vector2 size { get; set; }

        float area { get; }

        bool InBound(Vector2 pos);
    }
}
