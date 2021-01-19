using System;
using System.Collections.Generic;
using System.Text;

namespace VendingMachine
{
    //Derived Class
    class Chocolate : Product
    {
        public Chocolate(string name, int productNum, int price, string instructions) : base(name, productNum, price, instructions)
        {

        }

        //Displays the product information.
        public override void Examine()
        {
            Console.WriteLine("Chocolate: " + Name + "\t" +
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
