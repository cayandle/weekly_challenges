using System;
using System.Collections.Generic;

namespace Onboarding_Challenges
{
    class Challenge
    {
        static void Main(string[] args)
        {
            string test = Console.ReadLine();

            //Checking constraints of positive integer
            try
            {
                if(Int32.Parse(test)>0){
                    Console.WriteLine(ExpressFactors(Int32.Parse(test)));
                }else {
                    Rejected();
                }
            }
            catch (System.FormatException)
            {
                Rejected();
            }
            catch (System.OverflowException)
            {
                Console.WriteLine("That number is too large, please be less than or equal to 2,147,483,647");
                Rejected();
            }
        }

        //Method to catch bad inputs from the user
        static void Rejected(){
            Console.WriteLine("Please enter a positive integer");
            Main(null);
        }

        static string ExpressFactors(int p_test){
            string result = "";
            int original = p_test;
            bool loop = true;
            bool notFirst = false;
            int count = 0;
                for(int i = 2; i<=original/2; i++){

                    //If the remaining number is divisible by the next iteration
                    if(p_test%i==0){

                        //If not the first factor in list this will add the separating 'x' between factors
                        if(notFirst){
                            result += " x ";
                        }
                        notFirst = true;

                        //Will check for squares i.e. 8 is divisible thrice by 2
                        while(loop){
                            count++;
                            p_test/=i;
                            if(p_test%i!=0){
                                loop=false;
                            }
                        }

                        //Adds factor to string, if statement to determine if a caret is used
                        if(count==1){
                            result = result + i;
                        }else{
                            result = result + i+"^"+count;
                        }

                        //reset the count and loop variables for the next iteration
                        count=0;
                        loop=true;
                    }
                }

                //If the loop finds no factors then this number is prime and sets the result as such
                if(result == ""){
                    result = p_test.ToString();
                }

            //Return the result of the loop
            return result;
        }
    }
}
