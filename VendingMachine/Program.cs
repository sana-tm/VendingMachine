
/* This Vending Machine program takes comma seperated cash input according to predefined denominations.
 * The user selects the product number of the desired item from the provided list. 
 * If more quantity of same product types are required then the product numbers should be given comma seperated.
 * It displays the products purchased or not, depending on the balance.
 * Also displays how to use the product.
 * The remaining change is returned in the predifined denominations.
 * At any point of time if the user gives invalid input, throws an exception and exits from the Program.
 */


using System;
using System.Collections.Generic;

namespace VendingMachine

{
    class Program
    {        
        //Creating Inventory List for each type of Product.

        public static List<Product> drinkslist = new List<Product>();
        public static List<Product> snackslist = new List<Product>();
        public static List<Product> foodlist = new List<Product>();
        public static List<Product> chocolatelist = new List<Product>();

        //Pre-defined Currency Denomination.
        public static int[] moneyDenom = new int[] { 1, 5, 10, 20, 50, 100, 500, 1000 };

        public enum ProductTypes
        {
            Drinks,
            Snacks,
            Food,
            Chocolate
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Click any key to display products");
            Console.ReadKey();

            InitializeProducts();
            Console.WriteLine("-----------------------");
            try
            {
                int totalInputMoney = InputMoney();
            int totalRemainingMoney = totalInputMoney;
            Console.WriteLine($" You have put {totalInputMoney} Kr in the machine");
            Console.WriteLine("-----------------------");

            Console.Write("Enter the product number of the Drinks comma separated (example- 1011,1011,1012) : ");
            string selectDrink = Console.ReadLine();
            Console.Write("Enter the product number of the Snack comma separated (example- 1021,1022) : ");
            string selectSnack = Console.ReadLine();
            Console.Write("Enter the product number of the Food comma separated (example- 1031,1032) : ");
            string selectFood = Console.ReadLine();
            Console.Write("Enter the product number of the Chocolate comma separated (example- 1041,1042) : ");
            string selectChocolate = Console.ReadLine();

            int[] selectDrinkArray = Array.ConvertAll(selectDrink.Split(','), Int32.Parse);
            int[] selectSnackArray = Array.ConvertAll(selectSnack.Split(','), Int32.Parse);
            int[] selectFoodArray = Array.ConvertAll(selectFood.Split(','), Int32.Parse);
            int[] selectChocolateArray = Array.ConvertAll(selectChocolate.Split(','), Int32.Parse);

            Console.WriteLine("-----------------------");

            if (selectDrinkArray.Length > 0)            
            {
                for (int i = 0; i < selectDrinkArray.Length; i++)
                {
                    totalRemainingMoney=BuyProduct(selectDrinkArray[i], ProductTypes.Drinks, totalRemainingMoney, drinkslist);

                }
            }

            Console.WriteLine("-----------------------");
            if (selectSnackArray.Length > 0)
            {
                for (int i = 0; i < selectSnackArray.Length; i++)
                {
                    totalRemainingMoney = BuyProduct(selectSnackArray[i], ProductTypes.Snacks, totalRemainingMoney, snackslist);

                }
            }

            Console.WriteLine("-----------------------");
            if (selectFoodArray.Length > 0)
            {
                for (int i = 0; i < selectFoodArray.Length; i++)
                {
                    totalRemainingMoney = BuyProduct(selectFoodArray[i], ProductTypes.Food, totalRemainingMoney, foodlist);

                }
            }

            Console.WriteLine("-----------------------");
            if (selectChocolateArray.Length > 0)
            {
                for (int i = 0; i < selectChocolateArray.Length; i++)
                {
                    totalRemainingMoney = BuyProduct(selectChocolateArray[i], ProductTypes.Chocolate, totalRemainingMoney, chocolatelist);

                }
            }

            Console.WriteLine("-----------------------");
            if (totalRemainingMoney > 0)
                Console.WriteLine("Your remaining money is :" + totalRemainingMoney + " Kr");

            ReturnMoney(totalRemainingMoney);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Invalid input provided, please try running again", ex.Message);
            }

            Console.ReadLine();
        }

        //User enters money in to the Vending Machine as comma seperated money denominations.
        //Returns sum of money entered by the user.
        public static int InputMoney()
        {
            int sum = 0;

            Console.WriteLine("Money should be input in fixed denominations: 1kr, 5kr, 10kr, 20kr, 50kr, 100kr, 500kr and 1000kr.");
            Console.Write("Enter the money in to the machine comma separated (example- 1,5,5,10) :" );            
            string money = Console.ReadLine();            
            
            string[] moneyArray = money.Split(',');
            
            for(int i = 0; i < moneyArray.Length; i++)
            {
                bool isflag = false;

                for (int j = 0; j < moneyDenom.Length; j++)
                {
                    if(moneyDenom[j] == Convert.ToInt32(moneyArray[i]))
                    {
                        sum = sum + moneyDenom[j];
                        isflag = true;
                        break;
                    }                                        
                }

                if (isflag == false)
                {
                    Console.WriteLine("Invalid input, try again");
                    Console.WriteLine($"Please collect your money back {money} and try again!");
                    Environment.Exit(0);
                }
                    
            }
            
            return sum;
        }

        
        //Returns remaining change to the User as predefined denominations
        public static void ReturnMoney(int totalRemainingMoney)
        {            
            List<int> remianingDenom = new List<int>();
            while (totalRemainingMoney>0)
            {
                for (int i = 0, j = 0; i < moneyDenom.Length; i++)
                {
                    if (totalRemainingMoney == moneyDenom[i])
                    {                     
                        remianingDenom.Add(moneyDenom[i]);
                        j++;
                        totalRemainingMoney = totalRemainingMoney - moneyDenom[i];
                        break;
                    }
                    else if (totalRemainingMoney < moneyDenom[i])
                    {                        
                        remianingDenom.Add(moneyDenom[i - 1]);
                        totalRemainingMoney = totalRemainingMoney - moneyDenom[i - 1];
                        j++;
                        break;
                    }
                }
            }

            string returnChange = string.Join<int>(",", remianingDenom);
            if (remianingDenom.Count>0)
                Console.WriteLine($"Please collect the change {returnChange}");
            else
                Console.WriteLine("You have no money left");

        }

        //Adding Prdoucts to the inventory and Displaying them. 
        public static void InitializeProducts()
        {

            Console.WriteLine("\n Drinks In the machine");
            Console.WriteLine("-----------------------");
            Drinks coke = new Drinks("Coco Cola", 1011, 10, "Refreshing Drink! Enjoy it cold");
            coke.Examine();
            drinkslist.Add(coke);            

            Drinks fanta = new Drinks("Fanta Lime", 1012, 10, "Refreshing Drink! Enjoy it cold");
            fanta.Examine();
            drinkslist.Add(fanta);            

            Drinks water = new Drinks("Vitamin Water", 1013, 24,"Energy Drink to increase your vitamins");
            water.Examine();
            drinkslist.Add(water);
            Console.WriteLine("*******************************");

            Console.WriteLine("\n Snacks In the machine");
            Console.WriteLine("-----------------------");
            Snacks pringles = new Snacks("Pringles", 1021, 9,"Classic Salt Flavoured Potato Chips");
            pringles.Examine();
            snackslist.Add(pringles);
            
            Snacks lays = new Snacks("Lays Classic", 1022, 20,"Cream and Onion Flavoured Potato Chips");
            lays.Examine();
            snackslist.Add(lays);
            
            Snacks cheez = new Snacks("Cheez Doodles", 1023, 13,"Cheese Flavoured Balls");
            cheez.Examine();
            snackslist.Add(cheez);

            Console.WriteLine("*******************************");
            Console.WriteLine("\n Food items In the machine");
            Console.WriteLine("-----------------------");
            Food mealbar = new Food("Nature diet Protien Meal bar", 1031, 26,"Diet protien bar with Crunchy chocolate ");
            mealbar.Examine();
            foodlist.Add(mealbar);
            
            Food tramezzino = new Food("Tramezzino - Tuna Sandwich", 1032, 40,"Tuna sandwich with green Olives, Can be used in Microwave");
            tramezzino.Examine();
            foodlist.Add(tramezzino);
            
            Food panini = new Food("Panini -Chicken Sandwich", 1033, 55, "Roasted Chicken sandwich with tomotoes, Can be used in Microwave");
            panini.Examine();
            foodlist.Add(panini);

            Console.WriteLine("*******************************");
            Console.WriteLine("\n Chocolates In the machine");
            Console.WriteLine("-----------------------");

            Chocolate snickers = new Chocolate("Snickers", 1041, 13,"Nutty Chocolate bar!");
            snickers.Examine();
            chocolatelist.Add(snickers);
            
            Chocolate bounty = new Chocolate("Bounty", 1042, 13,"Coconut  filled Chocolate bar!");
            bounty.Examine();
            chocolatelist.Add(bounty);
            
            Chocolate kex = new Chocolate("Kex Choco", 1043, 12,"Crunchy Wafer Chocolate!");
            kex.Examine();
            chocolatelist.Add(kex);

        }

        //Checks user input for the selected product in inventory.
        public static int BuyProduct(int selectedProduct, ProductTypes type, int totalRemainingMoney, List<Product> productList)
        {            
            var product = productList.Find(x => x.ProductNumber == selectedProduct);

            if (!(product is null))
            {
                Console.WriteLine($"You selected {type} { product.Name}");
                totalRemainingMoney = product.Purchase(totalRemainingMoney);
            }
            else
                Console.WriteLine($"Product {selectedProduct} does not exist");

            return totalRemainingMoney;
        }
    }
}
