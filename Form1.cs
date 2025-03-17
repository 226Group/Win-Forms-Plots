using System;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Инициализация значений по умолчанию
            xmin.Text = "-10"; // x min
            xmax.Text = "10";  // x max
            k.Text = "0";    // sin(x) phase shift
            phase.Text = "0";    // cos(x) phase shift
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            // Вызываем метод для построения графика
            BuildChart();
        }

        private void BuildChart()
        {
            // Очистка графика перед построением
            chart1.Series["Sin(x)"].Points.Clear();
            chart1.Series["Cos(x)"].Points.Clear();

            // Получение значений из текстовых полей
            if (!double.TryParse(xmin.Text, out double xMin) ||
                !double.TryParse(xmax.Text, out double xMax) ||
                !double.TryParse(k.Text, out double koef) ||
                !double.TryParse(phase.Text, out double phaseShift))
            {
                MessageBox.Show("Пожалуйста, введите корректные числовые значения.");
                return;
            }

            double h = 0.1; // Шаг

            // Построение графика синуса
            if (checkBoxSin.Checked)
            {
                for (double x = xMin; x <= xMax; x += h)
                {
                    double y = Math.Sin(koef * x + phaseShift);
                    chart1.Series["Sin(x)"].Points.AddXY(x, y);
                }
            }

            // Построение графика косинуса
            if (checkBoxCos.Checked)
            {
                for (double x = xMin; x <= xMax; x += h)
                {
                    double y = Math.Cos(koef * x + phaseShift);
                    chart1.Series["Cos(x)"].Points.AddXY(x, y);
                }
            }
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
    }
}
