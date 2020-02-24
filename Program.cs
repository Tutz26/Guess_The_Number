using System;

namespace Guess_The_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the guess the number game!");


        }
        
        /// <summary>
        /// Create a random number between 0 and the threshold, it also makes the number positive if a negative number was used.
        /// </summary>
        /// <param name="maxThrehsholdNumber"></param>
        /// <returns></returns>
        static int RandomizeInRange(int maxThrehsholdNumber)
        {
            Random rNumber = new Random();

            if(maxThrehsholdNumber < 0)
            {
                maxThrehsholdNumber = maxThrehsholdNumber * (-1);
            }
            //Creates random number between the range
            int randomNumberGenerator = rNumber.Next(0, maxThrehsholdNumber); 

            return randomNumberGenerator;
        }


        /// <summary>
        /// It converts the user input into integer or lets you know if it can't be converted.
        /// </summary>
        /// <returns></returns>
        static int UserInputRequest()
        {
        
            int number;
            //Input request for user
          String userInput = Console.ReadLine();
            //Clean spaces in the string
          userInput = userInput.Replace(" ", "");

            //Avoid error inputs with try parse.
            bool isInputParsable = Int32.TryParse(userInput, out number); 
        
            if(isInputParsable)
            {
              return Convert.ToInt32(userInput);
            }
            else
            {
              Console.WriteLine("Input was not correct, please use only numbers.");
              return 0;
            }

        }
    }
}
