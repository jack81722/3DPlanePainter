using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExMath
{
    /// <summary>
    /// The features of Math except System.Math
    /// </summary>
    public static class Formula
    {

        #region Clamp : limit value between min and max
        public static int Clamp(int value, int min, int max)
        {
            if (min > max)
            {
                var temp = min;
                min = max;
                max = temp;
            }
            if (value < min)
                value = min;
            else if (value > max)
                value = max;
            return value;
        }

        public static float Clamp(float value, float min, float max)
        {
            if (min > max)
            {
                var temp = min;
                min = max;
                max = temp;
            }
            if (value < min)
                value = min;
            else if (value > max)
                value = max;
            return value;
        }

        public static decimal Clamp(decimal value, decimal min, decimal max)
        {
            if (min > max)
            {
                var temp = min;
                min = max;
                max = temp;
            }
            if (value < min)
                value = min;
            else if (value > max)
                value = max;
            return value;
        }

        public static double Clamp(double value, double min, double max)
        {
            if (min > max)
            {
                var temp = min;
                min = max;
                max = temp;
            }
            if (value < min)
                value = min;
            else if (value > max)
                value = max;
            return value;
        }
        #endregion

        #region Min : find minimum of numbers
        public static int Min(params int[] nums)
        {
            int min = nums[0];
            for (int i = 1; i < nums.Length; i++)
            {
                if (min > nums[i])
                {
                    min = nums[i];
                }
            }
            return min;
        }

        public static float Min(params float[] nums)
        {
            float min = nums[0];
            for (int i = 1; i < nums.Length; i++)
            {
                if (min > nums[i])
                {
                    min = nums[i];
                }
            }
            return min;
        }

        public static double Min(params double[] nums)
        {
            double min = nums[0];
            for (int i = 1; i < nums.Length; i++)
            {
                if (min > nums[i])
                {
                    min = nums[i];
                }
            }
            return min;
        }

        public static decimal Min(params decimal[] nums)
        {
            decimal min = nums[0];
            for (int i = 1; i < nums.Length; i++)
            {
                if (min > nums[i])
                {
                    min = nums[i];
                }
            }
            return min;
        }

        public static int Min(out int min_index, params int[] nums)
        {
            int min = nums[0];
            min_index = 0;
            for (int i = 1; i < nums.Length; i++)
            {
                if (min > nums[i])
                {
                    min = nums[i];
                    min_index = i;
                }
            }
            return min;
        }

        public static float Min(out int min_index, params float[] nums)
        {
            float min = nums[0];
            min_index = 0;
            for (int i = 1; i < nums.Length; i++)
            {
                if (min > nums[i])
                {
                    min = nums[i];
                    min_index = i;
                }
            }
            return min;
        }

        public static decimal Min(out int min_index, params decimal[] nums)
        {
            decimal min = nums[0];
            min_index = 0;
            for (int i = 1; i < nums.Length; i++)
            {
                if (min > nums[i])
                {
                    min = nums[i];
                    min_index = i;
                }
            }
            return min;
        }

        public static double Min(out int min_index, params double[] nums)
        {
            double min = nums[0];
            min_index = 0;
            for (int i = 1; i < nums.Length; i++)
            {
                if (min > nums[i])
                {
                    min = nums[i];
                    min_index = i;
                }
            }
            return min;
        }
        #endregion

        #region Max : find maximum of numbers
        public static int Max(params int[] nums)
        {
            int max = nums[0];
            for (int i = 1; i < nums.Length; i++)
            {
                if (max < nums[i])
                {
                    max = nums[i];
                }
            }
            return max;
        }

        public static float Max(params float[] nums)
        {
            float max = nums[0];
            for (int i = 1; i < nums.Length; i++)
            {
                if (max < nums[i])
                {
                    max = nums[i];
                }
            }
            return max;
        }

        public static decimal Max(params decimal[] nums)
        {
            decimal max = nums[0];
            for (int i = 1; i < nums.Length; i++)
            {
                if (max < nums[i])
                {
                    max = nums[i];
                }
            }
            return max;
        }

        public static double Max(params double[] nums)
        {
            double max = nums[0];
            for (int i = 1; i < nums.Length; i++)
            {
                if (max < nums[i])
                {
                    max = nums[i];
                }
            }
            return max;
        }
        #endregion

        #region Sum : calculate sum of numbers
        public static int Sum(params int[] nums)
        {
            int sum = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                sum += nums[i];
            }
            return sum;
        }

        public static float Sum(params float[] nums)
        {
            float sum = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                sum += nums[i];
            }
            return sum;
        }

        public static decimal Sum(params decimal[] nums)
        {
            decimal sum = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                sum += nums[i];
            }
            return sum;
        }

        public static double Sum(params double[] nums)
        {
            double sum = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                sum += nums[i];
            }
            return sum;
        }
        #endregion

        #region Average : calculate average of numbers
        public static float Avg(params int[] nums)
        {
            return nums.Length > 0 ? (float)Sum(nums) / nums.Length : 0;
        }

        public static float Avg(params float[] nums)
        {
            return nums.Length > 0 ? (float)Sum(nums) / nums.Length : 0;
        }

        public static decimal Avg(params decimal[] nums)
        {
            return nums.Length > 0 ? (decimal)Sum(nums) / nums.Length : 0;
        }

        public static double Avg(params double[] nums)
        {
            return nums.Length > 0 ? (double)Sum(nums) / nums.Length : 0;
        }
        #endregion

        #region Sum of Square : calculate sum of square
        public static int SumOfSquare(params int[] nums)
        {
            int sum = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                sum += nums[i] * nums[i];
            }
            return sum;
        }

        public static float SumOfSquare(params float[] nums)
        {
            float sum = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                sum += nums[i] * nums[i];
            }
            return sum;
        }

        public static decimal SumOfSquare(params decimal[] nums)
        {
            decimal sum = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                sum += nums[i] * nums[i];
            }
            return sum;
        }

        public static double SumOfSquare(params double[] nums)
        {
            double sum = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                sum += nums[i] * nums[i];
            }
            return sum;
        }
        #endregion

        #region Angle & Radian
        public static float AngleToRadian(float angle)
        {
            return (float)(angle * Math.PI / 180);
        }

        public static float AngleToRadian(double angle)
        {
            return (float)(angle * Math.PI / 180);
        }

        public static float RadianToAngle(float radian)
        {
            return (float)(radian * 180 / Math.PI);
        }

        public static float RadianToAngle(double radian)
        {
            return (float)(radian * 180 / Math.PI);
        }
        #endregion

        #region Swap
        public static void Swap<T>(ref T x, ref T y)
        {
            var temp = x;
            x = y;
            y = temp;
        }
        #endregion

        #region Ease Functions
        public static float QuadraticIn(float t, float duration)
        {
            t = Clamp(t / duration, 0, 1);
            return t * t;
        }

        public static double QuadraticIn(double t, double duration)
        {
            t = Clamp(t / duration, 0, 1);
            return t * t;
        }

        public static float QuadraticOut(float t, float duration)
        {
            t = Clamp(t / duration, 0, 1);
            return -t * (t - 2);
        }

        public static double QuadraticOut(double t, double duration)
        {
            t = Clamp(t / duration, 0, 1);
            return -t * (t - 2);
        }

        public static float QuadraticInOut(float t, float duration)
        {
            t = Clamp(t / duration, 0, 1);
            if (t < 0.5f) return t * t * 2;
            return -1 + t * (4 - 2 * t);
        }

        public static double QuadraticInOut(double t, double duration)
        {
            t = Clamp(t / duration, 0, 1);
            if (t < 0.5) return t * t * 2;
            return -1 + t * (4 - 2 * t);
        }

        public static float CubicIn(float t, float duration)
        {
            t = Clamp(t / duration, 0, 1);
            return t * t * t;
        }

        public static double CubicIn(double t, double duration)
        {
            t = Clamp(t / duration, 0, 1);
            return t * t * t;
        }

        public static float CubicOut(float t, float duration)
        {
            t = Clamp(t / duration, 0, 1) - 1;
            return t * t * t + 1;
        }

        public static double CubicOut(double t, double duration)
        {
            t = Clamp(t / duration, 0, 1) - 1;
            return t * t * t + 1;
        }

        public static float CubicInOut(float t, float duration)
        {
            t = Clamp(t / (duration / 2), 0, 1);
            if (t < 1) return t * t * t / 2;
            t -= 2;
            return (t * t * t + 2) / 2;
        }

        public static double CubicInOut(double t, double duration)
        {
            t = Clamp(t / (duration / 2), 0, 1);
            if (t < 1) return t * t * t / 2;
            t -= 2;
            return (t * t * t + 2) / 2;
        }

        public static float QuarticIn(float t, float duration)
        {
            t = Clamp(t / duration, 0, 1);
            return t * t * t * t;
        }

        public static double QuarticIn(double t, double duration)
        {
            t = Clamp(t / duration, 0, 1);
            return t * t * t * t;
        }

        public static float QuarticOut(float t, float duration)
        {
            t = Clamp(t / duration, 0, 1) - 1;
            return 1 - t * t * t * t;
        }

        public static double QuarticOut(double t, double duration)
        {
            t = Clamp(t / duration, 0, 1) - 1;
            return 1 - t * t * t * t;
        }

        public static float QuarticInOut(float t, float duration)
        {
            t = Clamp(t / (duration / 2), 0, 1);
            if (t < 1) return t * t * t * t / 2;
            t -= 2;
            return -(t * t * t * t - 2) / 2;
        }

        public static double QuarticInOut(double t, double duration)
        {
            t = Clamp(t / (duration / 2), 0, 1);
            if (t < 1) return t * t * t * t / 2;
            t -= 2;
            return -(t * t * t * t - 2) / 2;
        }
        #endregion

        #region Byte Flag
        public static bool HasFlag(this byte b, byte flag)
        {
            return (b & flag) == flag;
        }

        public static bool HasFlag(this short b, short flag)
        {
            return (b & flag) == flag;
        }

        public static bool HasFlag(this ushort b, ushort flag)
        {
            return (b & flag) == flag;
        }

        public static void AddFlag(this byte b, byte flag)
        {
            b |= flag;
        }

        public static void AddFlag(this short b, short flag)
        {
            b |= flag;
        }

        public static void AddFlag(this ushort b, ushort flag)
        {
            b |= flag;
        }

        public static void RemoveFlag(this byte b, byte flag)
        {
            b = (byte)(b & flag);
        }

        public static void RemoveFlag(this short b, short flag)
        {
            b = (short)(b & flag);
        }

        public static void RemoveFlag(this ushort b, ushort flag)
        {
            b = (ushort)(b & flag);
        }
        #endregion
    }
}
