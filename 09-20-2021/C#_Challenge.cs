using System;
using System.Collections.Generic;

namespace Challenges
{
    class Store
    {
        static void Main(string[] args)
        {
            List<string> stock = new List<string>{"Apple", "Banana", "Blueberries", "Mango", "Pineapple", "Raspberries", "Strawberries"};
            bool loop = true;
            List<string> ingredients = new List<string>();
            int entry = 0;
            while (loop)
            {
                Console.Clear();
                Console.WriteLine("Enter 0 To Submit Smoothie");
                foreach (string item in stock)
                {
                    Console.WriteLine("Enter "+(stock.IndexOf(item)+1)+" to add "+item);
                }
                Console.WriteLine("Current Ingredients: " + String.Join(", ", ingredients));
                entry = Int32.Parse(Console.ReadLine());

                if(entry == 0)
                {
                    Console.Clear();
                    Smoothie newSmoothie = new Smoothie(ingredients);

                    Console.WriteLine("Cost to Make: $" + newSmoothie.GetCost().ToString("0.00"));
                    Console.WriteLine("Selling Price: $" + newSmoothie.GetPrice().ToString("0.00"));
                    Console.WriteLine("Name of the Smoothie: " + newSmoothie.GetName());
                    loop = false;
                }
                else if(entry > 0 && entry <= stock.Count)
                {
                    ingredients.Add(stock[entry-1]);
                    stock.Remove(stock[entry-1]);
                }
                else
                {
                    Console.WriteLine("Please Enter a Valid Number Option");
                }
            }
        }
    }

    class Smoothie
    {
        public List<string> ingredients = new List<string>();

        public Smoothie(List<string> p_ingredients)
        {
            ingredients = p_ingredients;
        }

        public decimal GetCost()
        {
            decimal total = 0m;
            foreach (string item in ingredients)
            {
                total += Convert(item.ToLower());
            }
            return Decimal.Round(total, 2);
        }

        public decimal GetPrice()
        {
            decimal total = 0m;
            total = GetCost();
            total = decimal.Multiply(2.5m, total);
            return Decimal.Round(total, 2);
        }

        public string GetName()
        {
            string result = "";
            ingredients.Sort();
            foreach (string item in ingredients)
            {
                if(item.Substring(item.Length - 3).ToLower()=="ies")
                {
                    result += item.Substring(0,1).ToUpper()+item.Substring(1,item.Length-4).ToLower()+"y ";
                }
                else
                {
                result += item.Substring(0,1).ToUpper()+item.Substring(1).ToLower()+" ";
                }
            }
            if(ingredients.Count>1)
            {
                result += "Fusion";
            }
            else
            {
                result += "Smoothie";
            }
            return result;
        }

        private decimal Convert(string ingred)
        {
            switch (ingred)
            {
                case "strawberries":
                return 1.5m;
                case "banana":
                return .5m;
                case "mango":
                return 2.5m;
                case "blueberries":
                return 1m;
                case "raspberries":
                return 1m;
                case "apple":
                return 1.75m;
                case "pineapple":
                return 3.5m;
                default:
                return 0m;
            }
        }
    }
}
