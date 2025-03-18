using System;
using System.Drawing;
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
            k.Text = "1";
            phase.Text = "0";
            checkBoxSin.CheckedChanged += (s, ev) => UpdateChart(s,ev);
            checkBoxCos.CheckedChanged += (s, ev) => UpdateChart(s,ev);
            Chart x = null;

        }

        private void UpdateChart(object sender, EventArgs e)
        {
            // Очистка графика перед построением
            // Изменяем не улаляем
            //myChart.ChartAreas.Clear();
            myChart.Series.Clear();

            //myChart.Series["Sin(x)"].Points.Clear();
            //myChart.Series["Cos(x)"].Points.Clear();

            // Получение значений из текстовых полей
            if (!double.TryParse(xmin.Text, out double xMin) ||
                !double.TryParse(xmax.Text, out double xMax) ||
                !double.TryParse(k.Text, out double koef) ||
                !double.TryParse(phase.Text, out double phaseShift))
            {
                MessageBox.Show("Пожалуйста, введите корректные числовые значения.");
                return;
            }

            // Create a ChartArea
            //ChartArea chartArea = new ChartArea("MainArea");


            // Set the axis limits
            var chartArea = myChart.ChartAreas["MainArea"];
            chartArea.AxisX.Minimum = xMin; // Set X-axis minimum
            chartArea.AxisX.Maximum = xMax; // Set X-axis maximum
            chartArea.AxisY.Minimum = -1; // Set Y-axis minimum
            chartArea.AxisY.Maximum = 1; // Set Y-axis maximum


            myChart.Series.Clear();

            // Create and add sine series
            Series sinSeries = new Series("Sin(x)")
            {
                ChartType = SeriesChartType.Line,
                Color = Color.Blue
            };
            myChart.Series.Add(sinSeries);

            // Create and add cosine series
            Series cosSeries = new Series("Cos(x)")
            {
                ChartType = SeriesChartType.Line,
                Color = Color.Red
            };
            myChart.Series.Add(cosSeries);


            double h = 0.1; // Step
            for (double x = xMin; x <= xMax; x += h)
            {
                if (checkBoxSin.Checked)
                {
                    double y = Math.Sin(koef * x + phaseShift);
                    sinSeries.Points.AddXY(x, y);
                }

                if (checkBoxCos.Checked)
                {
                    double y = Math.Cos(koef * x + phaseShift);
                    cosSeries.Points.AddXY(x, y);
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
