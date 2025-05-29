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
        double squareInPixels;
        string backgroundImage;
        public Bitmap Graph { get; set; }
        public PictureBox HLine { get; set; }
        public PictureBox VLine { get; set; }
        public GraphDrawing(CalculationCoefficients cf, int centerX, int centerY, double x0InPixels, double y0InPixels, string backgroundImage, PictureBox line, PictureBox line2, double squareInPixels)
        {
            coef = cf;
            this.backgroundImage = backgroundImage;
            HLine = line;
            VLine = line2;
            this.squareInPixels = squareInPixels;
            Graph = DrawField(centerX, centerY, x0InPixels, y0InPixels);
            if (coef.AStr * coef.CStr >= 0)
            {
                Graph = CreateGraph_Ellipse(Graph, x0InPixels, y0InPixels);
            }
            else
            {
                Graph = CreateGraph_Hyperbol(Graph, x0InPixels, y0InPixels, Math.Sign(coef.FStr / coef.AStr), Math.Sign(coef.FStr / coef.CStr));
            }
        }
        /// <summary>
        /// Генерирует изображение клеточного поля с осями координат
        /// </summary>
        /// <param name="centerX">иксовая координата центра осей</param>
        /// <param name="centerY">игриковая координата центра осей </param>
        /// <param name="endX">до каких пор генерировать изображение по икс</param>
        /// <param name="endY">до каких пор генерировать изображение по игрик</param>
        /// <returns>Возвращает изображение клеточного поля с осями координат</returns>
        Bitmap DrawField(int centerX, int centerY, double endX, double endY)
        {
            Bitmap squareField = new Bitmap(backgroundImage);
            Bitmap squareFieldH = new Bitmap(backgroundImage);
            Bitmap squareFieldV = new Bitmap(backgroundImage);
            for (int y = 0; y < endY; y += 245)
            {
                for (int x = 0; x < endX; x += 308)
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
            DrawLines(squareField, centerX, centerY);

            return squareField;
        }
        /// <summary>
        /// Генерирует на изображении оси координат
        /// </summary>
        /// <param name="squareField">клеточное поле</param>
        /// <param name="centerX">иксовая координата центра осей</param>
        /// <param name="centerY">игриковая координата центра осей</param>
        void DrawLines(Bitmap squareField, int centerX, int centerY)
        {
            HLine.Height = 1;
            HLine.Width = squareField.Width;
            HLine.SizeMode = PictureBoxSizeMode.StretchImage;
            HLine.Location = new Point(0, centerY);
            VLine.Height = squareField.Height; ;
            VLine.Width = 1;
            VLine.SizeMode = PictureBoxSizeMode.StretchImage;
            VLine.Location = new Point(centerX, 0); 
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
        Bitmap CreateGraph_Ellipse(Bitmap squareField, double x0InPixels, double y0InPixels)
        {
            Bitmap result = squareField;
            using (Graphics g = Graphics.FromImage(result))
            {
                for (double x = -coef.GraphA; x <= coef.GraphA; x += 0.001)
                {
                    for (double y = -coef.GraphB; y <= coef.GraphB; y += 0.001)
                    {
                        if ((0.999 <= ((x * x) / coef.GraphAInSquare + (y * y) / coef.GraphBInSquare)) && (((x * x) / coef.GraphAInSquare + (y * y) / coef.GraphBInSquare) <= 1.001))
                        {
                            g.DrawLine(new Pen(Color.Black, 3), new PointF((float)((x * coef.CosAlpha + y * coef.SinAlpha) * squareInPixels + x0InPixels), (float)((-x * coef.SinAlpha + y * coef.CosAlpha) * squareInPixels + y0InPixels)), new PointF((float)((x * coef.CosAlpha + y * coef.SinAlpha) * squareInPixels + x0InPixels + 0.1), (float)((-x * coef.SinAlpha + y * coef.CosAlpha) * squareInPixels + y0InPixels + 0.1)));
                        }
                    }
                }
                g.DrawLine(new Pen(Color.Blue, 2), new PointF((float)((3 * coef.GraphA * coef.CosAlpha + 0 * coef.SinAlpha) * squareInPixels + x0InPixels), (float)((-3 * coef.GraphA * coef.SinAlpha + 0 * coef.CosAlpha) * squareInPixels + y0InPixels)), new PointF((float)((-3 * coef.GraphA * coef.CosAlpha + 0 * coef.SinAlpha) * squareInPixels + x0InPixels), (float)((3 * coef.GraphA * coef.SinAlpha + 0 * coef.CosAlpha) * squareInPixels + y0InPixels)));
                g.DrawLine(new Pen(Color.Violet, 2), new PointF((float)((0 * coef.CosAlpha + 3 * coef.GraphB * coef.SinAlpha) * squareInPixels + x0InPixels), (float)((-0 * coef.SinAlpha + 3 * coef.GraphB * coef.CosAlpha) * squareInPixels + y0InPixels)), new PointF((float)((0 * coef.CosAlpha - 3 * coef.GraphB * coef.SinAlpha) * squareInPixels + x0InPixels), (float)((-0 * coef.SinAlpha - 3 * coef.GraphB * coef.CosAlpha) * squareInPixels + y0InPixels)));
            }
            return result;
        }
        /// <summary>
        /// Генерирует на клеточном поле графиик гиперболы
        /// </summary>
        /// <param name="squareField">клетоное поле</param>
        /// <param name="x0InPixels">икс центра гиперболы в пикселях</param>
        /// <param name="y0InPixels">игрик центра гиперболы в пикселях</param>
        /// <param name="signA">знак коэффицента А</param>
        /// <param name="signC">знак коэффицента С</param>
        /// <returns>Возвращает клеточное поле с графиком гиперболы</returns>
        Bitmap CreateGraph_Hyperbol(Bitmap squareField, double x0InPixels, double y0InPixels, int signA, int signC)
        {
            Pen pen = new Pen(Color.Green, 2);
            Bitmap result = squareField;
            using (Graphics g = Graphics.FromImage(result))
            {
                if (coef.BigDelta != 0)
                {
                    if (signA > 0)
                    {
                        for (double x = -3 * coef.GraphA; x <= -coef.GraphA; x += 0.001)
                        {
                            for (double y = -3 * coef.GraphB; y <= 3 * coef.GraphB; y += 0.001)
                            {
                                if ((0.999 <= ((x * x) / coef.GraphAInSquare * signA + (y * y) / coef.GraphBInSquare * signC)) && (((x * x) / coef.GraphAInSquare * signA + (y * y) / coef.GraphBInSquare * signC) <= 1.001))
                                {
                                    g.DrawLine(new Pen(Color.Black, 3), new PointF((float)((x * coef.CosAlpha + y * coef.SinAlpha) * squareInPixels + x0InPixels), (float)((-x * coef.SinAlpha + y * coef.CosAlpha) * squareInPixels + y0InPixels)), new PointF((float)((x * coef.CosAlpha + y * coef.SinAlpha) * squareInPixels + x0InPixels + 0.1), (float)((-x * coef.SinAlpha + y * coef.CosAlpha) * squareInPixels + y0InPixels + 0.1)));
                                }
                            }
                        }
                        for (double x = coef.GraphA * coef.GraphA; x <= 3 * coef.GraphA; x += 0.001)
                        {
                            for (double y = -3 * coef.GraphB; y <= 3 * coef.GraphB; y += 0.001)
                            {
                                if ((0.999 <= ((x * x) / coef.GraphAInSquare * signA + (y * y) / coef.GraphBInSquare * signC)) && (((x * x) / coef.GraphAInSquare * signA + (y * y) / coef.GraphBInSquare * signC) <= 1.001))
                                {
                                    g.DrawLine(new Pen(Color.Black, 3), new PointF((float)((x * coef.CosAlpha + y * coef.SinAlpha) * squareInPixels + x0InPixels), (float)((-x * coef.SinAlpha + y * coef.CosAlpha) * squareInPixels + y0InPixels)), new PointF((float)((x * coef.CosAlpha + y * coef.SinAlpha) * squareInPixels + x0InPixels + 0.1), (float)((-x * coef.SinAlpha + y * coef.CosAlpha) * squareInPixels + y0InPixels + 0.1)));
                                }
                            }
                        }
                    }
                    else if (signC > 0)
                    {
                        for (double x = -3 * coef.GraphA; x <= 3 * coef.GraphA; x += 0.001)
                        {
                            for (double y = coef.GraphB; y <= 3 * coef.GraphB; y += 0.001)
                            {
                                if ((0.999 <= ((x * x) / coef.GraphAInSquare * signA + (y * y) / coef.GraphBInSquare * signC)) && (((x * x) / coef.GraphAInSquare * signA + (y * y) / coef.GraphBInSquare * signC) <= 1.001))
                                {
                                    g.DrawLine(new Pen(Color.Black, 3), new PointF((float)((x * coef.CosAlpha + y * coef.SinAlpha) * squareInPixels + x0InPixels), (float)((-x * coef.SinAlpha + y * coef.CosAlpha) * squareInPixels + y0InPixels)), new PointF((float)((x * coef.CosAlpha + y * coef.SinAlpha) * squareInPixels + x0InPixels + 0.1), (float)((-x * coef.SinAlpha + y * coef.CosAlpha) * squareInPixels + y0InPixels + 0.1)));
                                }
                            }
                        }
                        for (double x = -3 * coef.GraphA; x <= 3 * coef.GraphA; x += 0.001)
                        {
                            for (double y = -3 * coef.GraphB; y <= -coef.GraphB; y += 0.001)
                            {
                                if ((0.999 <= ((x * x) / coef.GraphAInSquare * signA + (y * y) / coef.GraphBInSquare * signC)) && (((x * x) / coef.GraphAInSquare * signA + (y * y) / coef.GraphBInSquare * signC) <= 1.001))
                                {
                                    g.DrawLine(new Pen(Color.Black, 3), new PointF((float)((x * coef.CosAlpha + y * coef.SinAlpha) * squareInPixels + x0InPixels), (float)((-x * coef.SinAlpha + y * coef.CosAlpha) * squareInPixels + y0InPixels)), new PointF((float)((x * coef.CosAlpha + y * coef.SinAlpha) * squareInPixels + x0InPixels + 0.1), (float)((-x * coef.SinAlpha + y * coef.CosAlpha) * squareInPixels + y0InPixels + 0.1)));
                                }
                            }
                        }
                    }
                }
                else
                {
                    pen = new Pen(Color.Black, 3);
                }
                g.DrawLine(new Pen(Color.Blue, 2), new PointF((float)((3 * coef.GraphA * coef.CosAlpha - 0 * coef.SinAlpha) * squareInPixels + x0InPixels), (float)(-(3 * coef.GraphA * coef.SinAlpha + 0 * coef.CosAlpha) * squareInPixels + y0InPixels)), new PointF((float)((-3 * coef.GraphA * coef.CosAlpha - 0 * coef.SinAlpha) * squareInPixels + x0InPixels), (float)(-(-3 * coef.GraphA * coef.SinAlpha + 0 * coef.CosAlpha) * squareInPixels + y0InPixels)));
                g.DrawLine(new Pen(Color.Violet, 2), new PointF((float)((0 * coef.CosAlpha - 3 * coef.GraphB * coef.SinAlpha) * squareInPixels + x0InPixels), (float)(-(0 * coef.SinAlpha + 3 * coef.GraphB * coef.CosAlpha) * squareInPixels + y0InPixels)), new PointF((float)((0 * coef.CosAlpha - -3 * coef.GraphB * coef.SinAlpha) * squareInPixels + x0InPixels), (float)(-(0 * coef.SinAlpha - 3 * coef.GraphB * coef.CosAlpha) * squareInPixels + y0InPixels)));
                g.DrawLine(pen, new PointF((float)((3 * coef.GraphA * coef.CosAlpha - 3 * coef.GraphB * coef.SinAlpha) * squareInPixels + x0InPixels), (float)(-(3 * coef.GraphA * coef.SinAlpha + 3 * coef.GraphB * coef.CosAlpha) * squareInPixels + y0InPixels)), new PointF((float)((-3 * coef.GraphA * coef.CosAlpha - -3 * coef.GraphB * coef.SinAlpha) * squareInPixels + x0InPixels), (float)(-(-3 * coef.GraphA * coef.SinAlpha + -3 * coef.GraphB * coef.CosAlpha) * squareInPixels + y0InPixels)));
                g.DrawLine(pen, new PointF((float)((-3 * coef.GraphA * coef.CosAlpha - 3 * coef.GraphB * coef.SinAlpha) * squareInPixels + x0InPixels), (float)(-(-3 * coef.GraphA * coef.SinAlpha + 3 * coef.GraphB * coef.CosAlpha) * squareInPixels + y0InPixels)), new PointF((float)((3 * coef.GraphA * coef.CosAlpha - -3 * coef.GraphB * coef.SinAlpha) * squareInPixels + x0InPixels), (float)(-(3 * coef.GraphA * coef.SinAlpha + -3 * coef.GraphB * coef.CosAlpha) * squareInPixels + y0InPixels)));
            }
            return result;
        }
    }
}
