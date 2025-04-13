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
    public partial class FormGraph : Form
    {
        //клетка = 17 пикселей
        double squareInPixels = 17;
        public FormGraph()
        {
            InitializeComponent();
        }
        public PictureBox Field = new PictureBox();
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
            Bitmap squareField = new Bitmap("Images/squareField.jpg");
            Bitmap squareFieldH = new Bitmap("Images/squareField.jpg");
            Bitmap squareFieldV = new Bitmap("Images/squareField.jpg");
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
            PictureBox hLine = new PictureBox();
            hLine.Load("Images/redSquare.png");
            hLine.Height = 1;
            hLine.Width = squareField.Width;
            hLine.SizeMode = PictureBoxSizeMode.StretchImage;
            hLine.Location = new Point(0, centerY);
            panelGraph.Controls.Add(hLine);
            hLine.BringToFront();
            PictureBox vLine = new PictureBox();
            vLine.Load("Images/redSquare.png");
            vLine.Height = squareField.Height; ;
            vLine.Width = 1;
            vLine.SizeMode = PictureBoxSizeMode.StretchImage;
            vLine.Location = new Point(centerX, 0);
            panelGraph.Controls.Add(vLine);
            vLine.BringToFront();
        }
        /// <summary>
        /// Склеивает 2 изображения по вертикали
        /// </summary>
        /// <param name="img1">первое изображение</param>
        /// <param name="img2">второе изображение</param>
        /// <returns>Возвращает склеенное изображение</returns>
        private static Bitmap MergeImagesV(Bitmap img1, Bitmap img2)
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
        private static Bitmap MergeImagesH(Bitmap img1, Bitmap img2)
        {
            int width = img1.Width + img2.Width;
            int height = Math.Max(img1.Height,img2.Height);

            Bitmap result = new Bitmap(width, height);

            using (Graphics g = Graphics.FromImage(result))
            {
                g.DrawImage(img1, 0, 0);
                g.DrawImage(img2, img1.Width, 0);
            }

            return result;
        }

        private void FormGraph_Load(object sender, EventArgs e)
        {
            StreamReader file = new StreamReader("data/graph.txt");
            string[] coefficients = file.ReadLine().Split();
            file.Close();
            double A = Convert.ToDouble(coefficients[0]);
            double B = Convert.ToDouble(coefficients[1]);
            double C = Convert.ToDouble(coefficients[2]);
            double D = Convert.ToDouble(coefficients[3]);
            double E = Convert.ToDouble(coefficients[4]);
            double F = Convert.ToDouble(coefficients[5]);
            double x0 = 0;
            double y0 = 0;
            double S = A + C;
            double delta = A * C - B * B;
            double Delta = A * C * F - C * D * D + 2 * D * B * E - F * B * B - A * E * E;
            double tgAlpha = Math.Max((C - A + Math.Sqrt((C - A) * (C - A) - 4 * B * (-B))) / (2 * B), (C - A - Math.Sqrt((C - A) * (C - A) - 4 * B * (-B))) / (2 * B));
            double sinAlpha = tgAlpha / (Math.Sqrt(1 + tgAlpha * tgAlpha));
            double cosAlpha = 1 / (Math.Sqrt(1 + tgAlpha * tgAlpha));
            double AStr = 0;
            double FStr = 0;
            double CStr = 0;
            if (delta != 0)
            {
                x0 = (C * D - B * E) / (B * B - A * C);
                y0 = (-D - A * x0) / B;
                FStr = Delta / delta;
                AStr = (-S + Math.Sqrt(S * S - 4 * delta)) / 2;
                if (AStr == B * tgAlpha + A)
                {
                    CStr = (-S - Math.Sqrt(S * S - 4 * delta)) / 2;
                }
                else
                {
                    CStr = AStr;
                    AStr = (-S - Math.Sqrt(S * S - 4 * delta)) / 2;
                } 
            }
            int centerX = 328;
            int centerY = 245;
            double x0InPixels = x0 * squareInPixels + centerX;
            double y0InPixels = -y0 * squareInPixels + centerY;
            double aInSquare = Math.Abs(FStr / AStr);
            double bInSquare = Math.Abs(FStr / CStr);
            if (Delta==0)
            {
                aInSquare = Math.Abs(CStr);
                bInSquare = Math.Abs(AStr);
            }
            double a = Math.Sqrt(aInSquare);
            double b = Math.Sqrt(bInSquare);


            if (x0InPixels<centerX)
            {
                int temp = centerX;
                centerX += Math.Abs(centerX * (int)(centerX/x0InPixels))+1;
                x0InPixels += centerX;
                x0InPixels -= temp;
            }
            if (y0InPixels < centerY)
            {
                int temp = centerY;
                centerY += Math.Abs(centerY * (int)(centerY/y0InPixels))+3;
                y0InPixels += centerY;
                y0InPixels -= temp;
            }
            Bitmap squareField = DrawField(centerX, centerY, x0InPixels, y0InPixels);
            if (AStr * CStr >= 0)
            {
                Bitmap result = CreateGraph_Ellipse(squareField, x0InPixels, y0InPixels, sinAlpha, cosAlpha, a, b, aInSquare, bInSquare);
                LoadCurve(result);
            }
            else
            {

                Bitmap result = CreateGraph_Hyperbol(squareField, x0InPixels, y0InPixels, sinAlpha, cosAlpha, a, b, aInSquare, bInSquare,Math.Sign(FStr/AStr), Math.Sign(FStr / CStr),Delta);
                LoadCurve(result);
            }
            
            panelGraph.Controls.Add(Field);
            labelAphineX.Text = "x = x' * " + cosAlpha.ToString() + " - y' * " + sinAlpha.ToString() + " + " + x0.ToString();
            labelAphineY.Text = "y = x' * " + sinAlpha.ToString() + " + y' * " + cosAlpha.ToString() + " + " + y0.ToString();
            labelA2.Text = ((float)aInSquare).ToString();
            labelB2.Text = ((float)bInSquare).ToString();
            if (Math.Sign(FStr / AStr) > 0)
            {
                labelSignA.Text = "";
            }
            else
                labelSignA.Text = "-";
            if (Math.Sign(FStr / CStr) > 0)
            {
                labelSignB.Text = "+";
            }
            else
                labelSignB.Text = "-";
        }
        /// <summary>
        /// Отображает клеточное поле с графиком
        /// </summary>
        /// <param name="result">клеточное поле с графиком</param>
        void LoadCurve(Bitmap result)
        {
            Field.Image = result;
            Field.Width = result.Width;
            Field.Height = result.Height;
            Field.SizeMode = PictureBoxSizeMode.StretchImage;
            Field.Location = new Point(0, 0);
            Field.SendToBack();
        }
        /// <summary>
        /// Генерирует на клеточном поле графиик эллипса
        /// </summary>
        /// <param name="squareField">клетоное поле</param>
        /// <param name="x0InPixels">икс центра эллипса в пикселях</param>
        /// <param name="y0InPixels">игрик центра эллипса в пикселях</param>
        /// <param name="sinAlpha">синус альфа</param>
        /// <param name="cosAlpha">косинус альфа</param>
        /// <param name="a">ширина эллипса</param>
        /// <param name="b">высота эллипса</param>
        /// <param name="aInSquare">квадрат ширины эллипса</param>
        /// <param name="bInSquare">квадрат высоты эллипса</param>
        /// <returns>Возвращает клеточное поле с графиком эллипса</returns>
        Bitmap CreateGraph_Ellipse(Bitmap squareField, double x0InPixels, double y0InPixels, double sinAlpha, double cosAlpha, double a, double b, double aInSquare, double bInSquare)
        {
            Bitmap result = squareField;
            using (Graphics g = Graphics.FromImage(result))
            {
                for (double x = -a; x <= a; x+=0.001)
                {
                    for (double y = -b; y <= b; y+=0.001)
                    {
                        if ((0.999 <= ((x * x) / aInSquare + (y * y) / bInSquare)) && (((x * x) / aInSquare + (y * y) / bInSquare) <= 1.001))
                        {
                            g.DrawLine(new Pen(Color.Black,3),new PointF((float)((x * cosAlpha + y * sinAlpha)*squareInPixels + x0InPixels), (float)((- x * sinAlpha + y * cosAlpha) * squareInPixels + y0InPixels)),new PointF((float)(( x * cosAlpha + y * sinAlpha) * squareInPixels + x0InPixels + 0.1), (float)((- x * sinAlpha + y * cosAlpha) * squareInPixels + y0InPixels + 0.1)));
                        }
                    }
                }
                g.DrawLine(new Pen(Color.Blue, 2), new PointF((float)((3*a * cosAlpha + 0 * sinAlpha) * squareInPixels + x0InPixels), (float)((-3 * a * sinAlpha + 0 * cosAlpha) * squareInPixels + y0InPixels)), new PointF((float)((-3 * a * cosAlpha + 0 * sinAlpha) * squareInPixels + x0InPixels), (float)((3 * a * sinAlpha + 0 * cosAlpha) * squareInPixels + y0InPixels)));
                g.DrawLine(new Pen(Color.Violet, 2), new PointF((float)(( 0 * cosAlpha + 3 * b * sinAlpha) * squareInPixels + x0InPixels), (float)((-0 * sinAlpha + 3 * b * cosAlpha) * squareInPixels + y0InPixels)), new PointF((float)((0 * cosAlpha - 3 * b * sinAlpha) * squareInPixels + x0InPixels), (float)((- 0 * sinAlpha - 3 * b * cosAlpha) * squareInPixels + y0InPixels)));
            }
            return result;
        }
        /// <summary>
        /// Генерирует на клеточном поле графиик гиперболы
        /// </summary>
        /// <param name="squareField">клетоное поле</param>
        /// <param name="x0InPixels">икс центра гиперболы в пикселях</param>
        /// <param name="y0InPixels">игрик центра гиперболы в пикселях</param>
        /// <param name="sinAlpha">синус альфа</param>
        /// <param name="cosAlpha">косинус альфа</param>
        /// <param name="a">ширина прямоугольника, диагонали которого являются ассимптотами гиперболы </param>
        /// <param name="b">высота прямоугольника, диагонали которого являются ассимптотами гиперболы</param>
        /// <param name="aInSquare">квадрат ширины прямоугольника, диагонали которого являются ассимптотами гиперболы </param>
        /// <param name="bInSquare">квадрат высоты прямоугольника, диагонали которого являются ассимптотами гиперболы</param>
        /// <param name="signA">знак коэффицента А</param>
        /// <param name="signC">знак коэффицента С</param>
        /// <param name="Delta">инвариант Дельта</param>
        /// <returns>Возвращает клеточное поле с графиком гиперболы</returns>
        Bitmap CreateGraph_Hyperbol(Bitmap squareField, double x0InPixels, double y0InPixels, double sinAlpha, double cosAlpha, double a, double b, double aInSquare, double bInSquare,int signA, int signC, double Delta)
        {
            Pen pen = new Pen(Color.Green, 2);
            Bitmap result = squareField;
            using (Graphics g = Graphics.FromImage(result))
            {
                if (Delta != 0)
                {
                    if (signA > 0)
                    {
                        for (double x = -3 * a; x <= -a; x += 0.001)
                        {
                            for (double y = -3 * b; y <= 3 * b; y += 0.001)
                            {
                                if ((0.999 <= ((x * x) / aInSquare * signA + (y * y) / bInSquare * signC)) && (((x * x) / aInSquare * signA + (y * y) / bInSquare * signC) <= 1.001))
                                {
                                    g.DrawLine(new Pen(Color.Black, 3), new PointF((float)((x * cosAlpha + y * sinAlpha) * squareInPixels + x0InPixels), (float)((-x * sinAlpha + y * cosAlpha) * squareInPixels + y0InPixels)), new PointF((float)((x * cosAlpha + y * sinAlpha) * squareInPixels + x0InPixels + 0.1), (float)((-x * sinAlpha + y * cosAlpha) * squareInPixels + y0InPixels + 0.1)));
                                }
                            }
                        }
                        for (double x = a * a; x <= 3 * a; x += 0.001)
                        {
                            for (double y = -3 * b; y <= 3 * b; y += 0.001)
                            {
                                if ((0.999 <= ((x * x) / aInSquare * signA + (y * y) / bInSquare * signC)) && (((x * x) / aInSquare * signA + (y * y) / bInSquare * signC) <= 1.001))
                                {
                                    g.DrawLine(new Pen(Color.Black, 3), new PointF((float)((x * cosAlpha + y * sinAlpha) * squareInPixels + x0InPixels), (float)((-x * sinAlpha + y * cosAlpha) * squareInPixels + y0InPixels)), new PointF((float)((x * cosAlpha + y * sinAlpha) * squareInPixels + x0InPixels + 0.1), (float)((-x * sinAlpha + y * cosAlpha) * squareInPixels + y0InPixels + 0.1)));
                                }
                            }
                        }
                    }
                    else if (signC > 0)
                    {
                        for (double x = -3 * a; x <= 3 * a; x += 0.001)
                        {
                            for (double y = b; y <= 3 * b; y += 0.001)
                            {
                                if ((0.999 <= ((x * x) / aInSquare * signA + (y * y) / bInSquare * signC)) && (((x * x) / aInSquare * signA + (y * y) / bInSquare * signC) <= 1.001))
                                {
                                    g.DrawLine(new Pen(Color.Black, 3), new PointF((float)((x * cosAlpha + y * sinAlpha) * squareInPixels + x0InPixels), (float)((-x * sinAlpha + y * cosAlpha) * squareInPixels + y0InPixels)), new PointF((float)((x * cosAlpha + y * sinAlpha) * squareInPixels + x0InPixels + 0.1), (float)((-x * sinAlpha + y * cosAlpha) * squareInPixels + y0InPixels + 0.1)));
                                }
                            }
                        }
                        for (double x = -3 * a; x <= 3 * a; x += 0.001)
                        {
                            for (double y = -3 * b; y <= -b; y += 0.001)
                            {
                                if ((0.999 <= ((x * x) / aInSquare * signA + (y * y) / bInSquare * signC)) && (((x * x) / aInSquare * signA + (y * y) / bInSquare * signC) <= 1.001))
                                {
                                    g.DrawLine(new Pen(Color.Black, 3), new PointF((float)((x * cosAlpha + y * sinAlpha) * squareInPixels + x0InPixels), (float)((-x * sinAlpha + y * cosAlpha) * squareInPixels + y0InPixels)), new PointF((float)((x * cosAlpha + y * sinAlpha) * squareInPixels + x0InPixels + 0.1), (float)((-x * sinAlpha + y * cosAlpha) * squareInPixels + y0InPixels + 0.1)));
                                }
                            }
                        }
                    }
                }
                else
                {
                    pen = new Pen(Color.Black, 3);
                }
                g.DrawLine(new Pen(Color.Blue, 2), new PointF((float)((3 * a * cosAlpha - 0 * sinAlpha) * squareInPixels + x0InPixels), (float)(-(3 * a * sinAlpha + 0 * cosAlpha) * squareInPixels + y0InPixels)), new PointF((float)((-3 * a * cosAlpha - 0 * sinAlpha) * squareInPixels + x0InPixels), (float)(-(-3 * a * sinAlpha + 0 * cosAlpha) * squareInPixels + y0InPixels)));
                g.DrawLine(new Pen(Color.Violet, 2), new PointF((float)((0 * cosAlpha - 3 * b * sinAlpha) * squareInPixels + x0InPixels), (float)(-(0 * sinAlpha + 3 * b * cosAlpha) * squareInPixels + y0InPixels)), new PointF((float)((0 * cosAlpha - -3 * b * sinAlpha) * squareInPixels + x0InPixels), (float)(-(0 * sinAlpha - 3 * b * cosAlpha) * squareInPixels + y0InPixels)));
                g.DrawLine(pen, new PointF((float)((3 * a * cosAlpha - 3 * b * sinAlpha) * squareInPixels + x0InPixels), (float)(-(3*a  * sinAlpha + 3 * b * cosAlpha) * squareInPixels + y0InPixels)), new PointF((float)((-3 * a * cosAlpha - -3 * b * sinAlpha) * squareInPixels + x0InPixels), (float)(-( -3*a* sinAlpha  + -3 * b * cosAlpha) * squareInPixels + y0InPixels)));
                g.DrawLine(pen, new PointF((float)((-3 * a * cosAlpha - 3 * b * sinAlpha) * squareInPixels + x0InPixels), (float)(-(-3*a * sinAlpha + 3 * b * cosAlpha) * squareInPixels + y0InPixels)), new PointF((float)((3 * a * cosAlpha - -3 * b * sinAlpha) * squareInPixels + x0InPixels), (float)(-( 3*a * sinAlpha + -3 * b * cosAlpha) * squareInPixels + y0InPixels)));
            }
            return result;
        }

        private void FormGraph_Paint(object sender, PaintEventArgs e)
        {
            //Graphics g = e.Graphics;
            //Pen pen = new Pen(Color.Black, 2);
            //g.DrawLine(pen, 100, 100, 100, 100);
            //g.DrawArc(pen, 10, 10, 100, 200, 45, 50);
            //g.DrawArc(pen, 10, 10, 100, 200, -45, 360);

        }

        private void panelGraph_Paint(object sender, PaintEventArgs e)
        {
            //Image imageFile = Image.FromFile("Images/squareFieldForDrawing.png");


            //// Create graphics object for alteration.
            //Graphics newGraphics = Graphics.FromImage(imageFile);

            //// Alter image.
            //newGraphics.FillRectangle(new SolidBrush(Color.Black), 100, 50, 100, 100);

            //// Draw image to screen.
            //e.Graphics.DrawImage(imageFile, new PointF(0F, 0F));
            //PictureBox graph = new PictureBox();
            
            

            //newGraphics.Dispose();
        }
    }
}
