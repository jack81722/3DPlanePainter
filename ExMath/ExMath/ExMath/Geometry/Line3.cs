using ExMath.Coordinate;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExMath.Geometry
{
    public struct Line3
    {
        #region Fields
        public Vector3 p1, p2;
        #endregion

        #region Properties
        public float distance { get { return Vector3.Distance(p1, p2); } }
        #endregion

        #region Constructors
        public Line3(float x1, float y1, float z1, float x2, float y2, float z2)
        {
            p1 = new Vector3(x1, y1, z1);
            p2 = new Vector3(x2, y2, z2);
        }

        public Line3(double x1, double y1, double z1, double x2, double y2, double z2)
        {
            p1 = new Vector3(x1, y1, z1);
            p2 = new Vector3(x2, y2, z2);
        }

        public Line3(Vector3 p1, Vector3 p2)
        {
            this.p1 = p1;
            this.p2 = p2;
        }
        #endregion

        #region Public Static Methods
        public static float Distance(Vector3 point, Line3 line)
        {
            Vector3 v1 = point - line.p1, v2 = line.p2 - line.p1, v3 = point - line.p2;
            if (Vector3.Radian(v1, v2) > Math.PI / 2)
            {
                return v1.magnitude;
            }
            if (Vector3.Radian(v2 * -1, v3) > Math.PI / 2)
            {
                return v3.magnitude;
            }
            return (float)((Math.Sqrt(v1.sqrMagnitude * v2.sqrMagnitude) * Math.Sin(Vector3.Radian(v1, v2)) / 2) / line.distance);
        }

        public static float Distance(Line3 line, Vector3 point)
        {
            Vector3 v1 = point - line.p1, v2 = line.p2 - line.p1, v3 = point - line.p2;
            if(v1.sqrMagnitude == 0 || v3.sqrMagnitude == 0)
                return 0;
            if (v2.sqrMagnitude == 0)
                return Vector3.Distance(line.p1, point);

            if (Vector3.Radian(v1, v2) > Math.PI / 2)
            {
                return v1.magnitude;
            }
            if (Vector3.Radian(v2 * -1, v3) > Math.PI / 2)
            {
                return v3.magnitude;
            }
            return (float)((Math.Sqrt(v1.sqrMagnitude * v2.sqrMagnitude) * Math.Sin(Vector3.Radian(v1, v2)) / 2) / line.distance);
        }

        public static Vector3 ClosestPoint(Line3 line, Vector3 point)
        {
            Vector3 v1 = point - line.p1, v2 = line.p2 - line.p1, v3 = point - line.p2;
            if (v1.sqrMagnitude == 0 || v3.sqrMagnitude == 0)
                return point;
            if (v2.sqrMagnitude == 0)
                return line.p1;

            if (Vector3.Radian(v2 * -1, v3) > (float)Math.PI / 2)
                return point;
            float radian = Vector3.Radian(v1, v2);
            
            if (radian == (float)Math.PI / 2)
                return line.p1;
            else if(radian > (float)Math.PI / 2)
                return point;
            else
                return line.p1 * (1 - Math.Atan(radian)) + line.p2 * Math.Atan(radian);
        }

        //public static bool Intersect(Line3 line,  cube)
        //{
        //    Vector3 closest = ClosestPoint(line, )
        //}
        #endregion

        public override string ToString()
        {
            return string.Format("{{{0}, {1}}}", p1, p2);
        }
    }
}
