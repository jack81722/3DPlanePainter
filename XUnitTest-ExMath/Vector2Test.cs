using ExMath.Coordinate;
using System;
using Xunit;

namespace XUnitTest_ExMath
{
    public class Vector2Test
    {
        [Fact]
        public void Test_Normalize()
        {
            Vector2 v = new Vector2(3, 4);
            v.Normalize();

            float normalizedX = 3f / 5f, normalizedY = 4f / 5f;

            Assert.Equal(normalizedX, v.x);
            Assert.Equal(normalizedY, v.y);
        }

        [Fact]
        public void Test_NormalizedProperty()
        {
            Vector2 v = new Vector2(3, 4);
            
            float normalizedX = 3f / 5f, normalizedY = 4f / 5f;

            Assert.Equal(normalizedX, v.normalized.x);
            Assert.Equal(normalizedY, v.normalized.y);
        }

        [Fact]
        public void Test_MagnitudeProperty()
        {
            Vector2 v = new Vector2(3, 4);

            Assert.Equal(5, v.magnitude);
        }

        [Fact]
        public void Test_SetValueAfterNormalized()
        {
            Vector2 v = new Vector2(3, 4);
            v.Normalize();
            v.x = 3;
            v.y = 4;

            Assert.Equal(5, v.magnitude);
        }

        [Fact]
        public void Test_XPlusOperator()
        {
            Vector2 v1 = new Vector2(1, 3);
            Vector2 v2 = new Vector2(2, 1);
            Vector2 v3 = v1 + v2;

            Assert.Equal(3, v3.x);
        }

        [Fact]
        public void Test_YPlusOperator()
        {
            Vector2 v1 = new Vector2(1, 3);
            Vector2 v2 = new Vector2(2, 1);
            Vector2 v3 = v1 + v2;

            Assert.Equal(4, v3.y);
        }

        [Fact]
        public void Test_XMinusOperator()
        {
            Vector2 v1 = new Vector2(7, 4);
            Vector2 v2 = new Vector2(3, 1);
            Vector2 v3 = v1 - v2;

            Assert.Equal(4, v3.x);
        }

        [Fact]
        public void Test_YMinusOperator()
        {
            Vector2 v1 = new Vector2(7, 4);
            Vector2 v2 = new Vector2(3, 1);
            Vector2 v3 = v1 - v2;

            Assert.Equal(3, v3.y);
        }

        [Fact]
        public void Test_MinusAndMagnitude()
        {
            Vector2 v1 = new Vector2(7, 4);
            Vector2 v2 = new Vector2(3, 1);
            Vector2 v3 = v1 - v2;

            Assert.Equal(5, v3.magnitude);
        }

        [Fact]
        public void Test_XMulOperator()
        {
            Vector2 v1 = new Vector2(1, 3);
            Vector2 v2 = v1 * 5;

            Assert.Equal(5, v2.x);
        }

        [Fact]
        public void Test_YMulOperator()
        {
            Vector2 v1 = new Vector2(1, 3);
            Vector2 v2 = v1 * 5;

            Assert.Equal(15, v2.y);
        }

        [Fact]
        public void Test_XDivOperator()
        {
            Vector2 v1 = new Vector2(1, 3);
            Vector2 v2 = v1 / 5;

            float ans = 1f / 5f;

            Assert.Equal(ans, v2.x);
        }

        [Fact]
        public void Test_YDivOperator()
        {
            Vector2 v1 = new Vector2(1, 3);
            Vector2 v2 = v1 / 5;

            float ans = 3f / 5f;

            Assert.Equal(ans, v2.y);
        }
    }
}
