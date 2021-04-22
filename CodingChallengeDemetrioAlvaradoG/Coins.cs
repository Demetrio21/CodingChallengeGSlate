using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CodingChallengeDemetrioAlvaradoG
{
    //class to manage the coins of the machine
    public class Coins
    {
        public Coins(int id, string name, int value, int quantity)
        {
            this.id = id;
            this.name = name;
            this.value = value;
            this.quantity = quantity;
        }

        public int id { get; set; }
        public string name { get; set; }
        public int value { get; set; }
        public int quantity { get; set; }
    }
}
