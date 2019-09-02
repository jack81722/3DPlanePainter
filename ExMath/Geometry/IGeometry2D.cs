using ExMath.Coordinate;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExMath.Geometry
{
    public interface IGeometry2D
    {
        Vector2 Center { get; set; }
        Vector2 Size { get; set; }

        float Area { get; }

        bool InBound(Vector2 pos);
    }
}
