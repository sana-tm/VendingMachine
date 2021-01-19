using System;
using System.Collections.Generic;
using System.Text;

namespace VendingMachine
{
    //Derived Class
    class Drinks : Product
    {
        
        public Drinks(string name, int productNum, int price, string instructions) : base(name, productNum, price, instructions)
        {

        }

        //Displays the product information.
        public override void Examine()
        {
            Console.WriteLine("Drink: " + Name + "\t" +
                    " Product Number: " + ProductNumber + "\t" +
                    " Price: " + Price);
        }

        //Displays how to use the product.
        public override void Use()
        {
            Console.WriteLine($"{Name} can be used  as {Instructions} ");
        }
    }
}
