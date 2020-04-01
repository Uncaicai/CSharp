using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*写一个订单管理的控制台程序，能够实现添加订单、删除订单、修改订单
 * 、查询订单（按照订单号、商品名称、客户等字段进行查询）功能。
提示：主要的类有Order（订单）、OrderItem（订单明细项），
OrderService（订单服务），订单数据可以保存在OrderService中一个List中
。在Program里面可以调用OrderService的方法完成各种订单操作。
要求：
（1）使用LINQ语言实现各种查询功能，查询结果按照订单总金额排序返回。
（2）在订单删除、修改失败时，能够产生异常并显示给客户错误信息。
（3）作业的订单和订单明细类需要重写Equals方法，
确保添加的订单不重复，每个订单的订单明细不重复。
（4）订单、订单明细、客户、货物等类添加ToString方法，
用来显示订单信息。
（5）OrderService提供排序方法对保存的订单进行排序。
默认按照订单号排序，也可以使用Lambda表达式进行自定义排序。

 orderservice 订单操作（增删） 显示订单数据有list  查询功能  抛出异常
               对list信息排序
 order  重写equals，确保添加不重复  显示信息
 orderitem  重写equals，确保添加不重复  显示信息
     */
namespace test1
{

  namespace OrderManagement
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Order Management System!");
            OrderService service = new OrderService();
                string path = @"orders.xml";
                //Person p = new Person { id = 1001, name = "tommy", age = 30 };
                //List<Order> ord = (List<Order>)service.Import(path, typeof(List<Order>)); 
                //foreach (Order ords in ord) { Console.Write(ords.ToString1()); }
                service.Import(path);
                while (true)
            {
                try
                {
                    String orderID;
                    String customerName;
                        Console.WriteLine("\n");
                        String action = GetInput("1.add an order\t2.delete an order\t3.alter your order\t4.sort your orders\nPlease select an action: ");
                    switch (action)
                    {
                        case "1":
                            customerName = GetInput("Customer name:");
                            service.AddOrder(customerName, Int32.Parse(DateTime.Now.ToString("HHmmss")));
                            Console.WriteLine("Add an order successful!");
                                service.PrintOrders(service.orderList);
                            //Console.WriteLine("Your order ID is:" );
                            break;
                        case "2":
                            orderID = GetInput("Order ID:");
                            service.DeleteOrder(Int32.Parse(orderID));
                                Console.WriteLine("Delete the order successful!");
                                service.PrintOrders(service.orderList);

                            break;
                        case "3":
                            orderID = GetInput("Order ID:");
                            String operation = GetInput( "add item\t" +"delete item\nPlease select an operation:" );
                                /*String modifyData = "";
                                if(operation != "add item")
                                {
                                    modifyData = GetInput("The data After modify:");
                                }*/
                            //object data = null;
                            //int goodsID = 0;
                            
                            switch (operation)
                            {
                                case "add item":
                                        Console.WriteLine("Please enter item，amount and unitprice ,Separated by space");
                                        //goodsID = Int32.Parse(GetInput("Goods ID:"));
                                        string[] string1 = System.Text.RegularExpressions.Regex.Split(Console.ReadLine(), @"[ ]+");
                                        string[] par3 = new string[3];
                                        for (int i = 0; i < 3; i++)
                                        {
                                            par3[i] = string1[i];
                                        }
                                        service.AlterOrder(Int32.Parse(orderID), operation, par3);

                                        service.PrintOrders(service.orderList);
                                        break;
                                case "delete item":
                                        Console.WriteLine("Please enter item and amount ,Separated by space");
                                        //goodsID = Int32.Parse(GetInput("Goods ID:"));
                                        string[] string2 = System.Text.RegularExpressions.Regex.Split(Console.ReadLine(), @"[ ]+");
                                        string[] par2 = new string[2];
                                        for (int i = 0; i < 2; i++)
                                        {
                                            par2[i] = (string2[i]);
                                        }
                                        service.AlterOrder(Int32.Parse(orderID), operation, par2);
                                        service.PrintOrders(service.orderList);
                                        break;                              
                                default:
                                        throw new ArgumentException("Invalid input!");
                            }
                            break;
                         case "4":
                             
                             Console.WriteLine("Please enter search conditions:");
                             customerName = GetInput("Customer name:");
                             orderID = GetInput("Order ID:");
                             String goodsName = GetInput("Goods name:");
                             customerName = customerName == "" ? null : customerName;
                             orderID = orderID == "" ? null : orderID;                             
                             goodsName = goodsName == "" ? null : goodsName;
                             //Console.Write(service.SearchOrder(orderID, customerName, goodsName));
                             List<Order> results = service.SearchOrder(customerName, orderID, goodsName);
                             service.PrintOrders(results);
                                /*Console.WriteLine("Result:");
                             foreach(Order order in results)
                             {
                                 Console.WriteLine(order);
                             }*/
                             break;
                          default:
                             throw new ArgumentException("No such operation!");
                    }
                        service.Export(path);
                    }
                catch(ArgumentException e)
                {
                    Console.WriteLine(e.Message);
                }
                catch(FormatException)
                {
                    Console.WriteLine("Invalid input!");
                }
            }
        }
        private static String GetInput(String tip)
        {
            Console.Write(tip);
            return Console.ReadLine();
        }
    }
}

}
