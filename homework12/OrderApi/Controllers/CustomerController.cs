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
    //根路径：api/customer
    [Route("api/[controller]")]
    public class CustomerController : ControllerBase
    {

        private readonly OrderContext orderDb;

        public CustomerController(OrderContext context)
        {
            this.orderDb = context;
        }
        
        //按顾客号查找顾客
        //GET :api/customer/id
        [HttpGet("{id}")]
        public ActionResult<Customer> GetCustomer(int id)
        {
            //按订单号寻找订单
            var customer = orderDb.Customers.FirstOrDefault(customer => customer.CustomerID == id);
            if (customer == null)
            {
                return NotFound();
            }
            return customer;
        }

        // GET: api/customer
        // 按customer name查询
        [HttpGet]
        public ActionResult<List<Customer>> GetCustomers(string customerName)
        {
            List<Customer> query = orderDb.Customers.ToList();
            if(customerName != null) {
                //按名字找
                query = query.Where(customer => customerName == customer.Name).ToList();
            }
            return query;
        }

        //增加顾客
        // POST: api/customer
        [HttpPost]
        public ActionResult<Customer> PostCustomer(Customer customer)
        {
            try
            {
                orderDb.Customers.Add(customer);
                orderDb.SaveChanges();
            }
            catch (Exception e)
            {
                return BadRequest(e.InnerException.Message);
            }
            return customer;
        }

        //修改顾客
        // PUT: api/customer/id
        [HttpPut("{id}")]
        public ActionResult<Customer> PutCustomer(int id, Customer customer)
        {
            if (id != customer.CustomerID)
            {
                return BadRequest("Id cannot be modified!");
            }
            try
            {
                orderDb.Entry(customer).State = EntityState.Modified;
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
        
        //删除顾客
        // DELETE: api/customer/id
        [HttpDelete("{id}")]
        public ActionResult DeleteCustomer(int id)
        {
            //该顾客有订单不能删除
            if(orderDb.Orders.Count(order => order.CustomerID == id) > 0) {
                return BadRequest("This customer has orders!");
            }
            try
            {
                var customer = orderDb.Customers.FirstOrDefault(customer => customer.CustomerID == id);
                if (customer != null)
                {
                    orderDb.Remove(customer);
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