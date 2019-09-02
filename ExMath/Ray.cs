using ExMath.Coordinate;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExMath
{
    [Serializable]
    public struct Ray
    {
        public Vector3 origin;
        public Vector3 direct;

        public Ray(Vector3 origin, Vector3 direct)
        {
            this.origin = origin;
            this.direct = direct;
        }
    }
}
