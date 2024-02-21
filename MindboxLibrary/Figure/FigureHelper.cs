using System.Globalization;
using System.Reflection;

namespace Mindbox
{
    public class FigureHelper
    {
        public static IFigureCalculation? GetFigureCalculation(string figureName)
        {
            if (figureName is null)
            {
                return null;
            }

            TextInfo cultureInfo = new CultureInfo("en-US", false).TextInfo;
            string normalizeFigureName = cultureInfo.ToTitleCase(figureName);
            var type = Type.GetType($"{typeof(FigureHelper).Namespace}.{normalizeFigureName}Calculation");

            if (type is null)
            {
                return null;
            }

            return (IFigureCalculation)Activator.CreateInstance(type);
        }

        public static IFigureParam? GetFigureParam(IFigureCalculation calculation, params (string paramName, object value)[] figureParams)
        {
            if (calculation is null || figureParams.Length == 0)
            {
                return null;
            }

            string figureCalcuationString = calculation.GetType().ToString();
            string figureName = figureCalcuationString.Replace($"{typeof(FigureHelper).Namespace}.", "");
            figureName = figureName.Replace("Calculation", "");
            if (figureName[0] == 'I')
            {
                figureName = figureName[1..];
            }

            var paramType = Type.GetType($"{typeof(FigureHelper).Namespace}.{figureName}Param");
            if (paramType is null)
            {
                return null;
            }

            var figureParam = (IFigureParam)Activator.CreateInstance(paramType);

            if (figureParam is null)
            {
                return null;
            }

            TextInfo cultureInfo = new CultureInfo("en-US", false).TextInfo;
            for (int i = 0; i < figureParams.Length; ++i)
            {
                if (string.IsNullOrEmpty(figureParams[i].paramName))
                {
                    continue;
                }

                string normalizeParamName = cultureInfo.ToTitleCase(figureParams[i].paramName);
                PropertyInfo? property = paramType.GetProperty(normalizeParamName);

                if (property is null)
                {
                    continue;
                }

                var value = figureParams[i].value;
                value = Convert.ChangeType(value, property.PropertyType);

                property.SetValue(figureParam, value);
            }

            return figureParam;
        }
    }
}