using System;
using System.Collections.Generic;
using System.Text;

namespace Data
{
   public class Products
    {
        public Products(int id, string name, decimal cost, int quantity)
        {
            this.id = id;
            this.name = name;
            this.cost = cost;
            this.quantity = quantity;
        }

        public int id { get; set; }
        public string name { get; set; }
        public decimal cost { get; set; }
        public int quantity { get; set; }
    }
}
