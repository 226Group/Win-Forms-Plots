using System;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
       //ouble xMin, xMax;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {

            BuildChart();
        }

        private void BuildChart()
        {
            //Очищает предидущие значения
            chart1.Series["Sin(x)"].Points.Clear();
            chart1.Series["Cos(x)"].Points.Clear();

            //ввод значений и перевод их в числа
            if (!double.TryParse(xmin.Text, out double xMin) ||
                !double.TryParse(xmax.Text, out double xMax) ||
                !double.TryParse(k.Text, out double koef) ||
                !double.TryParse(phase.Text, out double phaseShift))
            {
                MessageBox.Show("Пожалуйста, введите корректные числовые значения.");

                xmin.Clear();
                xmax.Clear();
                k.Clear();
                phase.Clear();

                return;
            }

            //chart1.ChartAreas["MainArea"].Min

            double h = 0.1;

            // график синуса
            if (checkBoxSin.Checked)
            {
                for (double x = xMin; x <= xMax; x += h)
                {
                    double y = Math.Sin(koef * x + phaseShift);
                    chart1.Series["Sin(x)"].Points.AddXY(x, y);
                }
            }

            // график косинуса
            if (checkBoxCos.Checked)
            {
                for (double x = xMin; x <= xMax; x += h)
                {
                    double y = Math.Cos(koef * x + phaseShift);
                    chart1.Series["Cos(x)"].Points.AddXY(x, y);
                }
            }
            if (checkBoxCos.Checked && checkBoxSin.Checked);

        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}