using Microsoft.VisualStudio.TestTools.UnitTesting;
using test1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test1.Tests
{
    [TestClass()]
    public class OrderServiceTests
    {
        OrderService service;
        [TestInitialize]
        public void Init()
        {
            service = new OrderService();
        }

        [TestMethod()]
        public void OrderServiceTest()
        {
            Assert.IsNotNull(service.orderList);
        }

        [TestMethod()]
        public void AddOrderTest()
        {
            service.AddOrder("test", 1);
            Assert.AreEqual(1, service.orderList[0].ID);
            service.AddOrder("test2", 2);
            Assert.AreEqual(2, service.orderList[1].ID);
        }

        [TestMethod()]
        public void DeleteOrderTest()
        {
            AddOrderTest();
            service.DeleteOrder(1);
            Assert.AreEqual(2, service.orderList[0].ID);
            Assert.AreEqual("test2", service.orderList[0].customer.Name);

        }

        [TestMethod()]
        public void AlterOrderTest()
        {
            AddOrderTest();
            string[] parameter = { "APPLE", "10", "7.2" };
            service.AlterOrder(1,"add item", parameter);
            Assert.AreEqual(72, service.orderList[0].SumPrice);
        }

        [TestMethod()]
        public void SearchOrderTest()
        {
            AddOrderTest();
            List<Order> results = service.SearchOrder("test2", null, null);
            Assert.AreEqual("test2", results[0].customer.Name);
        }

    }
}