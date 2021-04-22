using System;
using System.Collections.Generic;
using System.Text;

namespace Data
{
    public class Coins
    {
        public Coins(int id, string name, decimal value, int quantity)
        {
            this.id = id;
            this.name = name;
            this.value = value;
            this.quantity = quantity;
        }

        public int id { get; set; }
        public string name { get; set; }
        public decimal value { get; set; }
        public int quantity { get; set; }
    }

}

