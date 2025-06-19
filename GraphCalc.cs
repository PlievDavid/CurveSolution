using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurveSolution
{
    public partial class FormGraph
    {
        public class GraphCalc
        {
            public int SignA { get; private set; }
            public int SignC { get; private set; }
            int lineLength = 3;
            CalculationCoefficients coef;
            //клетка = 17 пикселей
            public double SquareInPixels { get; private set; }
            //координаты центра графика кривой
            public double X0InPixels { get; private set; }
            public double Y0InPixels { get; private set; }
            //координаты пересечения осей Х и У
            public int CenterX { get; private set; }
            public int CenterY { get; private set; }
            public GraphCalc(CalculationCoefficients coef)
            {
                CenterX = 328;
                CenterY = 245;
                SquareInPixels = 17;
                this.coef = coef;
                SignA = Math.Sign(coef.FStr / coef.AStr);
                SignC = Math.Sign(coef.FStr / coef.CStr);
                X0InPixels = coef.X0 * SquareInPixels + CenterX;
                Y0InPixels = -coef.Y0 * SquareInPixels + CenterY;
                if (X0InPixels < CenterX)
                {
                    int temp = CenterX;
                    CenterX += Math.Abs(CenterX * (int)(CenterX / X0InPixels)) + 1;
                    X0InPixels += CenterX;
                    X0InPixels -= temp;
                }
                if (Y0InPixels < CenterY)
                {
                    int temp = CenterY;
                    CenterY += Math.Abs(CenterY * (int)(CenterY / Y0InPixels)) + 3;
                    Y0InPixels += CenterY;
                    Y0InPixels -= temp;
                }
            }
            /// <summary>
            /// Определяет лежит ли точка на графике эллипса
            /// </summary>
            /// <param name="x">иксовая координата в неполярной системе</param>
            /// <param name="y">игриковая координата в неполярной системе</param>
            /// <returns>истина, если лежит на эллипсе, ложь в противном случае</returns>
            public bool IsEllipsePoint(double x, double y)
            {
                if ((0.999 <= ((x * x) / coef.GraphAInSquare + (y * y) / coef.GraphBInSquare)) && (((x * x) / coef.GraphAInSquare + (y * y) / coef.GraphBInSquare) <= 1.001))
                    return true;
                return false;
            }
            /// <summary>
            /// Определяет лежит ли точка на графике гиперболы
            /// </summary>
            /// <param name="x">иксовая координата в неполярной системе</param>
            /// <param name="y">игриковая координата в неполярной системе</param>
            /// <returns>истина, если лежит на гиперболе, ложь в противном случае</returns>
            public bool IsHyperbolPoint(double x, double y)
            {
                if ((0.99 <= ((x * x) / coef.GraphAInSquare * SignA + (y * y) / coef.GraphBInSquare * SignC)) && (((x * x) / coef.GraphAInSquare * SignA + (y * y) / coef.GraphBInSquare * SignC) <= 1.01))
                    return true;
                return false;
            }
            /// <summary>
            /// Определяет координаты точки графика, используя афинные преобразования
            /// </summary>
            /// <param name="x">иксовая координата в неполярной системе</param>
            /// <param name="y">игриковая координата в неполярной системе</param>
            /// <returns>точку(PointF)</returns>
            public PointF PointForGraphDrawing(double x, double y)
            {
                return new PointF((float)((x * coef.CosAlpha + y * coef.SinAlpha) * SquareInPixels + X0InPixels), (float)((-x * coef.SinAlpha + y * coef.CosAlpha) * SquareInPixels + Y0InPixels));
            }
            /// <summary>
            /// Определяет координаты точек для построения наклонных осей координат
            /// </summary>
            /// <returns>точку(PointF)</returns>
            public PointF PointForLineDrawing(bool IsXLine, bool IsStart)
            {
                int sign = -1;
                PointF point;
                if (IsStart)
                {
                    sign = 1;
                }
                if (IsXLine)
                    point = new PointF((float)(sign * (lineLength * coef.GraphA * coef.CosAlpha + 0 * coef.SinAlpha) * SquareInPixels + X0InPixels), (float)(sign * (-lineLength * coef.GraphA * coef.SinAlpha + 0 * coef.CosAlpha) * SquareInPixels + Y0InPixels));
                else
                {
                    if (coef.AStr * coef.CStr >= 0)
                        point = new PointF((float)(sign * (0 * coef.CosAlpha + lineLength * coef.GraphB * coef.SinAlpha) * SquareInPixels + X0InPixels), (float)(sign * (0 * coef.CosAlpha + lineLength * coef.GraphB * coef.SinAlpha) * SquareInPixels + Y0InPixels));
                    else
                        point = new PointF((float)((0 * coef.CosAlpha - sign * lineLength * coef.GraphB * coef.SinAlpha) * SquareInPixels + X0InPixels), (float)(-(0 * coef.SinAlpha + sign * lineLength * coef.GraphB * coef.CosAlpha) * SquareInPixels + Y0InPixels));
                }
                return point;
            }
            /// <summary>
            /// Определяет координаты точек для построения наклонных асимптот графика
            /// </summary>
            /// <returns>точку(PointF)</returns>
            public PointF PointForAsymptoteLineDrawing(bool IsUpRisingLine, bool IsStart)
            {
                int sign = -1;
                PointF point;
                if (IsStart)
                {
                    sign = 1;
                }
                if (IsUpRisingLine)
                    point = new PointF((float)((sign * lineLength * coef.GraphA * coef.CosAlpha - sign * lineLength * coef.GraphB * coef.SinAlpha) * SquareInPixels + X0InPixels), (float)(-sign * (lineLength * coef.GraphA * coef.SinAlpha + lineLength * coef.GraphB * coef.CosAlpha) * SquareInPixels + Y0InPixels));
                else
                    point = new PointF((float)(-sign * (lineLength * coef.GraphA * coef.CosAlpha + lineLength * coef.GraphB * coef.SinAlpha) * SquareInPixels + X0InPixels), (float)(sign * (lineLength * coef.GraphA * coef.SinAlpha -  lineLength * coef.GraphB * coef.CosAlpha) * SquareInPixels + Y0InPixels));
                return point;
            }
        }
    }
}
