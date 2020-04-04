using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace test1
{
    public partial class Form1 : Form
    {
        private Graphics graphics;
        double th1 = 30 * Math.PI / 180;
        double th2 = 20 * Math.PI / 180;
        double per1 = 0.6;
        double per2 = 0.7;
        double leng = 100;
        int n = 10;
        Pen pen = new Pen(Color.Blue, (float)1);


        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (graphics == null) graphics = this.CreateGraphics();
            else graphics.Clear(Color.White);
            drawCayleyTree(n, 200, 310, leng, -Math.PI / 2);
        }

   

        void drawCayleyTree(int n, double x0, double y0, double leng, double th) {
            if (n == 0) return;
            double x1 = x0 + leng * Math.Cos(th);
            double y1 = y0 + leng * Math.Sin(th);
            drawLine(x0, y0, x1, y1);

            drawCayleyTree(n - 1, x1, y1, per1 * leng, th + th1);
            drawCayleyTree(n - 1, x1, y1, per1 * leng, th - th2);
        }

        void drawLine(double x0, double y0, double x1, double y1) {
            graphics.DrawLine(
            pen, (int)x0,(int)y0,(int)x1,(int)y1);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            leng = Convert.ToDouble(this.numericUpDown1.Value);
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            n = Convert.ToInt32(this.numericUpDown2.Value);
        }

        private void numericUpDown3_ValueChanged(object sender, EventArgs e)
        {
            th1 = Convert.ToDouble(this.numericUpDown3.Value);
        }

        private void numericUpDown4_ValueChanged(object sender, EventArgs e)
        {
            th2 = Convert.ToDouble(this.numericUpDown4.Value);
        }

        private void numericUpDown5_ValueChanged(object sender, EventArgs e)
        {
            th1 = Convert.ToDouble(this.numericUpDown5.Value)* Math.PI / 180;
        }

        private void numericUpDown6_ValueChanged(object sender, EventArgs e)
        {
            th2 = Convert.ToDouble(this.numericUpDown6.Value) * Math.PI / 180;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBox1.SelectedItem.ToString()) {
                case "Blue":
                    pen.Color = Color.Blue;
                    break;
                case "Orange":
                    pen.Color = Color.Orange;
                    break;
                case "Black":
                    pen.Color = Color.Black;
                    break;
                default:
                    break;

            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
