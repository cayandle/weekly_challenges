using System;
using System.Collections.Generic;

namespace C__Challenge
{
    class Program
    {
        static void Main(string[] args)
        {
            //Number of items
            int N = 0;

            //Number of items of each color
            List<int> eachColor = new List<int>();

            //For validation of the amount of items
            bool pass = false;
            while(!pass){
                Console.WriteLine("Please enter the number of items between 1 and 20:");

                //Try catch block to catch non-integer values
                try
                {
                     N = Int32.Parse(Console.ReadLine());
                }
                catch (System.FormatException){}

                //Validation of number of items due to long data type limit
                if(N > 0 && N < 21){
                    pass=true;
                } else{
                    Console.WriteLine("Invalid amount of items");
                }
            }
            
            //Remaining items to distribute among the colors
            int remaining = N;

            //Current number of the color being input by the user
            int color = 1;

            //Temporary int used for checking if the amount of a color is possible
            int temp = 0;

            //Loop to make sure all items are assigned a color
            while(remaining!=0){
                Console.WriteLine("Items remaining to be assigned: "+remaining);
                Console.WriteLine("Enter the amount of color k"+color);

                //Try catch block to catch non-integer values
                try
                {
                    temp = Int32.Parse(Console.ReadLine());
                }
                catch (System.FormatException){}

                //Validation to make sure that the amount of items attempting to be assigned a color does not exceed the total amount of items remaining
                if(remaining>=temp&&temp!=0){
                    eachColor.Add(temp);
                    remaining-=temp;
                    color++;
                } else{
                    Console.WriteLine("Please enter an amount equal or less than the remaining items");
                }
                temp=0;
            }

            //End goal to show the number of arrangements
            Console.WriteLine(BestArrange(N,eachColor)+" ways to arrange the items");
        }

        static long BestArrange(int N, List<int> eachColor){
            
            //Stores the initial factorial and gets reduced to the correct answer
            long result = 0;
            //Current sum of the number of items
            int stepper = 0;

            //Setting the inital result to the factorial of the number of items
            result = Factorial(N);
            foreach (int item in eachColor)
            {
                //increase the stepper by each item, i.e. {1,3,5} would give stepper values {1,4,9}
                stepper += item;

                //Divide the result by this stepper amount
                result /= stepper;

                //Divide the result by the factorial of the amount of the color-1
                result /= Factorial(item-1);
            }

            //Return the final result
            return result;
        }

        static long Factorial(int num){
            long result = 1;

            //Loop to give the factorial of a number, i.e. 5! would be 5*4*3*2*1
            for (int i = num; i >= 0; i--)
            {
                if(i==0){
                    result*=1;
                }
                else{
                    result*=i;
                }
            }

            //Return the factorial
            return result;
        }
    }
}
