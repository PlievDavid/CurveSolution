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
            StreamReader coordinates = new StreamReader("data/graph.txt");
            string[] s = coordinates.ReadLine().Split();
            coordinates.Close();
            double x0 = Convert.ToDouble(s[0]);
            double x0InPixels = x0 * squareInPixels + 328;
            MessageBox.Show(x0InPixels.ToString());
            double y0 = Convert.ToDouble(s[1]);
            double y0InPixels = -y0 * squareInPixels + 245;
            double sinAlpha = Convert.ToDouble(s[2]);
            double cosAlpha = Convert.ToDouble(s[3]);
            double AStr = Convert.ToDouble(s[4]);
            double CStr = Convert.ToDouble(s[5]);
            double FStr = Convert.ToDouble(s[6]);
            double aInSquare = FStr / AStr;
            double bInSquare = FStr / CStr;
            double a = Math.Sqrt(aInSquare);
            double b = Math.Sqrt(bInSquare);
            
            MessageBox.Show(y0InPixels.ToString());
            int centerX = 328;
            int centerY = 245;
            if (x0InPixels<328)
            {
                centerX += Math.Abs(328*(int)(centerX/x0InPixels))+1;
                x0InPixels += centerX;
                x0InPixels -= 328;
            }
            if (y0InPixels < 245)
            {
                centerY += Math.Abs(245*(int)(centerY/y0InPixels))+3;
                y0InPixels += centerY;
                y0InPixels -= 245;
            }
            MessageBox.Show(centerX.ToString());
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
