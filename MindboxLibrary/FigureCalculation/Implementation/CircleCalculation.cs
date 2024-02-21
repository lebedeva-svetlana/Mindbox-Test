namespace Mindbox
{
    public class CircleCalculation : ICircleCalculation
    {
        public double? GetArea(IFigureParam param)
        {
            if (param is null)
            {
                return null;
            }

            if (param is not CircleParam circleParam || circleParam.Radius <= 0)
            {
                return null;
            }

            return Math.PI * (circleParam.Radius * circleParam.Radius);
        }
    }
}