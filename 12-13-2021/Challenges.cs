using System;
using System.Collections.Generic;
using System.Threading;

namespace _12_13_2021
{
    class Challenges
{
        static void Main(string[] args)
        {
            bool looping = true;
            while(looping){
                Console.Clear();
                Console.WriteLine("Enter 1 to go to Palindrome");
                Console.WriteLine("Enter 2 to go to Step Climbing");
                Console.WriteLine("Enter 3 to Exit");
                switch (Console.ReadLine()){
                    case "1":
                        Console.Clear();
                        Console.WriteLine("Please enter word to check if it is or is one character away from being a case sensitive palindrome:");
                        Console.WriteLine(almostPalindrome(Console.ReadLine()));
                        Console.WriteLine("Press Enter key to continue");
                        Console.ReadLine();
                        break;
                    case "2":
                        Console.Clear();
                        Console.WriteLine("Please enter number of steps to find out how many ways there are to climb them in 1 or 2 step increments:");
                        Console.WriteLine(waysToClimb(0,Int32.Parse(Console.ReadLine()))+" ways to climb the stairs");
                        Console.WriteLine("Press Enter to continue");
                        Console.ReadLine();
                        break;
                    case "3":
                        Console.Clear();
                        looping = false;
                        break;
                    default:
                        Console.WriteLine("Please enter valid option");
                        Thread.Sleep(2000);
                        break;
                }
            }
        }

        static string almostPalindrome(string phrase)
        {
            bool test = true;
            string result = "true";
            for(int i = 0; i < phrase.Length/2; i++){
                if(phrase[i]!=phrase[phrase.Length-1-i]){
                    if(test){
                        test=false;
                    }else{
                        result = "false";
                    }
                }
            }
            return result;
        }

        static int waysToClimb(int current, int goal)
        {
            int count = 0;
            if(current < goal){
                count += waysToClimb(current + 1, goal);
                count += waysToClimb(current + 2, goal);
            }else if(current == goal){
                count = 1;
            }else{
                return count;
            }
            return count;
        }
    }
}
