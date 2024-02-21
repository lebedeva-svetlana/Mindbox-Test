namespace MindboxTest
{
    public class CircleCalculationTest
    {
        public static IEnumerable<object[]> CircleData =>
            new List<object[]>
            {
            new object[] { new CircleParam() { Radius = 10 }, 314 },
            new object[] { new CircleParam() { Radius = 5.6 }, 99 }
            };

        [Theory, MemberData(nameof(CircleData))]
        public void GetArea_InputNotNullParam_GetCircleArea(CircleParam param, int result)
        {
            ICircleCalculation calculation = new CircleCalculation();
            Figure figure = new(calculation);

            Assert.Equal(Math.Round((double)figure.GetArea(param)), result);
        }

        [Fact]
        public void GetArea_InputNullParam_GetCircleNull()
        {
            ICircleCalculation calculation = new CircleCalculation();
            Figure figure = new(calculation);

            Assert.Null(figure.GetArea(null));
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-2)]
        public void GetArea_InputZeroLessOrEqualParam_GetCircleNull(int param)
        {
            ICircleCalculation calculation = new CircleCalculation();
            Figure figure = new(calculation);

            Assert.Null(figure.GetArea(new CircleParam() { Radius = param }));
        }
    }
}