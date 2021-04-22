using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CodingChallengeDemetrioAlvaradoG
{
    public partial class Main : System.Web.UI.Page
    {
        public IList<Coins> coinLabels = new List<Coins>();
        public IList<Products> productLabels = new List<Products>();
        BusinessLogic.BLogic BLogic = new BusinessLogic.BLogic();
        public decimal prod1Price;
        public decimal prod2Price;
        public decimal Prod3Price;

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                BLogic.loadFromDB();
            }

            loadProductLabelsAndStock();



        }
        //Function to charge the drinks, deliver the drinks and  return the change
        protected void btnGetDrinks_Click(object sender, EventArgs e)
        {
            int cents = Int32.Parse(txtCent.Text);
            int penny = Int32.Parse(txtPenny.Text);
            int nickel = Int32.Parse(txtNickel.Text);
            int quarter = Int32.Parse(txtQuarter.Text);
            int totalToPay = orderTotal();
            int amountLoaded = userMoneyAmoundLoaded();
            int change = amountLoaded - totalToPay;
            if (change >= 0) {
                UpdateCoins(1, coinLabels[0].quantity + cents);
                UpdateCoins(2, coinLabels[1].quantity + penny);
                UpdateCoins(3, coinLabels[2].quantity + nickel);
                UpdateCoins(4, coinLabels[3].quantity + quarter);
                int prodQty1 = Int32.Parse(txtProd1.Text);
                int prodQty2 = Int32.Parse(txtProd2.Text);
                int prodQty3 = Int32.Parse(txtProd3.Text);
                updateProductStock(1, productLabels[0].quantity - prodQty1);
                updateProductStock(2, productLabels[1].quantity - prodQty2);
                updateProductStock(3, productLabels[2].quantity - prodQty3);
                lblOrder.Text = $"Ordered Coke {prodQty1},  Pepsi{prodQty2},  Soda {prodQty3}";
                loadProductLabelsAndStock();
                getCoinsReturned(change);
                cleanMachine();
                loadProductLabelsAndStock();

            }
            else
            {
                lblNoEnough.Text = "Not suficiente money to cover the order total";
            }
            
        }

        //Function to keep update the amount of the order
        protected void getTotal_TextChanged(object sender, EventArgs e)
        {

            lblTotal.Text =$"{orderTotal()} cents/Dollars";
        }

        public int orderTotal()
        {
            int prodQty1 = Int32.Parse(txtProd1.Text);
            int prodQty2 = Int32.Parse(txtProd2.Text);
            int prodQty3 = Int32.Parse(txtProd3.Text);
            int orderTotal = (prodQty1 * productLabels[0].cost) + (prodQty2 * productLabels[1].cost) + (prodQty3 * productLabels[2].cost);

            return orderTotal;
        }

        //Function to fetch the money inserted by the user
        public int userMoneyAmoundLoaded()
        {
            int cents = Int32.Parse(txtCent.Text);
            int penny = Int32.Parse(txtPenny.Text);
            int nickel = Int32.Parse(txtNickel.Text);
            int quarter = Int32.Parse(txtQuarter.Text);

            int amountLoaded = (cents * coinLabels[0].value) + (penny * coinLabels[1].value) + (nickel * coinLabels[2].value) + (quarter * coinLabels[3].value);

            return amountLoaded;
        }

        //Function to update the stock of the products in the machine
        public void updateProductStock(int idProduct, int qty)
        {
            BLogic.updateProductStock(idProduct, qty);
        }
        //Function to clean the textbox of the machine
        public void cleanMachine()
        {
            txtCent.Text=0.ToString();
            txtPenny.Text = 0.ToString();
            txtNickel.Text = 0.ToString();
            txtQuarter.Text = 0.ToString();
            txtProd1.Text = 0.ToString();
            txtProd2.Text = 0.ToString();
            txtProd3.Text = 0.ToString();
        }

        //Function to keep update the values in the frontend
        public void loadProductLabelsAndStock()
        {
            coinLabels.Clear();
            productLabels.Clear();
            var coinList = BLogic.getCoinsObjects();
            foreach (var item in coinList)
            {
                coinLabels.Add(new Coins(item.id, item.name, item.value, item.quantity));
            }
            var productList = BLogic.getProductsObject();
            foreach (var item in productList)
            {
                productLabels.Add(new Products(item.id, item.name, item.cost, item.quantity));
            }
            lblProd1Details.Text = $"{productLabels[0].quantity} drinks available, Cost = {productLabels[0].cost}";
            lblProd2Details.Text = $"{productLabels[1].quantity} drinks available, Cost = {productLabels[1].cost}";
            lblProd3Details.Text = $"{productLabels[2].quantity} drinks available, Cost = {productLabels[2].cost}";
            if (productLabels[0].quantity < 1)
            {
                txtProd1.Attributes.Add("readonly", "readonly");
            }
            if (productLabels[1].quantity < 1)
            {
                txtProd2.Attributes.Add("readonly", "readonly");
            }
            if (productLabels[2].quantity < 1)
            {
                txtProd3.Attributes.Add("readonly", "readonly");
            }
            lblProd1.Text = productList[0].name;
            lblProd2.Text = productList[1].name;
            lblProd3.Text = productList[2].name;
        }



        //Function to calculate the quantity of coins the change must have
        public bool getCoinsReturned(int changeAmount)
        {
            bool changeOk = false;
            int amountLeft = changeAmount;

            int quarterQty;
            int nickelQty;
            int pennyQty;
            int centQty;

             quarterQty= BLogic.changeQtyCoins(amountLeft, coinLabels[3].value);
            if (coinLabels[3].quantity > quarterQty)
            {
                amountLeft = amountLeft - (quarterQty * coinLabels[3].value);

            }
            
             nickelQty = BLogic.changeQtyCoins(amountLeft, coinLabels[2].value);
            if (coinLabels[2].quantity > 0)
            {
                amountLeft = amountLeft - (nickelQty * coinLabels[2].value);

            }

             pennyQty = BLogic.changeQtyCoins(amountLeft, coinLabels[1].value);
            if (coinLabels[1].quantity > 0)
            {
                amountLeft = amountLeft - (pennyQty * coinLabels[1].value);

            }

             centQty = BLogic.changeQtyCoins(amountLeft, coinLabels[0].value);
            if (coinLabels[0].quantity > 0)
            {
                amountLeft = amountLeft - (centQty * coinLabels[0].value);
            }
            if (amountLeft == 0)
            {
                loadProductLabelsAndStock();
                lblChange.Text = $"The change is {changeAmount}-{centQty} cents-{pennyQty} pennys-{nickelQty} nickel-{quarterQty}quarters";
                UpdateCoins(1, coinLabels[0].quantity- centQty);
                UpdateCoins(2, coinLabels[1].quantity - pennyQty);
                UpdateCoins(3, coinLabels[2].quantity - nickelQty);
                UpdateCoins(4, coinLabels[3].quantity - quarterQty);
                lblMachineMoney.Text = $"Machine Money Reserve -{coinLabels[0].quantity} cents-{coinLabels[1].quantity} pennys-{coinLabels[2].quantity} nickel-{coinLabels[3].quantity} quarters";
                changeOk = true;
            }
            else
            {
                Console.WriteLine("Not sufficient change in the inventory");
            }
            return changeOk;
        }

        //Function to update the coins database qty
        public void UpdateCoins(int idCoin,int qty)
        {
            BLogic.updateCoinsStock(idCoin, qty);
        }

    }
}