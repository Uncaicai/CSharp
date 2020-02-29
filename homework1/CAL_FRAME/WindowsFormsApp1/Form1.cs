using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }



        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {


                Double num1 = 0;
                Double num2 = 0;
            


                try
                {
                    num1 = Convert.ToDouble(tbxNum1.Text);
                    num2 = Convert.ToDouble(tbxNum2.Text);
                   
                    switch (cbbxSymbol.SelectedItem.ToString())
                    {
                        case "＋":
                            lblResultNum.Text = Convert.ToString(num1 + num2);
                            break;
                        case "-":
                            lblResultNum.Text = Convert.ToString(num1 - num2);
                            break;
                        case "×":
                            lblResultNum.Text = Convert.ToString(num1 * num2);
                            break;
                        case "÷":
                            if (num2 == 0)
                            {
                                lblResultNum.Text = ("error：Dividend Cannot Be Zero");
                            }
                            else
                            {
                                lblResultNum.Text = Convert.ToString(num1 / num2);
                            }
                            break;
                    /* case "+":
                         double n11 = n1 + n2;
                         Console.WriteLine("进行加法运算的结果为" + n11);
                         break;
                     case "-":
                         double n12 = n1 - n2;
                         Console.WriteLine("进行减法运算的结果" + n12);
                         break;
                     case "*":
                         double n13 = n1 * n2;
                         Console.WriteLine("进行乘法运算的结果为" + n13);
                         break;
                     case "/":
                         while (n2 == 0)
                         {
                             Console.WriteLine("请输入一个非零数 ");
                             n2 = Convert.ToInt32(Console.ReadLine());
                         }
                         double n14 = n1 / n2;
                         Console.WriteLine("进行除法运算的结果" + n14);
                         break;

                     default:
                         Console.WriteLine("您输入的运算符有误！！");
                         break;*/

                    }

                  
                }
                catch (FormatException)
                {
                lblResultNum.Text = Convert.ToString("输入有误，请重新输入");
       
        }
            catch(OverflowException)
            {
                lblResultNum.Text = "error: Number Overflow";
            }
            catch(NullReferenceException)
            {
                lblResultNum.Text = " error: Wrong Sign of Operation";
            }
            
        }

        private void cbbxSymbol_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click_1(object sender, EventArgs e)
        {

        }

        private void tbxNum1_TextChanged(object sender, EventArgs e)
        {

        }

        private void tbxNum2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
