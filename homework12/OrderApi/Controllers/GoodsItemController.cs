using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using OrderApi.Models;

namespace OrderApi.Controllers
{
    //说明该类是控制器类
    [ApiController]
    //根路径：api/goodsitem
    [Route("api/[controller]")]
    public class GoodsItemController : ControllerBase
    {

        private readonly OrderContext orderDb;

        public GoodsItemController(OrderContext context)
        {
            this.orderDb = context;
        }

        //GET :api/goodsitem/id
        [HttpGet("{id}")]
        public ActionResult<GoodsItem> GetGoods(int id)
        {
            //按商品号寻找商品
            var goods = orderDb.GoodsItems.FirstOrDefault(order => order.GoodsItemID == id);
            if (goods == null)
            {
                return NotFound();
            }
            return goods;
        }

        // GET: api/goodsitem
        // 按goods name查询
        [HttpGet]
        public ActionResult<List<GoodsItem>> GetGoodsItems(string goodsName)
        {
            List<GoodsItem> query = orderDb.GoodsItems.ToList();
            if(goodsName != null) {
                //按商品名字找
                query = query.Where(goods => goodsName == goods.Name).ToList();
            }
            return query;
        }

        //增加商品
        // POST: api/goodsitem
        [HttpPost]
        public ActionResult<GoodsItem> PostGoodsItem(GoodsItem goods)
        {
            try
            {
                orderDb.GoodsItems.Add(goods);
                orderDb.SaveChanges();
            }
            catch (Exception e)
            {
                return BadRequest(e.InnerException.Message);
            }
            return goods;
        }

        //修改商品
        // PUT: api/goodsitem
        [HttpPut("{id}")]
        public ActionResult<GoodsItem> PutGoodsItem(int id, GoodsItem goods)
        {
            if (id != goods.GoodsItemID)
            {
                return BadRequest("Id cannot be modified!");
            }
            try
            {
                orderDb.Entry(goods).State = EntityState.Modified;
                orderDb.SaveChanges();
            }
            catch (Exception e)
            {
                string error = e.Message;
                if (e.InnerException != null) error = e.InnerException.Message;
                return BadRequest(error);
            }
            return NoContent();
        }
        
        //删除商品
        // DELETE: api/goodsitem
        [HttpDelete("{id}")]
        public ActionResult DeleteGoodsItem(int id)
        {
            //有订单含有该商品是不能删除
            if(orderDb.OrderItems.Count(item => item.GoodsItemID == id) > 0) {
                return BadRequest("This goods cannot be deleted!");
            }
            try
            {
                var goods = orderDb.GoodsItems.FirstOrDefault(goods => goods.GoodsItemID == id);
                if (goods != null)
                {
                    orderDb.Remove(goods);
                    orderDb.SaveChanges();
                }
            }
            catch (Exception e)
            {
                return BadRequest(e.InnerException.Message);
            }
            return NoContent();
        }

    }
}