using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic
{
    //Class to manage the  products of the machine
    public class Products
    {
        public Products(int id, string name, int cost, int quantity)
        {
            this.id = id;
            this.name = name;
            this.cost = cost;
            this.quantity = quantity;
        }

        public int id { get; set; }
        public string name { get; set; }
        public int cost { get; set; }
        public int quantity { get; set; }
    }
}
