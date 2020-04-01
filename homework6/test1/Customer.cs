using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test1
{


        public class Customer   //客户
        {
            public string Name { set; get; }
        public Customer() { }
        public Customer(string name) { Name = name; }
        public override string ToString()//客户信息
            {
            return "客户名：" + this.Name;
            }
        }
    
}
