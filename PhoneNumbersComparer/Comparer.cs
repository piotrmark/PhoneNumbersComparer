using System;
using System.Linq;

namespace PhoneNumbersComparer
{
    public class Comparer
    {
        public static bool PhoneNumbersMatchOptimal(string number1, string number2)
        {
            if (string.IsNullOrWhiteSpace(number1) && string.IsNullOrWhiteSpace(number2))
            {
                return true;
            }

            if (string.IsNullOrWhiteSpace(number1) || string.IsNullOrWhiteSpace(number2))
            {
                return false;
            }

            var index1 = 0;
            var index2 = 0;

            while (index1 < number1.Length && index2 < number2.Length)
            {
                while (index1 < number1.Length && !IsDigit(number1[index1]))
                {
                    index1++;
                }

                while (index2 < number2.Length && !IsDigit(number2[index2]))
                {
                    index2++;
                }

                if (index1 == number1.Length || index2 == number2.Length)
                {
                    break;
                }

                if (number1[index1] != number2[index2])
                {
                    return false;
                }

                index1++;
                index2++;
            }

            // Reached the end of one string. Make sure there are no digits left in the other one.
            while (index1 < number1.Length)
            {
                if (IsDigit(number1[index1]))
                {
                    return false;
                }

                index1++;
            }

            while (index2 < number2.Length)
            {
                if (IsDigit(number2[index2]))
                {
                    return false;
                }

                index2++;
            }

            return true;
        }

        public static bool PhoneNumbersMatchSimple(string number1, string number2)
        {
            if (string.IsNullOrWhiteSpace(number1) && string.IsNullOrWhiteSpace(number2))
            {
                return true;
            }

            if (string.IsNullOrWhiteSpace(number1) || string.IsNullOrWhiteSpace(number2))
            {
                return false;
            }

            return number1.Where(IsDigit).SequenceEqual(number2.Where(IsDigit));
        }

        private static bool IsDigit(char c)
        {
            return c >= '0' && c <= '9';
        }
    }
}
