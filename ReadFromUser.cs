using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagementSystem
{
    internal class ReadFromUser
    {
        public static int ReadInteger(string message)
        {
            int value;

            Console.Write(message);
            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out value))
                {
                    break;
                }
                Console.Write($"Invalid input (integers only) {message} : ");
            }
            return value;
        }
        public static int ReadInteger(string message, int min, int max)
        {
            int value;

            Console.Write(message);
            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out value))
                {
                    if (value >= min && value <= max)
                        break;
                }
                Console.Write($"{message} : between {min} and {max} :  ");
            }
            return value;
        }


        public static decimal ReadRealNumber(string message, decimal min = decimal.MinValue, decimal max = decimal.MaxValue)
        {
            decimal value;
            Console.Write(message);
            while (true)
            {
                if (decimal.TryParse(Console.ReadLine(), out value))
                {
                    if (value >= min && value <= max)
                    {
                        break;
                    }
                }
                Console.Write($"{message} : between {min} and {max} : ");
            }
            return value;
        }

        public static string ReadString(string message)
        {
            Console.Write(message);
            string value;
            while (true)
            {
                value = Console.ReadLine();
                if (value.Trim() != "")
                {
                    break;
                }
            }
            return value;
        }
    }
}
