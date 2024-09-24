using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetStore.Utils
{
    public static class Utilities
    {

        private const string BaseInvalidMessage = "Invalid input. ";

        public static string InvalidDecimalMessage => $"{BaseInvalidMessage}Please enter a valid decimal number.";
        public static string InvalidIntMessage => $"{BaseInvalidMessage}Please enter a valid integer.";
        public static string InvalidBoolMessage => $"{BaseInvalidMessage}Please enter 'true' or 'false'.";
        public static string InvalidStringMessage => $"{BaseInvalidMessage}Please enter a non-empty string.";

        public static decimal GetValidDecimal(string prompt)
        {
            decimal value;
            while (true)
            {
                Console.WriteLine(prompt);
                string input = Console.ReadLine()!;
                if (decimal.TryParse(input, out value))
                    return value;
                Console.WriteLine(InvalidDecimalMessage);
            }
        }

        public static int GetValidInt(string prompt)
        {
            int value;
            while (true)
            {
                Console.WriteLine(prompt);
                string input = Console.ReadLine()!;
                if (int.TryParse(input, out value))
                    return value;
                Console.WriteLine(InvalidIntMessage);
            }
        }

        public static bool GetValidBool(string prompt)
        {
            bool value;
            while (true)
            {
                Console.WriteLine(prompt);
                string input = Console.ReadLine()!;
                if (bool.TryParse(input, out value))
                    return value;
                Console.WriteLine(InvalidBoolMessage);
            }
        }

        public static string GetValidString(string prompt)
        {
            string value;
            while (true)
            {
                Console.WriteLine(prompt);
                value = Console.ReadLine()!;
                if (!string.IsNullOrWhiteSpace(value))
                    return value;
                Console.WriteLine(InvalidStringMessage);
            }
        }
    }
}
