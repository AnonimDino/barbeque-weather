using System;

namespace BarbequeWeather.Utilities.Logger
{
    public class ConsoleLogger : ILogger
    {
        public void Log(string message, Severity severity)
        {
            SetColorBasedOnSeverity(severity);

            Console.WriteLine(message);

            Console.ResetColor();
        }

        private void SetColorBasedOnSeverity(Severity severity)
        {
            switch (severity)
            {
                case Severity.Warning:
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    break;
                case Severity.Error:
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;
                default:
                    Console.ForegroundColor = ConsoleColor.Green;
                    break;
            }
        }
    }
}
