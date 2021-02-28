using System;
using System.Collections.Generic;
using System.Text;

namespace CTCI.OOPS.VendingMachine
{
    /*
     * You need to design a Vending Machine which follows the following requirements
        Accepts coins of 1,5,10,25, 50 Cents, i.e., penny, nickel, dime, and quarter as well as 1 and 2 dollar note
        Allow user to select products e.g. CANDY(10), SNACK(50), NUTS(90), Coke(25), Pepsi(35), Soda(45)
        Allow users to take a refund by canceling the request.
        Return the selected product and remaining change if any
        Allow reset operation for vending machine supplier

        Machine 
        //Accept money 
            //validate the amount 
                if invalid then cancel the transaction and reset 
                if valid then display products to select 

       //ValidateMoney(List<Money> money)
       //DisplayProducts() 
            //Based on money show th the options for the product
       //return product ReturnProduct(Product product)
       //return List<Money> ReturnChange(List<Money> moneym, Product product)
       //return List<Money> Refund()
       //CancelOperation()

       Person
       //InsertMoney(Money money)
       //SelectProduct(Product product)
       //CancelOperation

        
     * */
    class VendingMachine
    {

    }

    public enum ProductType
    {
        CANDY = 10, 
        SNACK = 50, 
        NUTS = 90, 
        Coke = 25, 
        Pepsi =  35 , 
        Soda = 45



    }

    public enum Coin_Type
    {
        PENNY = 1,
        NICKEL = 5,
        DIME = 10,
        QUARTER = 25, 
        HALF_DOLLER = 50,
        DOLLER = 100,
        TWO_DOLLER = 200
    }

    public class Product
    {
        private ProductType product_type;
        private int cost;
        private int Quantity;

        public void AddQuantity(int Quantity)
        {
            this.Quantity += Quantity;
        }

        public void RemoveQuantity(int Quantity)
        {
            this.Quantity -= Quantity;
        }

    }

    public class Admin
    {
        string id;
        string userName;
        string Password;

        void AddProduct()
        {

        }

        void DeleteProduct()
        {

        }

    }

    public interface IMachine
    {
        public void AcceptMoney(Coin_Type coin);

        public bool IsValidMoney();
        public List<Product> DisplayProducts();

        public Product ReturnProduct(Product product);

        public List<Coin_Type> ReturnChange(Product product);
        //return List<Money> Refund()
        //CancelOperation()

    }


    public  class Machine : Product, IMachine
    {
        List<Coin_Type> money = new List<Coin_Type>();
        public void AcceptMoney(Coin_Type coin)
        {
            money.Add(coin);
        }

       public bool IsValidMoney()
        {
            return true;
        }
       
        public List<Product> DisplayProducts()
        {
            return new List<Product>();
        }
       
        public Product ReturnProduct(Product product)
        {
            //validate and return 
            RemoveQuantity(1);
            return product;
        }
       public  List<Coin_Type> ReturnChange(Product product)
    {
        return new List<Coin_Type>();
    }
       //return List<Money> Refund()
       //CancelOperation()

    }

    public class Person
    {
        void SelectProduct()
        {

        }
    }


}
