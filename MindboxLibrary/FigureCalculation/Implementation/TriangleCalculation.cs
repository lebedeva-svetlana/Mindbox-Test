namespace Mindbox
{
    public class TriangleCalculation : ITriangleCalculation
    {
        public double? GetArea(IFigureParam param)
        {
            if (param is null)
            {
                return null;
            }

            if (param is not TriangleParam triangleParam || triangleParam.Ab <= 0 || triangleParam.Bc <= 0 || triangleParam.Ca <= 0)
            {
                return null;
            }

            double p = (triangleParam.Ab + triangleParam.Bc + triangleParam.Ca) / 2;
            return Math.Sqrt(p * (p - triangleParam.Ab) * (p - triangleParam.Bc) * (p - triangleParam.Ca));
        }

        public bool? IsRectangular(IFigureParam param)
        {
            if (param is null)
            {
                return null;
            }

            if (param is not TriangleParam triangleParam || triangleParam.Ab <= 0 || triangleParam.Bc <= 0 || triangleParam.Ca <= 0)
            {
                return null;
            }

            double bigSide;
            double[] smallSides = new double[2];

            if (triangleParam.Bc > triangleParam.Ab)
            {
                bigSide = triangleParam.Bc;
                smallSides[0] = triangleParam.Ab;
            }
            else
            {
                bigSide = triangleParam.Ab;
                smallSides[0] = triangleParam.Bc;
            }

            if (bigSide > triangleParam.Ca)
            {
                smallSides[1] = triangleParam.Ca;
            }
            else
            {
                smallSides[1] = bigSide;
                bigSide = triangleParam.Ca;
            }

            return (bigSide * bigSide) == (smallSides[0] * smallSides[0]) + (smallSides[1] * smallSides[1]);
        }
    }
}