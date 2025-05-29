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
        CalculationCoefficients coef;
        GraphDrawing graph;
        public FormGraph()
        {
            InitializeComponent();
        }
        public PictureBox Field = new PictureBox();
       
        private void FormGraph_Load(object sender, EventArgs e)
        {
            StreamReader file = new StreamReader("data/graph.txt");
            string[] coefficients = file.ReadLine().Split();
            file.Close();
            coef = new CalculationCoefficients(coefficients);
            if (coef.Delta != 0)
            {
                labelAphineX.Text = "x = x' * " + coef.CosAlpha.ToString() + " - y' * " + coef.SinAlpha.ToString() + " + " + coef.X0.ToString();
                labelAphineY.Text = "y = x' * " + coef.SinAlpha.ToString() + " + y' * " + coef.CosAlpha.ToString() + " + " + coef.Y0.ToString();
            }
            else
            {
                labelAphineX.Text = "x = x' * " + coef.CosAlpha.ToString() + " - y' * " + coef.SinAlpha.ToString();
                labelAphineY.Text = "y = x' * " + coef.SinAlpha.ToString() + " + y' * " + coef.CosAlpha.ToString();
            }
            int centerX = 328;
            int centerY = 245;
            double x0InPixels = coef.X0 * squareInPixels + centerX;
            double y0InPixels = -coef.Y0 * squareInPixels + centerY;
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
            PictureBox Line = new PictureBox();
            Line.Load("Images/redSquare.png");
            PictureBox Line2 = new PictureBox();
            Line2.Load("Images/redSquare.png");
            graph = new GraphDrawing(coef, centerX, centerY, x0InPixels, y0InPixels, "Images/squareField.jpg", Line , Line2, squareInPixels);
            LoadCurve(graph.Graph);
            panelGraph.Controls.Add(Field);
            labelA2.Text = ((float)coef.GraphAInSquare).ToString();
            labelB2.Text = ((float)coef.GraphBInSquare).ToString();
            if (Math.Sign(coef.FStr / coef.AStr) > 0)
            {
                labelSignA.Text = "";
            }
            else
                labelSignA.Text = "-";
            if (Math.Sign(coef.FStr / coef.CStr) > 0)
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
            panelGraph.Controls.Add(graph.HLine);
            graph.HLine.BringToFront();
            panelGraph.Controls.Add(graph.VLine);
            graph.VLine.BringToFront();
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
