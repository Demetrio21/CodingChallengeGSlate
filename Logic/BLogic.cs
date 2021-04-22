using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace BusinessLogic
{
    //class to manage the business logic
    public class BLogic
    {
        //List of objects to manage the simulation of the data base
        public static List<Coins> coinsList = new List<Coins>();
        public static List<Products> productsList = new List<Products>();


        //Method to load the data in the objects
        public void loadFromDB()
        {
            coinsList.Add(new Coins(1, "Cent", 1, 100));
            coinsList.Add(new Coins(2, "Penny", 5, 10));
            coinsList.Add(new Coins(3, "Nickel", 10, 5));
            coinsList.Add(new Coins(4, "Quarter", 25, 25));

            productsList.Add(new Products(1, "Coke", 25, 5));
            productsList.Add(new Products(2, "Pepsi", 36, 15));
            productsList.Add(new Products(3, "Soda", 45, 3));
        }


        //Method to get the data of the list of coins objects
        public List<Coins> getCoinsObjects()
        {
            return coinsList;
        }
        //Method to get the data of the list of products objects
        public List<Products> getProductsObject()
        {
            return productsList;
        }
        //Method to update the object list of products
        public bool updateProductStock(int idProduct, int qty)
        {
            bool isUpdated = false;
            foreach (var item in productsList)
            {
                if(item.id== idProduct)
                {
                    item.quantity = qty;
                }
            }
            return isUpdated;
        }
        //Method to update the object list of coins
        public bool updateCoinsStock(int idCoin, int qty)
        {
            bool isUpdated = false;
            foreach (var item in coinsList)
            {
                if (item.id == idCoin)
                {
                    item.quantity = qty;
                }
            }
            return isUpdated;
        }

        //Function to return que quantity of coins to be returnd of each type
        public int changeQtyCoins(int changeAmount, int coinValue)
        {
            int coinQty = (int)(changeAmount / coinValue);
            return coinQty;
        }
    }
}
