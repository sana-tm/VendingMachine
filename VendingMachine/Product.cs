using System;
using System.Collections.Generic;
using System.Text;

namespace VendingMachine
{
    //BASE CLASS for the product type.
    abstract class Product
    {
        public string Name { get; set; }
        public int ProductNumber { get; set; }
        public int Price { get; set; }
        public string Instructions { get; set; }

        protected Product(string name, int productNum, int price, string instructions)
        {
            this.Name = name;
            this.ProductNumber = productNum;
            this.Price = price;
            this.Instructions = instructions;
        }

        //Purchase is done only if the user has enough balance in the machine.
        //Returns the remaining money.
        public int Purchase(int totalRemainingMoney)
        {
            int temp = totalRemainingMoney;
            totalRemainingMoney = totalRemainingMoney - Price;
            if (totalRemainingMoney >= 0)
            {
                Console.WriteLine($"{Name} purchased");
                this.Use();
            }
            else
            {
                Console.WriteLine($"Not enough money to buy {Name}");
            }

            return totalRemainingMoney >= 0 ? totalRemainingMoney : temp;

        }

        public abstract void Examine();
        public abstract void Use();

    }


}
