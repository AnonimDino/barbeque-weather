using System;

namespace BarbequeWeather.View
{
    public class ConsoleView : IView
    {
        private const string RESULT_IF_BBQ = "!!!BARBEQUE TIME!!!";
        private const string RESULT_IF_NO_BBQ = "No barbeque party.. :(";
        private const string RUN_AGAIN_PROMPT = "Would you like to run again? (Y/N)";
        private const string WRONG_INPUT_PROMPT = "Please type in either Y or N!";
        private const string YES = "Y";
        private const string NO = "N";

        public int GetLatitude() => GetIntConsoleInput("Please type in LATITUDE of your position and hit Enter:");

        public int GetLongitude() => GetIntConsoleInput("Please type in LONGITUDE of your position and hit Enter:");

        public void DisplayResult(string locationDisclaimer, bool isBarbequeTime)
        {
            Console.WriteLine(locationDisclaimer);

            if (isBarbequeTime)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.BackgroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine(RESULT_IF_BBQ);
            } else
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.BackgroundColor = ConsoleColor.DarkRed;
                Console.WriteLine(RESULT_IF_NO_BBQ);
            }
            Console.ResetColor();
        }

        public bool RunAgain()
        {
            Console.WriteLine(RUN_AGAIN_PROMPT);
            var input = Console.ReadLine();
            var confirmed = input == YES || input == NO;
            while(!confirmed)
            {
                Console.WriteLine(WRONG_INPUT_PROMPT);
                input = Console.ReadLine();
                confirmed = input == YES || input == NO;
            }
            return input == YES;
        }

        private int GetIntConsoleInput(string message)
        {
            Console.WriteLine(message);
            var consoleInput = Console.ReadLine();
            int result;
            while (!int.TryParse(consoleInput, out result))
            {
                Console.WriteLine(message);
                consoleInput = Console.ReadLine();
            }
            return result;
        }

        public void DisplayError(string errorMessage)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.DarkRed;
            Console.WriteLine(errorMessage);
            Console.ResetColor();
        }
    }
}