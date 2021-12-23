using System;

namespace _12_20_2021
{
    class Program
    {
        static void Main(string[] args)
        {
            bool loop = true;
            while(loop){
                Console.WriteLine("Please enter 1 to go to DeadEnd");
                Console.WriteLine("Please enter 2 to go to MagicSquare");
                Console.WriteLine("Please enter 3 to Exit");
                string pick = Console.ReadLine();
                switch (pick){
                    case "1":
                        Console.WriteLine("Please enter the number to find the dead end count and result");
                        int param = Int32.Parse(Console.ReadLine());
                        int[] result1 = DeadEnd(param);
                        Console.WriteLine("["+result1[0]+", "+result1[1]+"]");
                        Console.WriteLine("Press Enter to continue");
                        Console.ReadLine();
                        break;
                    case "2":
                        Console.WriteLine("Please enter size of square");
                        int size = Int32.Parse(Console.ReadLine());
                        int[][] param2 = new int[size][];
                        for(int i = 0; i < size; i++){
                            Console.WriteLine("Please enter "+size+" numbers for row "+ (i+1)+" separated by spaces");
                            string input = Console.ReadLine();
                            string[] splitInput = input.Split(' ');
                            param2[i] = new int[size];
                            for(int j = 0; j < splitInput.Length; j++){
                                param2[i][j] = Int32.Parse(splitInput[j]);
                            }
                        }
                        Console.WriteLine(IsMagicSquare(param2));
                        Console.WriteLine("Press Enter to continue");
                        Console.ReadLine();
                        break;
                    case "3":
                        loop=false;
                        break;
                    default:
                        Console.Clear();
                        break;
                }
            }
        }

        static int[] DeadEnd(int param){
            int count = 1;
            int firstPrevious = param;
            int secondPrevious = param;
            bool test = true;
            while(test){
                secondPrevious = firstPrevious;
                firstPrevious = param;
                int digits = param.ToString().Length;
                int digitSum = 0;
                for(int i = 0; i < digits; i++){
                    digitSum+=Int32.Parse(param.ToString()[i].ToString());
                }
                if(param%digitSum==0){
                    param/=digitSum;
                }else{
                    param*=digitSum;
                }
                if(secondPrevious==param||param==firstPrevious){
                    param=firstPrevious;
                    test=false;
                }else{
                    count++;
                }
            }
            int[] result = {count,param};
            return result;
        }

        static bool IsMagicSquare(int[][] param){
            bool result = true;
            int size = param.Length;
            int tentative = 0;
            int horTest = 0;
            int vertTest = 0;
            int topLeftDiagTest = 0;
            int topRightDiagTest = 0;
            foreach(int i in param[0]){
                tentative += i;
            }
            for(int i = 0; i < size; i++){
                horTest = 0;
                vertTest = 0;
                topLeftDiagTest += param[i][i];
                topRightDiagTest += param[i][size-i-1];
                for(int j = 0; j < size; j++){
                    horTest += param[i][j];
                    vertTest += param[j][i];
                }
                if(tentative!=horTest||tentative!=vertTest){
                    result=false;
                    break;
                }
            }
            if(topLeftDiagTest!=tentative||topRightDiagTest!=tentative){
                result=false;
            }     
            return result;
        }
    }
}
