using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test1
{
    class OrderItem
    {
        public string Item { get; set; }
        public double UnitPrice { get; set; }
        public int Amount { get; set; }

        public OrderItem() { }
        public OrderItem(string item,  int amount, double unitprice)
        {
            Item =  item;
            UnitPrice =  unitprice;
            Amount =  amount;
        }

        public override bool Equals(object obj)
        {
            OrderItem m = obj as OrderItem;
            return m != null && m.Item == Item;
              //&& m.UnitPrice == UnitPrice && m.Amount == Amount;
        }

        public override string ToString()
        {
            return Item + "   " +  Amount+ "    " + UnitPrice+"\n";
        }

        public override int GetHashCode()
        {
            
            return  int.Parse(Item);
        }

    }

}
