using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CurveSolution
{
    public partial class FormEquation : Form
    {
        public FormEquation()
        {
            InitializeComponent();
        }

        private void FormEquation_Load(object sender, EventArgs e)
        {
            FillDictionary();
        }
        Dictionary<char, int> coefficients = new Dictionary<char, int> { };
        /// <summary>
        /// Заполняет словарь изначальным значением коэффицентов
        /// </summary>
        void FillDictionary()
        {
            for (char i = 'A'; i <= 'F'; i++)
            {
                coefficients.Add(i, 1);
            }
        }
        /// <summary>
        /// Меняет знак в строке текст бокса textBoxEquation
        /// </summary>
        /// <param name="cnt"> количесвто элементов в textBoxEquationInsertPosition</param>
        /// <param name="position"> позиция, в которой меняем знак</param>
        /// <param name="sign"> знак, на который меняем</param>
        /// <param name="textBoxEquationInsertPosition"> строка, разделенная по пробелам</param>
        void PositionSignChange(int cnt, string position, string sign, string[] textBoxEquationInsertPosition)
        {
            textBoxEquation.Text = textBoxEquation.Text + textBoxEquationInsertPosition[0] + " ";
            for (int i = 1; i < cnt - 1; i++)
            {
                if (textBoxEquationInsertPosition[i - 1] == position)
                    textBoxEquation.Text = textBoxEquation.Text + sign + " ";
                else
                    textBoxEquation.Text = textBoxEquation.Text + textBoxEquationInsertPosition[i] + " ";
            }
        }
        /// <summary>
        /// Меняет число в указанной позиции в строке текст бокса textBoxEquation
        /// </summary>
        /// <param name="cnt">количесвто элементов в textBoxEquationInsertPosition</param>
        /// <param name="position">позиция, в которой меняем число</param>
        /// <param name="num">чилсло, на которое меняем</param>
        /// <param name="textBoxEquationInsertPosition">строка, разделенная по пробелам</param>
        void PositionNumChange(int cnt,string position, string num,string[] textBoxEquationInsertPosition)
        {
            for (int i = 0; i < cnt-1; i++)
            {
                if (textBoxEquationInsertPosition[i + 1] == position)
                    textBoxEquation.Text = textBoxEquation.Text + num + " ";
                else
                    textBoxEquation.Text = textBoxEquation.Text + textBoxEquationInsertPosition[i] + " ";
            }
        }
        /// <summary>
        /// Реализует ввод коэффицентов
        /// </summary>
        /// <param name="textBox"> текст бокс куда записываем уравнение</param>
        /// <param name="position">позиция коэффицента</param>
        void InsertNumber(ref TextBox textBox, string position)
        {
            string strA = textBox.Text;
            if (strA != "")
            {
                int A;
                try
                {
                    A = Convert.ToInt32(strA);
                }
                catch
                {
                    MessageBox.Show("Введите числовое значение, не превышающее 2^32.");
                    strA = strA.Substring(0, strA.Length - 1);
                    textBox.Text = strA;
                }
                string[] textBoxEquationInsertPosition;
                textBoxEquationInsertPosition = textBoxEquation.Text.Split();
                textBoxEquation.Clear();
                int cnt = textBoxEquationInsertPosition.Count();
                PositionNumChange(cnt, position, strA, textBoxEquationInsertPosition);
            }
        }

        private void textBoxA_TextChanged(object sender, EventArgs e)
        {
            InsertNumber(ref textBoxA,"x^2");
        }

        private void textBoxB_TextChanged(object sender, EventArgs e)
        {
            InsertNumber(ref textBoxB, "x*y");
        }

        private void textBoxC_TextChanged(object sender, EventArgs e)
        {
            InsertNumber(ref textBoxC, "y^2");
        }

        private void textBoxD_TextChanged(object sender, EventArgs e)
        {
            InsertNumber(ref textBoxD, "x");
        }

        private void textBoxE_TextChanged(object sender, EventArgs e)
        {
            InsertNumber(ref textBoxE, "y");
        }

        private void textBoxF_TextChanged(object sender, EventArgs e)
        {
            InsertNumber(ref textBoxF, "=");
        }

        private void radioButtonAPlus_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonAPlus.Checked == false)
            {
                textBoxEquation.Text = "- " + textBoxEquation.Text;
                coefficients['A'] = -1;
            }
            else
            {
                textBoxEquation.Text = textBoxEquation.Text.Substring(2);
                coefficients['A'] = 1;
            }
        }

        private void radioButtonBPlus_CheckedChanged(object sender, EventArgs e)
        {
            string[] textBoxEquationInsertPosition;
            textBoxEquationInsertPosition = textBoxEquation.Text.Split();
            textBoxEquation.Clear();
            int cnt = textBoxEquationInsertPosition.Count();
            if (radioButtonBPlus.Checked == false)
            {
                PositionSignChange(cnt, "x^2", "-", textBoxEquationInsertPosition);
                coefficients['B'] = -1;
            }
            else
            {
                PositionSignChange(cnt, "x^2", "+", textBoxEquationInsertPosition);
                coefficients['B'] = 1;
            }
        }

        private void radioButtonCPlus_CheckedChanged(object sender, EventArgs e)
        {
            string[] textBoxEquationInsertPosition;
            textBoxEquationInsertPosition = textBoxEquation.Text.Split();
            textBoxEquation.Clear();
            int cnt = textBoxEquationInsertPosition.Count();
            if (radioButtonCPlus.Checked == false)
            {
                PositionSignChange(cnt, "x*y", "-", textBoxEquationInsertPosition);
                coefficients['C'] = -1;
            }
            else
            {
                PositionSignChange(cnt, "x*y", "+", textBoxEquationInsertPosition);
                coefficients['C'] = 1;
            }
        }

        private void radioButtonDPlus_CheckedChanged(object sender, EventArgs e)
        {
            string[] textBoxEquationInsertPosition;
            textBoxEquationInsertPosition = textBoxEquation.Text.Split();
            textBoxEquation.Clear();
            int cnt = textBoxEquationInsertPosition.Count();
            if (radioButtonDPlus.Checked == false)
            {
                PositionSignChange(cnt, "y^2", "-", textBoxEquationInsertPosition);
                coefficients['D'] = -1;
            }
            else
            {
                PositionSignChange(cnt, "y^2", "+", textBoxEquationInsertPosition);
                coefficients['D'] = 1;
            }
        }

        private void radioButtonEPlus_CheckedChanged(object sender, EventArgs e)
        {
            string[] textBoxEquationInsertPosition;
            textBoxEquationInsertPosition = textBoxEquation.Text.Split();
            textBoxEquation.Clear();
            int cnt = textBoxEquationInsertPosition.Count();
            if (radioButtonEPlus.Checked == false)
            {
                PositionSignChange(cnt, "x", "-", textBoxEquationInsertPosition);
                coefficients['E'] = -1;
            }
            else
            {
                PositionSignChange(cnt, "x", "+", textBoxEquationInsertPosition);
                coefficients['E'] = 1;
            }
        }

        private void radioButtonFPlus_CheckedChanged(object sender, EventArgs e)
        {
            string[] textBoxEquationInsertPosition;
            textBoxEquationInsertPosition = textBoxEquation.Text.Split();
            textBoxEquation.Clear();
            int cnt = textBoxEquationInsertPosition.Count();
            if (radioButtonFPlus.Checked == false)
            {
                PositionSignChange(cnt, "y", "-", textBoxEquationInsertPosition);
                coefficients['F'] = -1;
            }
            else
            {
                PositionSignChange(cnt, "y", "+", textBoxEquationInsertPosition);
                coefficients['F'] = 1;
            }
        }
        void Calculations()
        {
            double A = Convert.ToDouble(textBoxA.Text) * coefficients['A'];
            double B = Convert.ToDouble(textBoxB.Text) * coefficients['B'] / 2;
            double C = Convert.ToDouble(textBoxC.Text) * coefficients['C'];
            double D = Convert.ToDouble(textBoxD.Text) * coefficients['D'] / 2;
            double E = Convert.ToDouble(textBoxE.Text) * coefficients['E'] / 2;
            double F = Convert.ToDouble(textBoxF.Text) * coefficients['F'] / 2;
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
            StreamWriter coordinates = new StreamWriter("data/graph.txt");
            coordinates.WriteLine(x0 + " " + y0 + " " + sinAlpha + " " + cosAlpha + " " + AStr + " " + CStr + " " + FStr);
            coordinates.Close();
        }
        private void buttonSolve_Click(object sender, EventArgs e)
        {
            Calculations();
            FormGraph graph = new FormGraph { };
            graph.Show();
        }
    }
}
