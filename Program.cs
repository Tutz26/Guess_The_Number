using System;

namespace Guess_The_Number
{
    class Program
    {

            //Variable creation
            static int userNumber; 
            static int randomNumber;
            static  int playerAttempts;
            static bool gameOver;

        /// <summary>
        /// Guess the number core, iteration and variable asignation happens here.
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            gameOver = false;
            playerAttempts = 0;

            Console.WriteLine("Welcome to the guess the number game!");
            Console.WriteLine("Please type a positive number, this number will be the maximum between a range of itself and 0 to select an aleatory number.");


            userNumber = UserInputRequest();

            //Avoid user to use 0 or an invalid number
            if(userNumber == 0)
            {       
                while(userNumber == 0)
                {
                userNumber = UserInputRequest();
                }
            }
            //Generate random number
            else
            {
              randomNumber = RandomizeInRange(userNumber);
            }

            //Iterate until player wins!
            while(!gameOver)
            {
                Console.WriteLine("Please type a number to guess between 1 and {0}!", userNumber);
                int attemptedNumber = UserInputRequest();

                if(attemptedNumber != randomNumber)
                {
                    playerAttempts = playerAttempts + 1;
                    Console.WriteLine("You have tried {0} times.", playerAttempts);
                
                    if(attemptedNumber > randomNumber)
                    {
                        Console.WriteLine("Try less!");
                    }
                    else
                    {
                        Console.WriteLine("Try more!");
                    }
                }
                else
                {
                    Console.WriteLine("Congratulations! you won!.");
                    Console.WriteLine("It only cost you {0} attempts.", playerAttempts);
                    Console.WriteLine("Press any key to exit!");
                    Console.ReadKey();
                    gameOver = true;
                }

            }

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
