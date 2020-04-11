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
using static test1.Form3;

namespace test1
{

    public partial class Form1 : Form
    {


        public OrderService os = new OrderService();
        public List<Order> orders;
        public string KeyWord { get; set; }
        public Form1()
        {
            InitializeComponent();
            OrderItem apple = new OrderItem(1, "apple", 10.0, 80);
            OrderItem egg = new OrderItem(2, "eggs", 1.2, 200);
            OrderItem milk = new OrderItem(3, "milk", 50, 10);

            Order order1 = new Order(1, "Customer1", new List<OrderItem> { apple, egg, milk });
            Order order2 = new Order(2, "Customer2", new List<OrderItem> { egg, milk });
            Order order3 = new Order(3, "Customer2", new List<OrderItem> { apple, milk });

            os.AddOrder(order1);
            os.AddOrder(order2);
            os.AddOrder(order3);
            orders = os.Orders;
            OrderBindingSource.DataSource = orders;
            //绑定查询条件
            queryInput.DataBindings.Add("Text", this, "KeyWord");
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            switch (SearchWay.SelectedItem) {
            case "商品名称":
                    if (KeyWord == null || KeyWord == "")
                    {
                        OrderBindingSource.DataSource = orders;
                    }
                    else
                    {
                        OrderBindingSource.DataSource =
                            os.QueryOrdersByGoodsName(KeyWord);
                    }
                    OrderBindingSource.ResetBindings(false);
                    itemsBindingSource.ResetBindings(false);
                    break;
                    
            case "客户名称":
                    if (KeyWord == null || KeyWord == "")
                    {
                        OrderBindingSource.DataSource = orders;
                    }
                    else
                    {
                        OrderBindingSource.DataSource =
                            os.QueryOrdersByCustomerName(KeyWord);
                    }
                    OrderBindingSource.ResetBindings(false);
                    itemsBindingSource.ResetBindings(false);
                    break;
            case "订单价格":
            default:
                    
                        os.Sort((o1, o2) => o1.TotalPrice.CompareTo(o2.TotalPrice));
                        orders = os.Orders;
                        OrderBindingSource.DataSource = orders;
                    OrderBindingSource.ResetBindings(false);
                    itemsBindingSource.ResetBindings(false);
                    break;




        }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 f = new Form2();
            f.Owner = this; //设置查找窗体的父窗体为本窗体
            f.CreateOrder += new Form2.CreateOrderHandler(CreateOrder);
            f.ShowDialog();
            OrderBindingSource.ResetBindings(false);
            /*Order orde = new Order(3, "Customer2", new List<OrderItem> { apple, milk });

            os.AddOrder(order1);*/
        }

        public void CreateOrder(object sender, CreateOrderEventArgs args)

        {
            Order order = new Order(args.ID, args.Customer, args.Items);
            // 更新窗体控件
            if (orders.Contains(order))
                MessageBox.Show($"Add Order Error: Order with id {order.OrderId} already exists!");
                os.AddOrder(order);

        }
        private void button6_Click(object sender, EventArgs e)
        {
            
                //string localFilePath, fileNameExt, newFileName, FilePath;
                SaveFileDialog sfd = new SaveFileDialog();
                //设置文件类型
                sfd.Filter = "orders（*.xml）|*.xml";

                //设置默认文件类型显示顺序
                sfd.FilterIndex = 1;

                //保存对话框是否记忆上次打开的目录
                sfd.RestoreDirectory = true;

                //点了保存按钮进入
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    
                    string localFilePath = sfd.FileName.ToString(); //获得文件路径
                    string fileNameExt = localFilePath.Substring(localFilePath.LastIndexOf("\\") + 1); //获取文件名，不带路径
                    os.Export(localFilePath);
                //获取文件路径，不带文件名
                //FilePath = localFilePath.Substring(0, localFilePath.LastIndexOf("\\"));

                //给文件名前加上时间
                //newFileName = DateTime.Now.ToString("yyyyMMdd") + fileNameExt;

                //在文件名里加字符
                //saveFileDialog1.FileName.Insert(1,"dameng");

                //System.IO.FileStream fs = (System.IO.FileStream)sfd.OpenFile();//输出文件

                ////fs输出带文字或图片的文件，就看需求了
            }
            
           
        }

        private void button4_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Title = "C# Corner Open File Dialog";
            openFileDialog1.InitialDirectory = @"c:\";
            openFileDialog1.Filter = "All files（*.xml*）|*.xml";
            /*
             * FilterIndex 属性用于选择了何种文件类型,缺省设置为0,系统取Filter属性设置第一项
             * ,相当于FilterIndex 属性设置为1.如果你编了3个文件类型，当FilterIndex ＝2时是指第2个.
             */
            openFileDialog1.FilterIndex = 2;
            /*
             *如果值为false，那么下一次选择文件的初始目录是上一次你选择的那个目录，
             *不固定；如果值为true，每次打开这个对话框初始目录不随你的选择而改变，是固定的  
             */
            openFileDialog1.RestoreDirectory = true;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                os.Import(System.IO.Path.GetFullPath(openFileDialog1.FileName));
                //System.IO.Path.GetFullPath(openFileDialog1.FileName); //绝对路径
                //System.IO.Path.GetExtension(openFileDialog1.FileName); //文件扩展名
                //System.IO.Path.GetFileNameWithoutExtension(openFileDialog1.FileName); //文件名没有扩展名
                //System.IO.Path.GetFileName(openFileDialog1.FileName); //得到文件
                //System.IO.Path.GetDirectoryName(openFileDialog1.FileName); //得到路径
            }
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int position = OrderBindingSource.Position;
            //string orderid = Convert.ToString(dataGridView1.Rows[position].Cells[0].Value);
            //MessageBox.Show(orderid);
            os.RemoveOrder(Convert.ToUInt32(dataGridView1.Rows[position].Cells[0].Value));
            OrderBindingSource.ResetBindings(false);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form3 f3 = new Form3(this.orders);
            f3.Owner = this; //设置查找窗体的父窗体为本窗体
            f3.UpdateOrder += new Form3.UpdateOrderHandler(UpdateOrder);
            f3.ShowDialog();
            OrderBindingSource.ResetBindings(false);
            /*Order orde = new Order(3, "Customer2", new List<OrderItem> { apple, milk });

            os.AddOrder(order1);*/
        }
        public void UpdateOrder(object sender, UpdateOrderEventArgs args)

        {
            Order order = new Order(args.ID, args.Customer, args.Items);
            // 更新窗体控件
            if (!(orders.Contains(order)))
                MessageBox.Show($"Update Order Error: Order with id {order.OrderId} did not exists!");
            os.UpdateOrder(order);

        }
    }
}

