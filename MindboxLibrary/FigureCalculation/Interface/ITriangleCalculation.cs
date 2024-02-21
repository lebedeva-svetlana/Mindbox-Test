namespace Mindbox
{
    public interface ITriangleCalculation : IFigureCalculation
    {
        public bool? IsRectangular(IFigureParam param);
    }
}