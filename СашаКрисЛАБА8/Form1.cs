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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace СашаКрисЛАБА8
{
    public partial class Form1 : Form
    {
        public static double xn, xk, xh, x, y, a, ymax, ymin, yt;

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            System.Windows.Forms.TextBox tb = sender as System.Windows.Forms.TextBox;
            char number = e.KeyChar;
            string sep = System.Globalization.CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator;

            
            if (char.IsDigit(number) || char.IsControl(number)) return;


            if (number == '-' && tb.SelectionStart == 0 && !tb.Text.Contains("-")) return;


            if (number.ToString() == sep && tb.Text.Length > 0 && !tb.Text.Contains(sep)) return;

            e.Handled = true;
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            System.Windows.Forms.TextBox tb = sender as System.Windows.Forms.TextBox;
            char number = e.KeyChar;
            string sep = System.Globalization.CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator;

          
            if (char.IsDigit(number) || char.IsControl(number)) return;

           
            if (number == '-' && tb.SelectionStart == 0 && !tb.Text.Contains("-")) return;

            
            if (number.ToString() == sep && tb.Text.Length > 0 && !tb.Text.Contains(sep)) return;

            e.Handled = true; 
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            System.Windows.Forms.TextBox tb = sender as System.Windows.Forms.TextBox;
            char number = e.KeyChar;
            string sep = System.Globalization.CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator;

            if (char.IsDigit(number) || char.IsControl(number)) return;
            if (number == '-' && tb.SelectionStart == 0 && !tb.Text.Contains("-")) return;
            if (number.ToString() == sep && tb.Text.Length > 0 && !tb.Text.Contains(sep)) return;

            e.Handled = true; 
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            System.Windows.Forms.TextBox tb = sender as System.Windows.Forms.TextBox;
            char number = e.KeyChar;
            string sep = System.Globalization.CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator;

            if (char.IsDigit(number) || char.IsControl(number)) return;

            if (number == '-' && tb.SelectionStart == 0 && !tb.Text.Contains("-")) return;

            if (number.ToString() == sep && tb.Text.Length > 0 && !tb.Text.Contains(sep)) return;

            e.Handled = true; 
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            { 
          
                double xn = Convert.ToDouble(textBox1.Text);
                double xk = Convert.ToDouble(textBox2.Text);
                double h = Convert.ToDouble(textBox3.Text);
                dataGridView1.Rows.Clear();
                dataGridView1.Rows.Clear();
                chart1.Series[0].Points.Clear();
                chart1.Titles.Clear(); 
                chart1.Titles.Add("График функции Вариант 9");

                double maxVal = double.MinValue;
                double minVal = double.MaxValue;

                for (double x = xn; x <= xk + h / 2; x += h)
                {

                    double y = Math.Pow(x, 5) + Math.Pow(x + 10, 1.0 / 3.0);

                    if (!double.IsNaN(y) && !double.IsInfinity(y))
                    {
                        dataGridView1.Rows.Add(Math.Round(x, 2), Math.Round(y, 3));
                        chart1.Series[0].Points.AddXY(Math.Round(x, 2), y);
                        if (y > maxVal) maxVal = y;
                        if (y < minVal) minVal = y;
                    }
                }

              
                textBox5.Text = Math.Round(maxVal, 3).ToString();
                textBox6.Text = Math.Round(minVal, 3).ToString();

                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка! Проверьте, что в полях ввода указаны числа. " + ex.Message);
            }
        }

        private void высотаСтрокToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            if (f2.ShowDialog() == DialogResult.OK)
            {
                int newHeight = f2.InputValue;

                dataGridView1.RowTemplate.Height = newHeight;

                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    row.Height = newHeight;
                }
            }
        }

        private void ширинаСтолбцовToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            if (f2.ShowDialog() == DialogResult.OK)
            {
                int newWidth = f2.InputValue;

                foreach (DataGridViewColumn col in dataGridView1.Columns)
                {
                    col.Width = newWidth;
                }
            }
        }

        private void сохранитьДанныеТаблицыВФайлToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                StreamWriter sw = new StreamWriter(sfd.FileName);
                sw.WriteLine("Результаты расчетов:");
                sw.Close();
                MessageBox.Show("Файл успешно сохранен");
            }
        }

        private void цветТекстаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog cd = new ColorDialog();
            if (cd.ShowDialog() == DialogResult.OK)
            {
                dataGridView1.DefaultCellStyle.ForeColor = cd.Color; 
            }
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
          
                xn = double.Parse(textBox1.Text);
                xk = double.Parse(textBox2.Text);
                xh = double.Parse(textBox3.Text);
                a = double.Parse(textBox4.Text);

                if (tabControl1.SelectedIndex == 1) 
                {
                   
                }
                else if (tabControl1.SelectedIndex == 2) 
                {
                    
                }
            }
            catch
            {
                MessageBox.Show("Введите корректные числовые данные!", "Ошибка");
                tabControl1.SelectedIndex = 0; 
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void выхоToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        public static int i, k, j, h, m;
        public Form1()
        {
            InitializeComponent();
        }
    }
}
