//订单明细类
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace OrderApi.Models {
    public class OrderItem {
        //key
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OrderItemID{get;set;}
        //外键
        [ForeignKey("GoodsItemID")]
        public int GoodsItemID{get;set;}
        public GoodsItem GoodsItem { get; set; }

        [ForeignKey("OrderID")]
        public int OrderID{ get; set; }
        //public Order Order { get; set; }
        public int Quantity{get;set;}
         public double TotalPrice {
             get => GoodsItem == null ? 0:GoodsItem.Price * (double)Quantity;
         }
    }
}