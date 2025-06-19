using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static CurveSolution.FormGraph;

namespace CurveSolution
{
    class GraphDrawing
    {
        CalculationCoefficients coef;
        GraphCalc calc;
        double squareInPixels;
        string backgroundImage;
        public Bitmap Graph { get; private set; }
        public PictureBox HLine { get; private set; }
        public PictureBox VLine { get; private set; }
        public GraphDrawing(CalculationCoefficients coef, GraphCalc calc, string backgroundImage, PictureBox HLine, PictureBox VLine)
        {
            this.coef = coef;
            this.calc = calc;
            this.backgroundImage = backgroundImage;
            this.HLine = HLine;
            this.VLine = VLine;
            this.squareInPixels = calc.SquareInPixels;
            Graph = DrawField();
            if (coef.AStr * coef.CStr >= 0)
            {
                Graph = CreateGraph_Ellipse(Graph);
            }
            else
            {
                Graph = CreateGraph_Hyperbol(Graph, calc.X0InPixels, calc.Y0InPixels);
            }
        }
        /// <summary>
        /// Определяет тип кривой
        /// </summary>
        /// <returns>вид кривой(string)</returns>
        public string GetCurveType()
        {
            if (coef.AStr * coef.CStr >= 0)
            {
                return "Эллипс";
            }
            else
            {
                return "Гипербола";
            }
        }
        /// <summary>
        /// Генерирует изображение клеточного поля с осями координат
        /// </summary>
        /// <returns>Возвращает изображение клеточного поля с осями координат</returns>
        Bitmap DrawField()
        {
            Bitmap squareField = new Bitmap(backgroundImage);
            Bitmap squareFieldH = new Bitmap(backgroundImage);
            Bitmap squareFieldV = new Bitmap(backgroundImage);
            for (int y = 0; y < calc.Y0InPixels; y += 245)
            {
                for (int x = 0; x < calc.X0InPixels; x += 308)
                {
                    if (y == 0)
                    {
                        Bitmap temp;
                        temp = MergeImagesH(squareField, squareFieldV);
                        squareField = temp;
                        squareFieldH = temp;
                    }
                    else if (y != 0 && x == 0)
                    {
                        Bitmap temp;
                        temp = MergeImagesV(squareField, squareFieldH);
                        squareField = temp;
                    }
                }
            }
            DrawLines(squareField);

            return squareField;
        }
        /// <summary>
        /// Генерирует на изображении оси координат
        /// </summary>
        /// <param name="squareField">клеточное поле</param>
        void DrawLines(Bitmap squareField)
        {
            HLine.Height = 1;
            HLine.Width = squareField.Width;
            HLine.SizeMode = PictureBoxSizeMode.StretchImage;
            HLine.Location = new Point(0, calc.CenterY);
            VLine.Height = squareField.Height; ;
            VLine.Width = 1;
            VLine.SizeMode = PictureBoxSizeMode.StretchImage;
            VLine.Location = new Point(calc.CenterX, 0); 
        }
        /// <summary>
        /// Склеивает 2 изображения по вертикали
        /// </summary>
        /// <param name="img1">первое изображение</param>
        /// <param name="img2">второе изображение</param>
        /// <returns>Возвращает склеенное изображение</returns>
        private Bitmap MergeImagesV(Bitmap img1, Bitmap img2)
        {
            int width = Math.Max(img1.Width, img2.Width);
            int height = img1.Height + img2.Height;

            Bitmap result = new Bitmap(width, height);

            using (Graphics g = Graphics.FromImage(result))
            {
                g.DrawImage(img1, 0, 0);
                g.DrawImage(img2, 0, img1.Height);
            }

            return result;
        }
        /// <summary>
        /// Склеивает 2 изображения по горизонтали
        /// </summary>
        /// <param name="img1">первое изображение</param>
        /// <param name="img2">второе изображение</param>
        /// <returns>Возвращает склеенное изображение</returns>
        private Bitmap MergeImagesH(Bitmap img1, Bitmap img2)
        {
            int width = img1.Width + img2.Width;
            int height = Math.Max(img1.Height, img2.Height);

            Bitmap result = new Bitmap(width, height);

            using (Graphics g = Graphics.FromImage(result))
            {
                g.DrawImage(img1, 0, 0);
                g.DrawImage(img2, img1.Width, 0);
            }

            return result;
        }
        /// <summary>
        /// Генерирует на клеточном поле графиик эллипса
        /// </summary>
        /// <param name="squareField">клетоное поле</param>
        /// <returns>Возвращает клеточное поле с графиком эллипса</returns>
        Bitmap CreateGraph_Ellipse(Bitmap squareField)
        {
            Bitmap result = squareField;
            using (Graphics g = Graphics.FromImage(result))
            {
                for (double x = -coef.GraphA; x <= coef.GraphA; x += 0.001)
                {
                    for (double y = -coef.GraphB; y <= coef.GraphB; y += 0.001)
                    {
                        if (calc.IsEllipsePoint(x,y))
                        {
                            PointF drawLineStart = calc.PointForGraphDrawing(x,y);
                            PointF drawLineEnd = new PointF(drawLineStart.X + 0.1F, drawLineStart.Y + 0.1F);
                            g.DrawLine(new Pen(Color.Black, 3), drawLineStart, drawLineEnd);
                        }
                    }
                }
                g.DrawLine(new Pen(Color.Blue, 2), calc.PointForLineDrawing(true,true) , calc.PointForLineDrawing(true,false));
                g.DrawLine(new Pen(Color.Violet, 2), calc.PointForLineDrawing(false,true) , calc.PointForLineDrawing(false,false));
            }
            return result;
        }
        /// <summary>
        /// Генерирует на клеточном поле графиик гиперболы
        /// </summary>
        /// <param name="squareField">клетоное поле</param>
        /// <param name="x0InPixels">икс центра гиперболы в пикселях</param>
        /// <param name="y0InPixels">игрик центра гиперболы в пикселях</param>
        /// <returns>Возвращает клеточное поле с графиком гиперболы</returns>
        Bitmap CreateGraph_Hyperbol(Bitmap squareField, double x0InPixels, double y0InPixels)
        {
            Pen pen = new Pen(Color.Green, 2);
            Bitmap result = squareField;
            using (Graphics g = Graphics.FromImage(result))
            {
                if (coef.BigDelta != 0)
                {
                    if (calc.SignA > 0)
                    {
                        for (double x = -3 * coef.GraphA; x <= -coef.GraphA; x += 0.001)
                        {
                            for (double y = -3 * coef.GraphB; y <= 3 * coef.GraphB; y += 0.001)
                            {
                                if (calc.IsHyperbolPoint(x,y))
                                {
                                    PointF drawLineStart = calc.PointForGraphDrawing(x, y);
                                    PointF drawLineEnd = new PointF(drawLineStart.X + 0.1F, drawLineStart.Y + 0.1F);
                                    g.DrawLine(new Pen(Color.Black, 3), drawLineStart, drawLineEnd);
                                }
                            }
                        }
                        for (double x = coef.GraphA * coef.GraphA; x <= 3 * coef.GraphA; x += 0.001)
                        {
                            for (double y = -3 * coef.GraphB; y <= 3 * coef.GraphB; y += 0.001)
                            {
                                if (calc.IsHyperbolPoint(x, y))
                                {
                                    PointF drawLineStart = calc.PointForGraphDrawing(x, y);
                                    PointF drawLineEnd = new PointF(drawLineStart.X + 0.1F, drawLineStart.Y + 0.1F);
                                    g.DrawLine(new Pen(Color.Black, 3), drawLineStart, drawLineEnd);
                                }
                            }
                        }
                    }
                    else if (calc.SignC > 0)
                    {
                        for (double x = -3 * coef.GraphA; x <= 3 * coef.GraphA; x += 0.001)
                        {
                            for (double y = coef.GraphB; y <= 3 * coef.GraphB; y += 0.001)
                            {
                                if (calc.IsHyperbolPoint(x, y))
                                {
                                    PointF drawLineStart = calc.PointForGraphDrawing(x, y);
                                    PointF drawLineEnd = new PointF(drawLineStart.X + 0.1F, drawLineStart.Y + 0.1F);
                                    g.DrawLine(new Pen(Color.Black, 3), drawLineStart, drawLineEnd);
                                }
                            }
                        }
                        for (double x = -3 * coef.GraphA; x <= 3 * coef.GraphA; x += 0.001)
                        {
                            for (double y = -3 * coef.GraphB; y <= -coef.GraphB; y += 0.001)
                            {
                                if (calc.IsHyperbolPoint(x, y))
                                {
                                    PointF drawLineStart = calc.PointForGraphDrawing(x, y);
                                    PointF drawLineEnd = new PointF(drawLineStart.X + 0.1F, drawLineStart.Y + 0.1F);
                                    g.DrawLine(new Pen(Color.Black, 3), drawLineStart, drawLineEnd);
                                }
                            }
                        }
                    }
                }
                else
                {
                    pen = new Pen(Color.Black, 3);
                }
                g.DrawLine(new Pen(Color.Blue, 2), calc.PointForLineDrawing(true, true), calc.PointForLineDrawing(true, false));
                g.DrawLine(new Pen(Color.Violet, 2), calc.PointForLineDrawing(false,true) , calc.PointForLineDrawing(false,false));
                g.DrawLine(pen, calc.PointForAsymptoteLineDrawing(true, true), calc.PointForAsymptoteLineDrawing(true, false));
                g.DrawLine(pen, calc.PointForAsymptoteLineDrawing(false, true), calc.PointForAsymptoteLineDrawing(false, false));
            }
            return result;
        }
    }
}
