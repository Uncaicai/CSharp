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

    public partial class Form3 : Form

    {

        // 定义委托

        // public delegate void DataChangeHandler(string x); 一次可以传递一个string

        public delegate void UpdateOrderHandler(object sender, UpdateOrderEventArgs args);

        // 声明事件

        public event UpdateOrderHandler UpdateOrder;

        public List<Order> ords;

        // 调用事件函数

        public void OnDataChange(object sender, UpdateOrderEventArgs args)

        {

            if (UpdateOrder != null)

            {

                UpdateOrder(this, args);

            }

        }

        public Form3() {
            InitializeComponent();
        }


        public Form3(List<Order> orders)

        {
            InitializeComponent();
            List<uint> UpdateId = new List<uint>();
            ords = orders;
            foreach (var a in ords) {
                UpdateId.Add(a.OrderId);
            }
            comboBox1.DataSource = UpdateId;


        }



        private void button1_Click(object sender, EventArgs e)

        {

            // 触发事件， 传递自定义参数
            string UpdateId = Convert.ToString(comboBox1.SelectedItem);
            OnDataChange(this, new UpdateOrderEventArgs(UpdateId, textBox2.Text, textBox3.Text, textBox4.Text, textBox5.Text));

            this.Close();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            uint id = uint.Parse(comboBox1.Text);
            Order ord = ords.Where(o => o.OrderId == id).FirstOrDefault();
            textBox2.Text = ord.Customer;
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            List<OrderItem> items = ord.Items;
            foreach (var a in items) {
                if (a.Index == 1) { textBox3.Text = Convert.ToString(a.Quantity) ; }
                if (a.Index == 2) { textBox4.Text = Convert.ToString(a.Quantity); }
                if (a.Index == 3) { textBox5.Text = Convert.ToString(a.Quantity); }
            }
        }

        public class UpdateOrderEventArgs : EventArgs

        {

            public uint ID { get; set; }

            public string Customer { get; set; }

            //public List<OrderItem> items = new List<OrderItem>();
            public List<OrderItem> Items { get; set; }
            public UpdateOrderEventArgs(string id, string customer, string amount1, string amount2, string amount3)

            {

                ID = uint.Parse(id);

                Customer = customer;
                List<OrderItem> items = new List<OrderItem>();

                if (!(amount1 == "" || amount1 == null || amount1 == "0"))
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
}