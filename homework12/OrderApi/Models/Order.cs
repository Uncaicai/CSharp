using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OrderApi.Models {
    //订单类
    public class Order {
        //主键
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OrderID{get;set;}
        
        //外键
        [ForeignKey("CustomerID")]
        public int CustomerID{get;set;}
        public Customer Customer { get; set; }

        public List<OrderItem> OrderItems{get;set;}
        public DateTime OrderTime{get;set;}
        public int TotalQuantity{
            get {
                int totalQuantity = 0;
                foreach (OrderItem orderItem in OrderItems)
                {
                    totalQuantity += orderItem.Quantity;
                }
                return totalQuantity;
            }
        }
        public double TotalPrice {
            get => OrderItems==null ? 0: OrderItems.Sum(item => item.TotalPrice);
        }

        public Order() {
            OrderTime = DateTime.Now;
        }
    }
}