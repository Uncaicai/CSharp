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
默认按照订单号排序，也可以使用Lambda表达式进行自定义排序。*/
using System;
using System.Collections.Generic;
using System.Linq;

namespace test1
{
   /* class Order
    {
        public string Number { get; set; }
        public string Product { get; set; }
        public string Client { get; set; }
        public int Age { get; set; }

        public Order(string name, string iD, string major, int age)
        {
            Name = name;
            ID = iD;
            Major = major;
            Age = age;
        }
    }*/
[Serializable]
   public class Order
    {
        //private int id;
        public int ID { get; set; }

        //public string Name { get;  }
        // public string Tel { get;  }

        // public int Time { get; }
        // public string Name { get; set; }
        public Customer customer = new Customer();

        private double sumPrice ;
        public double SumPrice
        {
            get
            {
                this.sumPrice = 0;
                foreach (var orderItem in OrderItems.Values)
                {
                    sumPrice += orderItem.UnitPrice * orderItem.Amount;
                }

                return sumPrice;
            }
            set => sumPrice = value;
        }

        internal Dictionary<string, OrderItem> OrderItems { get => orderItems; set => orderItems = value; }

        private Dictionary<string, OrderItem> orderItems;

        public Order() { }
        public Order(string name,  int id )
        {
            this.ID = id;
            //Time = time;
            this.customer.Name=name;

            this.OrderItems = new Dictionary<string, OrderItem>();
            // Tel = telephone;
        }
       

        public void AddOrderItem(string item, int amount, double unitprice)
        {
            OrderItem orderItem = new OrderItem(item, amount,unitprice);
            if (OrderItems.Keys.Contains(item))
            {
                OrderItems[item].Amount += amount;
            }
            else OrderItems.Add(item, new OrderItem(item, amount, unitprice));
            
        }

        public void DeleteItems(string item, int amount) {


            if (OrderItems.Keys.Contains(item) && OrderItems[item].Amount > amount)
            {
                OrderItems[item].Amount -= amount;
            }
            else if (OrderItems.Keys.Contains(item) && OrderItems[item].Amount <= amount)
                OrderItems.Remove(item);

        }

        /* public override bool Equals(object obj)
         {
             Order m = obj as Order;
             return m != null && m.ID == ID;
             //&& m.UnitPrice == UnitPrice && m.Amount == Amount;
         }*/
        public override string ToString()
        {
            return $"[ID={ID}, customer={customer.Name},SumPrice={sumPrice}]" ;
        }
        public  string ToString1()
        {
            string result = "";
            result += "-----------------------------\n";
            result += "ID: " + ID + "\n";
            result += "Customer: " + customer.Name + "\n";
            result += "-----------------------------\n";
            result += "Item Name   Price    Quantity\n";
            foreach (var orderItem in OrderItems.Values)
            {
                result += orderItem.ToString();
            }
            result += "-----------------------------\n";
            result += "Total Price: " + SumPrice + "\n";
            result += "-----------------------------\n";

            return result;
        }

        public override bool Equals(object obj)
        {
            return obj is Order order &&
                   EqualityComparer<Customer>.Default.Equals(customer, order.customer) &&
                   EqualityComparer<Dictionary<string, OrderItem>>.Default.Equals(OrderItems, order.OrderItems) &&
                   sumPrice == order.sumPrice;
        }

       
    }
}
