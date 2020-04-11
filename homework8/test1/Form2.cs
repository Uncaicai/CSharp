using OrderApp;
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

    public partial class Form2 : Form

    {

        // 定义委托

        // public delegate void DataChangeHandler(string x); 一次可以传递一个string

        public delegate void CreateOrderHandler(object sender, CreateOrderEventArgs args);

        // 声明事件

        public event CreateOrderHandler CreateOrder;



        // 调用事件函数

        public void OnDataChange(object sender, CreateOrderEventArgs args)

        {

            if (CreateOrder != null)

            {

                CreateOrder(this, args);

            }

        }



        public Form2()

        {

            InitializeComponent();

        }



        private void button1_Click(object sender, EventArgs e)

        {

            // 触发事件， 传递自定义参数

            OnDataChange(this, new CreateOrderEventArgs(textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text, textBox5.Text));

            this.Close();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }

    public class CreateOrderEventArgs : EventArgs

    {

        public uint ID { get; set; }

        public string Customer { get; set; }

        //public List<OrderItem> items = new List<OrderItem>();
        public List<OrderItem> Items { get; set; }
    public CreateOrderEventArgs(string id, string customer,string amount1, string amount2, string amount3)

        {

            ID = uint.Parse(id);

            Customer = customer;
            List<OrderItem> items = new List<OrderItem>();

            if (!(amount1 == "" || amount1==null||amount1=="0"))
            {
                OrderItem apple = new OrderItem(1, "apple", 10.0, uint.Parse(amount1));
                items.Add(apple);
            }
            if (!(amount2 == "" || amount2 == null || amount2 == "0"))
            {
                OrderItem egg = new OrderItem(2, "eggs", 1.2, uint.Parse(amount2));
                items.Add(egg);
            }
            if (!(amount3 == "" || amount3 == null || amount3 == "0"))
            {
                OrderItem milk = new OrderItem(3, "milk", 50, uint.Parse(amount3));
                items.Add(milk);
            }
            Items = items;


        }

    }


}
