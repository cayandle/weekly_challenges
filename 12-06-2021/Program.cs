using System;
using System.Collections.Generic;
using System.Threading;

namespace _12_06_2021
{
    class ChallengeHub
    {
        static void Main(string[] args)
        {
            
            bool running = true;
            while(running){
                Console.Clear();
                Console.WriteLine("Press 1 to go to Overtime Calculator");
                Console.WriteLine("Press 2 to go to Unique Fraction Sum Tool");
                Console.WriteLine("Press 3 to Exit");
                switch(Console.ReadLine()){
                    case "1":
                    Console.Clear();
                    Challenge1.GetValues();
                    break;
                    case "2":
                    Console.Clear();
                    Challenge2.UniqueFract();
                    break;
                    case "3":
                    Console.Clear();
                    running = false;
                    break;
                    default:
                    Console.WriteLine("Please enter a valid number");
                    Thread.Sleep(1000);
                    Console.Clear();
                    break;
                }
                
            }
            
        }
    }


    public static class Challenge1
    {
        public static void GetValues(){
            List<decimal> timeline = new List<decimal>();
            Console.WriteLine("Please enter starting time in decimal format with 24hour day notation:");
            timeline.Add(Decimal.Parse(Console.ReadLine()));
            Console.WriteLine("Please enter ending time in decimal format with 24hour day notation:");
            timeline.Add(Decimal.Parse(Console.ReadLine()));
            Console.WriteLine("Please enter hourly pay in decimal format:");
            timeline.Add(Decimal.Parse(Console.ReadLine()));
            Console.WriteLine("Please enter overtime pay multiplier in decimal format:");
            timeline.Add(Decimal.Parse(Console.ReadLine()));
            OverTime(timeline);
        }
        public static void OverTime(List<decimal> param){
            decimal total = param[1]-param[0];
            total *= param[2];
            if(param[0] >= 17){
                total *= param[3];
            }else if(param[1] > 17){
                total += ((param[1]-17)*(param[3]-1)*param[2]);
            }
            Console.WriteLine(total.ToString("C2") + " Earned");
            Console.WriteLine("Press Enter to Continue");
            Console.ReadLine();
        }
    }
    public static class Challenge2
    {
        public static void UniqueFract(){
            List<double> uniques = new List<double>();
            double total = 0;
            for(int i = 1; i <= 9; i++){
                for(int j = 1; j <= i; j++){
                    double test = (double)j/i;
                    if(test!=1){
                        if(!uniques.Contains(test)){
                            uniques.Add(test);
                            total+=test;
                            Console.WriteLine(j+"/"+i);
                        }
                    }
                }
            }
            Console.WriteLine("Sum of all irreducible regular fractions between 0 and 1 with single digit numerators and denominators is: " + total);
            Console.WriteLine("Press Enter to Continue");
            Console.ReadLine();
        }
    }
}
