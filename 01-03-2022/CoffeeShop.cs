using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace _01_03_2022
{

    class StartingPoint
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter the name of the Coffee Shop:");
            string name = Console.ReadLine();
            CoffeeShop shop = new CoffeeShop(name);
            bool loop = true;
            while(loop){
                Console.Clear();
                Console.WriteLine("Welcome to "+shop.name+"!");
                Console.WriteLine("Press 1 to order an item");
                Console.WriteLine("Press 2 to fulfill an order");
                Console.WriteLine("Press 3 to list all orders");
                Console.WriteLine("Press 4 to display the total amount due for all orders");
                Console.WriteLine("Press 5 to display the name of the cheapest item");
                Console.WriteLine("Press 6 to list the name of all drinks");
                Console.WriteLine("Press 7 to list the name of all food");
                Console.WriteLine("Press 8 to exit");
                switch(Console.ReadLine()){
                    case "1":
                        Console.WriteLine("Please enter the name of the item you would like to order");
                        string item = Console.ReadLine().ToLower();
                        Console.WriteLine(shop.addOrder(item));
                        break;
                    case "2":
                        Console.WriteLine(shop.fulfillOrder());
                        break;
                    case "3":
                        foreach(MenuItem i in shop.listOrders()){
                            Console.WriteLine(i.item);
                        }
                        break;
                    case "4":
                        Console.WriteLine(shop.dueAmount());
                        break;
                    case "5":
                        Console.WriteLine(shop.cheapestItem());
                        break;
                    case "6":
                        foreach(string i in shop.drinksOnly()){
                            Console.WriteLine(i);
                        }
                        break;
                    case "7":
                        foreach(string i in shop.foodOnly()){
                            Console.WriteLine(i);
                        }
                        break;
                    case "8":
                        loop = false;
                        break;
                    default:
                        Console.WriteLine("Please select a valid option");
                        break;
                }
                Console.WriteLine("Press enter to continue");
                Console.ReadLine();
            }
        }
    }
    class CoffeeShop
    {
        public CoffeeShop(string name)
        {
            menu = new List<MenuItem>();
            orders = new List<MenuItem>();
            this.name = name;
            string json = File.ReadAllText("./Menus/MenuBase.json");
            menu = JsonSerializer.Deserialize<List<MenuItem>>(json);
        }
        public string name { get; set;}
        public List<MenuItem> menu { get; set;}
        public List<MenuItem> orders { get; set;}
        public string addOrder(string item){
            foreach(MenuItem i in menu){
                if(i.item==item){
                    MenuItem order = i;
                    orders.Add(order);
                    return item+" ordered!";
                }
            }
            return "This item is currently unavailable!";
        }
        public string fulfillOrder(){
            if(orders.Count!=0){
                MenuItem temp = orders[0];
                orders.RemoveAt(0);
                return "The "+temp.item+" is ready!";
            }else{
                return "All orders have been fulfilled!";
            }
        }
        public List<MenuItem> listOrders(){
                return orders;
        }
        public decimal dueAmount(){
            decimal total = 0;
            foreach(MenuItem i in orders){
                total+=i.price;
            }
            return total;
        }
        public string cheapestItem(){
            decimal minPrice = menu[0].price;
            string minItem = "";
            foreach(MenuItem i in menu){
                if(i.price < minPrice){
                    minPrice = i.price;
                    minItem = i.item;
                }
            }
            return minItem;
        }
        public List<string> drinksOnly(){
            List<string> drinks = new List<string>();
            foreach(MenuItem i in menu){
                if(i.type=="drink"){
                    drinks.Add(i.item);
                }
            }
            return drinks;
        }
        public List<string> foodOnly(){
            List<string> food = new List<string>();
            foreach(MenuItem i in menu){
                if(i.type=="food"){
                    food.Add(i.item);
                }
            }
            return food;
        }
        
    }
    class MenuItem
    {
        public string item { get; set;}
        public string type { get; set;}
        public decimal price { get; set;}
    }
}
