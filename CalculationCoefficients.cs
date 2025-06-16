using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace CurveSolution
{
    public partial class FormGraph
    {
        public class CalculationCoefficients
        {
            public double A { get; private set; }
            public double B { get; private set; }
            public double C { get; private set; }
            public double D { get; private set; }
            public double E { get; private set; }
            public double F { get; private set; }
            public double S { get; private set; }
            public double Delta { get; private set; }
            public double BigDelta { get; private set; }
            public double TgAlpha { get; private set; }
            public double SinAlpha { get; private set; }
            public double CosAlpha { get; private set; }
            public double AStr { get; private set; }
            public double FStr { get; private set; }
            public double CStr { get; private set; }
            public double X0 { get; private set; }
            public double Y0 { get; private set; }
            public double GraphA { get; private set; }
            public double GraphB { get; private set; }
            public double GraphAInSquare { get; private set; }
            public double GraphBInSquare { get; private set; }
            public CalculationCoefficients(string[] coefficients)
            {
                A = Convert.ToDouble(coefficients[0]);
                B = Convert.ToDouble(coefficients[1]);
                C = Convert.ToDouble(coefficients[2]);
                D = Convert.ToDouble(coefficients[3]);
                E = Convert.ToDouble(coefficients[4]);
                F = Convert.ToDouble(coefficients[5]);
                Calculate();
            }
            void Calculate()
            {
                S = A + C;
                Delta = A * C - B * B;
                BigDelta = A * C * F - C * D * D + 2 * D * B * E - F * B * B - A * E * E;
                TgAlpha = Math.Max((C - A + Math.Sqrt((C - A) * (C - A) - 4 * B * (-B))) / (2 * B), (C - A - Math.Sqrt((C - A) * (C - A) - 4 * B * (-B))) / (2 * B));
                SinAlpha = TgAlpha / (Math.Sqrt(1 + TgAlpha * TgAlpha));
                CosAlpha = 1 / (Math.Sqrt(1 + TgAlpha * TgAlpha));
                if (Delta != 0)
                {
                    X0 = (C * D - B * E) / (B * B - A * C);
                    Y0 = (-D - A * X0) / B;
                    FStr = BigDelta / Delta;
                    AStr = (-S + Math.Sqrt(S * S - 4 * Delta)) / 2;
                    if (AStr == B * TgAlpha + A)
                    {
                        CStr = (-S - Math.Sqrt(S * S - 4 * Delta)) / 2;
                    }
                    else
                    {
                        CStr = AStr;
                        AStr = (-S - Math.Sqrt(S * S - 4 * Delta)) / 2;
                    } 
                }
                GraphAInSquare = Math.Abs(FStr / AStr);
                GraphBInSquare = Math.Abs(FStr / CStr);
                if (Delta == 0)
                {
                    GraphAInSquare = Math.Abs(CStr);
                    GraphBInSquare = Math.Abs(AStr);
                }
                GraphA = Math.Sqrt(GraphAInSquare);
                GraphB = Math.Sqrt(GraphBInSquare);
            }
        }
    }
}
