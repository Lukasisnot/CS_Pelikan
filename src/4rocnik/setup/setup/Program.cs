using System;

namespace setup
{
    internal class Program
    {
        public static int GuessingNumber;
        public static int GuessingNumberSceling = 100;
        public static int GuessingNumberFloor = 0;
        public static bool NumberGuessed = false;
        
        public static void Main(string[] args)
        {
            // for (int i = 1; i < 100; i++)
            // {
            //     Console.WriteLine(FizzBuzz(i));
            // }
            
            GenerateNumber();
            while (!NumberGuessed)
            {
                Console.Write("Guess a number: ");
                int guess = Convert.ToInt32(Console.ReadLine());
                NumberGuessed = GuessNumber(guess);
            }
        }
    
        public static string FizzBuzz(int  number)
        {
            if (number % 3 == 0 && number % 5 == 0)
            {
                return "FizzBuzz";
            }
            else if (number % 3 == 0)
            {
                return "Fizz";
            }
            else if (number % 5 == 0)
            {
                return "Buzz";
            }
            else
            {
                return number.ToString();
            }
        }

        public static bool GuessNumber(int guess)
        {
            if (guess > GuessingNumber)
            {
                Console.WriteLine("lower");
                return false;
            }
            else if (guess < GuessingNumber)
            {
                Console.WriteLine("higher");
                return false;
            }
            else
            {
                Console.WriteLine("genius");
                return true;
            }
        }

        public static void GenerateNumber()
        {
            Random random = new Random();
            GuessingNumber = random.Next(GuessingNumberFloor, GuessingNumberSceling + 1);
        }
    }
    
}