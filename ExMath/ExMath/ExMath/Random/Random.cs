using ExMath.Coordinate;
using System;

namespace ExMath
{
    public static class Random
    {
        private static System.Random random = new System.Random();

        #region Coordinate Random Methods
        public static Vector2 insideUnitCircle
        {
            get
            {
                double angle = random.NextDouble() * System.Math.PI * 2;
                double x = System.Math.Cos(angle);
                double y = System.Math.Sin(angle);
                return new Vector2((float)x, (float)y) * random.NextDouble();
            }
        }

        public static Vector3 insideUnitSphere
        {
            get
            {
                double x = Range(-1.0, 1.0);
                double y = Range(-1.0, 1.0);
                double z = Range(-1.0, 1.0);
                return Vector3.Normalize(new Vector3((float)x, (float)y, (float)z)) * (float)random.NextDouble();
            }
        }

        public static Vector2 GetCirclePoint(float min, float max)
        {
            double angle = random.NextDouble() * System.Math.PI * 2;
            double x = System.Math.Cos(angle);
            double y = System.Math.Sin(angle);
            return new Vector2((float)x, (float)y) * Range(min, max);
        }

        public static Vector3 GetSpherePoint(float min, float max)
        {
            double x = Range(-1.0, 1.0);
            double y = Range(-1.0, 1.0);
            double z = Range(-1.0, 1.0);
            return Vector3.Normalize(new Vector3((float)x, (float)y, (float)z)) * Range(min, max);
        }
        #endregion

        public static double Range(double min, double max)
        {
            if (min > max)
                throw new InvalidOperationException("Min cannot greater than max");
            return random.NextDouble() * (max - min) + min;
        }

        public static float Range(float min, float max)
        {
            if (min > max)
                throw new InvalidOperationException("Min cannot greater than max");
            return (float)random.NextDouble() * (max - min) + min;
        }

        public static int Range(int min, int max)
        {
            if (min > max)
                throw new InvalidOperationException("Min cannot greater than max");
            return random.Next(min, max);
        }

        public static T[] Shuffle<T>(params T[] array)
        {
            int r;
            T temp;
            for (int i = 0; i < array.Length; i++)
            {
                r = Range(i, array.Length);
                temp = array[i];
                array[i] = array[r];
                array[r] = temp;
            }
            return array;
        }
    }
}