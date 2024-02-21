namespace Mindbox
{
    public class Figure
    {
        private IFigureCalculation _calculation;

        public Figure(IFigureCalculation areaCalculation)
        {
            _calculation = areaCalculation;
        }

        public double? GetArea(IFigureParam figureParam)
        {
            return _calculation.GetArea(figureParam);
        }
    }
}