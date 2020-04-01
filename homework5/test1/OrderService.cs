using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace test1
{
    class OrderService
    {
        public List<Order> orderList { get; set; }
        int orderAmount;

        public OrderService()
        {
            orderList = new List<Order>();
            Console.WriteLine("My Store:");
            Console.WriteLine("-------------------------------");
            Console.WriteLine(" Item                  Price");
            Console.WriteLine(" APPLE                 7.2 ");
            Console.WriteLine(" BANANA                10 ");
            Console.WriteLine(" GRAPE                 8.7 ");
            Console.WriteLine(" CHIP                  6.3");
            Console.WriteLine(" TEA                   3.5");
            Console.WriteLine(" COFFEE                26");
            Console.WriteLine(" IPHONE                12699 ");
            Console.WriteLine(" IPAD                  10299");
            Console.WriteLine(" PERFUME               1099");
            Console.WriteLine("-------------------------------");
            Console.WriteLine("-------------------------------");

            // Console.WriteLine("How many orders do you want to make?");
        }
        public void AddOrder(string name, int id)
        {

            Order order = new Order(name, id);
            bool isRepeat = false;
            foreach (Order a in orderList)
            {
                if (a.Equals(order))
                {
                    isRepeat = true;
                }
                else
                {
                    isRepeat = false;
                }
            }
            if (!isRepeat)
            {
                orderList.Add(order);
                orderAmount++;
            }
        }

        public void DeleteOrder(int id)
        {
            foreach (Order a in orderList)
            {
                if (a.ID == id)
                {
                    orderList.Remove(a);
                    orderAmount--;
                    return;
                }
            }
            throw new ArgumentException("Invalid order!");
        }
        //修改订单，alterType为修改项
        //如果要对订单明细进行修改，则还应传入要修改的商品号
        public void AlterOrder(int id, String alterType, string[] parameter)
        {
            Order alterOrder = null;
            foreach (Order a in orderList)
            {
                if (a.ID == id)
                {
                    alterOrder = a;
                    break;
                }
            }
            if (alterOrder == null)
            {
                throw new ArgumentException("Invalid order!");
            }
            switch (alterType)
            {

                case "add item": alterOrder.AddOrderItem(parameter[0], int.Parse(parameter[1]), double.Parse(parameter[2])); break;
                case "delete item": alterOrder.DeleteItems(parameter[0], int.Parse(parameter[1])); break;
                default: throw new ArgumentException("No such operation!");
            }
        }

        public List<Order> SearchOrder(string customerName, string number, string itemName)//查询订单
        {
            var searchByCustomer = orderList.Where(s => s.customer.Name == customerName);//通过订单号查询
                                                                                         // var searchBycustomer = orderList.Where(s => s.customer.Name.Equals(customerName));//通过用户名查询
                                                                                         // var searchBycargo = orderList.Where(s => s.Name.Equals(cargoName));//通过商品名称查询
            var searchByNumAndCustomer = searchByCustomer.Where(s => s.ID == int.Parse(number)); //通过订单号和客户名查询

            var searchByAll = searchByNumAndCustomer.Where(s => s.OrderItems[itemName].Item == itemName);
            /* if (number != null)
             {
                if (itemName != null) { var searchByAll = searchByNumAndCustomer.Where(s => s.orderItems[itemName].Item == itemName);
                 }//通过订单号，客户名，商品名查询*/

            List<Order> list = new List<Order>();
            if (number == null && customerName != null && itemName == null)
            {
                foreach (var s in searchByCustomer)
                {
                    list.Add(s);
                }
                return list;
            }
            if (number != null && customerName != null && itemName == null)
            {
                foreach (var s in searchByNumAndCustomer)
                {
                    list.Add(s);
                }
                return list;
            }
            if (number != null && customerName != null && itemName != null)
            {
                foreach (var s in searchByAll)
                {
                    list.Add(s);
                }
                return list;
            }
            else
            {
                Console.WriteLine("查询输入参数出错！");
                return null;
            }


        }

        public void Sort(Comparison<Order> comparison = null)
        {
            //默认按照订单号排序
            if (comparison == null)
            {
                orderList.Sort((order1, order2) => order1.ID - order2.ID);
            }
            //自定义排序
            else
            {
                orderList.Sort(comparison);
            }
        }

        public void PrintOrders(List<Order> orderList1)
        {
            Console.WriteLine("\n");
            if (orderList1 != null)
            {
                for (int i = 0; i < orderList1.Count; i++)
                {
                    Console.WriteLine($"{orderList1[i].ToString1()}");
                    Console.WriteLine(" ");
                }
            }
        }



        /// <summary>
        /// serialize object to xml file.
        /// </summary>
        /// <param name="path">the path to save the xml file</param>
        /// <param name="obj">the object you want to serialize</param>
        /* public void Export(string path, object obj)
         {
             XmlSerializer serializer = new XmlSerializer(obj.GetType());
             string content = string.Empty;
             //serialize
             using (StringWriter writer = new StringWriter())
             {
                 serializer.Serialize(writer, obj);
                 content = writer.ToString();
             }
             //save to file
             using (StreamWriter stream_writer = new StreamWriter(path))
             {
                 stream_writer.Write(content);
             }
         }

         /// <summary>
         /// deserialize xml file to object
         /// </summary>
         /// <param name="path">the path of the xml file</param>
         /// <param name="object_type">the object type you want to deserialize</param>
         public object Import(string path, Type object_type)
         {
             XmlSerializer serializer = new XmlSerializer(object_type);
             using (StreamReader reader = new StreamReader(path))
             {
                 return serializer.Deserialize(reader);
             }
         }*/

        public void Export(String path)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Order>));
            using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
            {
                xmlSerializer.Serialize(fs, orderList);
            }
        }

        public void Import(String path)
        {
           /* XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Order>));
            using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
            {
                orderList = (List<Order>)xmlSerializer.Deserialize(fs);
            }*/


            XmlSerializer formatter = new XmlSerializer(typeof(List<Order>));
            using (FileStream stream = new FileStream(path, FileMode.OpenOrCreate))
            {
             XmlReader xmlReader = new XmlTextReader(stream);
             List<Order> outBook = formatter.Deserialize(xmlReader) as List<Order>;//反序列化
               
                if (outBook != null)
                {
                     Console.WriteLine("xml orders:\n");
                    for (int i = 0; i < outBook.Count; i++)
                    {
                        Console.WriteLine($"{outBook[i].ToString()}");

                    }
                }
            }
            //Console.Read();

        }
    }
}
