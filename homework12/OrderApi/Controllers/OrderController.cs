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
    //根路径：api/order
    [Route("api/[controller]")]
    public class OrderController : ControllerBase
    {

        private readonly OrderContext orderDb;

        public OrderController(OrderContext context)
        {
            this.orderDb = context;
        }

        private IQueryable<Order> AllOrders(OrderContext db) {
            var orders = db.Orders.Include("Customer").Include("OrderItems").ToList();
            for(int i = 0;i < orders.Count;i++) {
                for(int j = 0;j < orders[i].OrderItems.Count;j++) {
                    GoodsItem goodsItem = db.GoodsItems.FirstOrDefault(item => item.GoodsItemID == orders[i].OrderItems[j].GoodsItemID);
                    orders[i].OrderItems[j].GoodsItem = goodsItem;
                }
            }
            return orders.AsQueryable();
        }

        //GET :api/order/id
        [HttpGet("{id}")]
        public ActionResult<Order> GetOrder(int id)
        {
            //按订单号寻找订单
            var order = AllOrders(orderDb).FirstOrDefault(order => order.OrderID == id);
            if (order == null)
            {
                return NotFound();
            }
            return order;
        }

        // GET: api/order
        // 按customer name,goods name查询
        [HttpGet]
        public ActionResult<List<Order>> GetOrders(string customerName, string goodsName)
        {
            IQueryable<Order> query = AllOrders(orderDb);
            if(customerName != null) {
                //按顾客名字找
                query = query.Where(order => customerName == 
                    //从顾客数据库中找到与order用户ID相同的顾客
                    orderDb.Customers.FirstOrDefault(customer => customer.CustomerID == order.Customer.CustomerID).Name);
            }
            if(goodsName != null) {
                //按商品名字找
                query = query.Where(order => 
                    order.OrderItems.Count(item => item.GoodsItem.Name == goodsName) > 0);
            }
            return query.ToList();
        }

        //增加订单
        // POST: api/order
        [HttpPost]
        public ActionResult<Order> PostOrder(Order order)
        {
            try
            {
                orderDb.Orders.Add(order);
                orderDb.OrderItems.AddRange(order.OrderItems);
                orderDb.SaveChanges();
            }
            catch (Exception e)
            {
                return BadRequest(e.InnerException.Message);
            }
            return order;
        }

        //修改订单
        // PUT: api/order/id
        [HttpPut("{id}")]
        public ActionResult<Order> PutOrder(int id, Order order)
        {
            if (id != order.OrderID)
            {
                return BadRequest("Id cannot be modified!");
            }
            try
            {
                orderDb.Entry(order).State = EntityState.Modified;
                foreach(OrderItem item in order.OrderItems) {
                    orderDb.Entry(item).State = EntityState.Modified;
                }
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
        
        //删除订单
        // DELETE: api/order/id
        [HttpDelete("{id}")]
        public ActionResult DeleteOrder(int id)
        {
            try
            {
                var order = AllOrders(orderDb).Include("OrderItems").FirstOrDefault(order => order.OrderID == id);
                if (order != null)
                {
                    orderDb.Remove(order);
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