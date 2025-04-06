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
            double aInSquare = FStr / AStr;
            double bInSquare = FStr / CStr;
            double a = Math.Sqrt(aInSquare);
            double b = Math.Sqrt(bInSquare);
            MessageBox.Show((Math.Sqrt(1 + tgAlpha * tgAlpha)).ToString());
            MessageBox.Show(sinAlpha.ToString());


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
            Bitmap result = CreateGraph_Ellipse(squareField, x0InPixels, y0InPixels, sinAlpha, cosAlpha, a, b, aInSquare, bInSquare, centerX, centerY);
            Field.Image = result;
            Field.Width = result.Width;
            Field.Height = result.Height;
            Field.SizeMode = PictureBoxSizeMode.StretchImage;
            Field.Location = new Point(0, 0);
            Field.SendToBack();
            panelGraph.Controls.Add(Field);
            labelAphineX.Text = "x = x' * " + cosAlpha.ToString() + " - y' * " + sinAlpha.ToString() + " + " + x0.ToString();
            labelAphineY.Text = "y = x' * " + sinAlpha.ToString() + " + y' * " + cosAlpha.ToString() + " + " + y0.ToString();
            labelA2.Text = aInSquare.ToString().Substring(0,6);
            labelB2.Text = bInSquare.ToString().Substring(0, 6);
            if (aInSquare>0)
            {
                labelSignA.Text = "";
            }
            else
                labelSignA.Text = "-";
            if (bInSquare > 0)
            {
                labelSignB.Text = "+";
            }
            else
                labelSignB.Text = "-";
        }
        Bitmap CreateGraph_Ellipse(Bitmap squareField, double x0InPixels, double y0InPixels, double sinAlpha, double cosAlpha, double a, double b, double aInSquare, double bInSquare, int centerX,int centerY)
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
                            g.DrawLine(new Pen(Color.Black,3),new PointF((float)((x * cosAlpha - y * sinAlpha)*squareInPixels + x0InPixels), (float)((x * sinAlpha + y * cosAlpha) * squareInPixels + y0InPixels)),new PointF((float)(( x * cosAlpha - y * sinAlpha) * squareInPixels + x0InPixels + 0.1), (float)((x * sinAlpha + y * cosAlpha) * squareInPixels + y0InPixels + 0.1)));
                            // MessageBox.Show(((x * cosAlpha - y * sinAlpha) * squareInPixels + x0InPixels + centerX).ToString());
                        }
                    }
                }
                g.DrawLine(new Pen(Color.Blue, 2), new PointF((float)((3*a * cosAlpha - 0 * sinAlpha) * squareInPixels + x0InPixels), (float)((3 * a * sinAlpha + 0 * cosAlpha) * squareInPixels + y0InPixels)), new PointF((float)((-3 * a * cosAlpha - 0 * sinAlpha) * squareInPixels + x0InPixels), (float)((-3 * a * sinAlpha + 0 * cosAlpha) * squareInPixels + y0InPixels)));
                g.DrawLine(new Pen(Color.Violet, 2), new PointF((float)(( 0 * cosAlpha - 3 * b * sinAlpha) * squareInPixels + x0InPixels), (float)((0 * sinAlpha + 3 * b * cosAlpha) * squareInPixels + y0InPixels)), new PointF((float)((0 * cosAlpha + 3 * b * sinAlpha) * squareInPixels + x0InPixels), (float)((0 * sinAlpha - 3 * b * cosAlpha) * squareInPixels + y0InPixels)));
            }
            return result;
        }

        private void FormGraph_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Pen pen = new Pen(Color.Black, 2);
            // Рисуем линию от точки (10, 10) до точки (100, 100)
            g.DrawLine(pen, 100, 100, 100, 100);
            g.DrawArc(pen, 10, 10, 100, 200, 45, 50);
            g.DrawArc(pen, 10, 10, 100, 200, -45, 360);

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
