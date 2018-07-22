using System;

namespace Capstone1
{
    class Program
    {
        static void Main()
        {
            do
            {
                Console.WriteLine("Please enter a word you would like to translate to pig latin");
                string userInput = Console.ReadLine();

                if(ValidateString(userInput))
                {
                    Console.WriteLine(ToPigLatin(userInput));
                }
                else
                {
                    Console.WriteLine(userInput);
                }
            }
            //call continue method
            while (Continue() == 1);
        }

        static bool ValidateString(string userInput)
        {
            int num = 0;
            for (int i = 1; i < userInput.Length; i++)
            {
                if (int.TryParse(userInput[i].ToString(), out num))
                {
                    //Console.WriteLine("Please enter a valid string");
                    return false;
                }
            }
            return true;
        }

        static string ToPigLatin(string usStr)
        {
            usStr = usStr.ToLower();

            if ((usStr.IndexOfAny("aeiou".ToCharArray()) == 0))
            {
                usStr = usStr + "way";
            }
            else
            {
                char hold;
                int vowelIndex = usStr.IndexOfAny("aeiou".ToCharArray());

                for (int i = 0; i < vowelIndex; i++)
                {
                    hold = usStr[0];
                    usStr = usStr.Remove(0, 1);
                    usStr = usStr + hold;
                }

                usStr = usStr + "ay";
            }
            return usStr;
        }

        static int Continue()
        {
            string response;
            int situ = 3;
            while (situ == 3)
            {
                Console.WriteLine("Continue? (y/n): ");
                response = Console.ReadLine().ToLower();

                if (response == "y" || response == "yes")
                {
                    //if yes, restart at main
                    situ = 1;
                }
                else if (response == "n" || response == "no")
                {
                    //if no, exit
                    situ = 0;
                }
                else if (response != "n" || response != "no" || response != "y" || response != "yes")
                {
                    situ = 3;
                }

                if (situ == 3)
                {
                    Console.WriteLine("Please enter valid response.");
                }
            }
            return situ;
        }
    }
}