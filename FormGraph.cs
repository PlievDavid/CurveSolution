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
        public string[] Coefficients { get; set; }
        CalculationCoefficients coef;
        GraphCalc calc;
        GraphDrawing graph;
        public FormGraph()
        {
            InitializeComponent();
        }
        public PictureBox Field = new PictureBox();
       
        private void FormGraph_Load(object sender, EventArgs e)
        {
            coef = new CalculationCoefficients(Coefficients);
            if (coef.Delta != 0)
            {
                labelAphineX.Text = "x = x' * " + ((float)coef.CosAlpha).ToString() + " - y' * " + ((float)coef.SinAlpha).ToString() + " + " + ((float)coef.X0).ToString();
                labelAphineY.Text = "y = x' * " + ((float)coef.SinAlpha).ToString() + " + y' * " + ((float)coef.CosAlpha).ToString() + " + " + ((float)coef.Y0).ToString();
            }
            else
            {
                labelAphineX.Text = "x = x' * " + ((float)coef.CosAlpha).ToString() + " - y' * " + ((float)coef.SinAlpha).ToString();
                labelAphineY.Text = "y = x' * " + ((float)coef.SinAlpha).ToString() + " + y' * " + ((float)coef.CosAlpha).ToString();
            }
            
            
            PictureBox HLine = new PictureBox();
            HLine.Load("Images/redSquare.png");
            PictureBox VLine = new PictureBox();
            VLine.Load("Images/redSquare.png");
            calc = new GraphCalc(coef);
            graph = new GraphDrawing(coef, calc, "Images/squareField.jpg", HLine , VLine);
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
            StreamWriter wr = new StreamWriter("data/graph.txt");
            wr.WriteLine("Тип кривой: " + graph.GetCurveType());
            wr.WriteLine("Координаты центра: " + coef.X0 + ", " + coef.Y0);
            wr.Close();
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
