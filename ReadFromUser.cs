using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using EmployeeManagementSystem.Operations;

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
                Console.Write($"   Invalid input (integers only) {message} : ");
            }
            return value;
        }
        public static int ReadInteger(string message, int min, int max)
        {
            int value;
           
            while (true)
            {
                Console.Write($"{message} (Between {min} and {max}): ");
                string input = Console.ReadLine().Trim();
                if (CompanyOperations.CheckForCancel(input)) return -1;
                if (int.TryParse(input, out value))
                {
                    if (value >= min && value <= max)
                        return value;
                    else
                        Console.WriteLine($"   Error: Value must be between {min} and {max}.");
                }
                else
                {
                    Console.WriteLine("   Error: Invalid number! Please enter a valid integer.");
                }
            }
        }

        public static decimal ReadRealNumber(string message, decimal min, decimal max)
        {
            decimal value;
            while (true)
            {
                Console.Write($"{message} (Between {min} and {max}): ");
                string input = Console.ReadLine().Trim();
                if (CompanyOperations.CheckForCancel(input)) return -1;
                if (decimal.TryParse(input, out value))
                {
                    if (value >= min && value <= max)
                        return value;
                    else
                        Console.WriteLine($"   Error: Value must be between {min} and {max}.");
                }
                else
                {
                    Console.WriteLine("   Error: Invalid number! Please enter a valid decimal number.");
                }
            }
        }

        public static string ReadString(string message)
        {
            while (true)
            {
                Console.Write(message);
                string value = Console.ReadLine().Trim();

                if (string.IsNullOrWhiteSpace(value))
                {
                    Console.WriteLine("   Error: Input cannot be empty. Please enter a valid name.");
                }
                else if (!value.All(c => char.IsLetter(c) || char.IsWhiteSpace(c)))
                {
                    Console.WriteLine("   Error: Name must contain only letters and spaces.");
                }
                else if (value.All(char.IsDigit))
                {
                    Console.WriteLine("   Error: Name cannot be a number.");
                }
                else
                {
                    return value;
                }
            }
        }



    }
}
