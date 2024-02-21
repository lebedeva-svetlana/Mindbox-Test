using Mindbox;

var figureCalculation1 = FigureHelper.GetFigureCalculation("circle");
var figureParam1 = FigureHelper.GetFigureParam(figureCalculation1, new(string, object)[] { ("radius", "20") });

var figureCalculation2 = FigureHelper.GetFigureCalculation("triangle");
var figureParam2 = FigureHelper.GetFigureParam(figureCalculation2, new (string, object)[] { ("ab", "3"), ("bc", "4"), ("ca", "5") });

Figure calculation1 = new(figureCalculation1);
Figure calculation2 = new(figureCalculation2);

Console.WriteLine(calculation1.GetArea(figureParam1));
Console.WriteLine(calculation2.GetArea(figureParam2));

Console.WriteLine((figureCalculation2 as TriangleCalculation).IsRectangular(figureParam2));