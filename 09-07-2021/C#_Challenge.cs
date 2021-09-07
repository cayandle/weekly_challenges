using System;

namespace Onboarding_Challenges
{
    class Challenge
    {
        static void Main(string[] args)
        {
            Console.WriteLine(GiveMeSomething(Console.ReadLine()));
        }

        private static string GiveMeSomething(string phrase){
            return "something " + phrase;
        }
    }
}
