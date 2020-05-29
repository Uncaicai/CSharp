//商品类
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace OrderApi.Models {
    public class GoodsItem{
        //key
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int GoodsItemID{get;set;}
        //商品名
        [Required]
        public string Name{get;set;}
        //商品价格
        public double Price{get;set;}
    }
}