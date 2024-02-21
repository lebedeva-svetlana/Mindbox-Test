namespace MindboxTest
{
    public class TriangleCalculationTest
    {
        public static IEnumerable<object[]> TriangleData =>
            new List<object[]>
            {
            new object[] { new TriangleParam() { Ab = 4, Bc = 5, Ca = 3 }, 6 },
            new object[] { new TriangleParam() { Ab = 5.5, Bc = 5, Ca = 3 }, 7 },
            };

        public static IEnumerable<object[]> TriangleIsRectangularData =>
            new List<object[]>
            {
            new object[] { new TriangleParam() { Ab = 3, Bc = 4, Ca = 5 }, true },
            new object[] { new TriangleParam() { Ab = 6, Bc = 9, Ca = 7 }, false },
            new object[] { new TriangleParam() { Ab = 6.2, Bc = 5, Ca = 7 }, false },
            };

        [Theory, MemberData(nameof(TriangleIsRectangularData))]
        public void IsRectangular_InputNotNullParam_GetBool(TriangleParam param, bool result)
        {
            ITriangleCalculation calculation = new TriangleCalculation();

            Assert.Equal(calculation.IsRectangular(param), result);
        }

        [Fact]
        public void IsRectangular_InputNullParam_GetNull()
        {
            ITriangleCalculation calculation = new TriangleCalculation();

            Assert.Null(calculation.IsRectangular(null));
        }

        [Theory]
        [InlineData(0, 4, 3)]
        [InlineData(0, 0, 0)]
        [InlineData(2, -2, 7)]
        public void IsRectangular_InputZeroLessOrEqualParam_GetNull(int ab, int bc, int ca)
        {
            ITriangleCalculation calculation = new TriangleCalculation();

            Assert.Null(calculation.IsRectangular(new TriangleParam() { Ab = ab, Bc = bc, Ca = ca }));
        }

        [Theory, MemberData(nameof(TriangleData))]
        public void GetArea_InputNotNullParam_GetTriangleArea(TriangleParam param, int result)
        {
            ITriangleCalculation calculation = new TriangleCalculation();
            Figure figure = new(calculation);

            Assert.Equal(Math.Round((double)figure.GetArea(param)), result);
        }

        [Fact]
        public void GetArea_InputNullParam_GetTriangleNull()
        {
            ITriangleCalculation calculation = new TriangleCalculation();
            Figure figure = new(calculation);

            Assert.Null(figure.GetArea(null));
        }

        [Theory]
        [InlineData(0, 4, 3)]
        [InlineData(0, 0, 0)]
        [InlineData(2, -2, 7)]
        public void GetArea_InputZeroLessOrEqualParam_GetTriangleNull(int ab, int bc, int ca)
        {
            ITriangleCalculation calculation = new TriangleCalculation();
            Figure figure = new(calculation);

            Assert.Null(figure.GetArea(new TriangleParam() { Ab = ab, Bc = bc, Ca = ca }));
        }
    }
}