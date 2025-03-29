using EmployeeManagementSystem.Operations;
using System;

namespace EmployeeManagementSystem.Menus
{
    public static class EmployeeMenu
    {
        public static void Show()
        {
            while (true)
            {
                Thread.Sleep(2000);
                Console.Clear();
                Console.BackgroundColor = ConsoleColor.White;
                Console.WriteLine("                                             ╔════════════════════════════╗");
                Console.WriteLine("                                             ║    EMPLOYEE OPERATIONS     ║");
                Console.WriteLine("                                             ╚════════════════════════════╝\n");
                Console.Write("\n");

                Console.WriteLine("   1. Add Employee");
                Console.WriteLine("   2. Print All Employees");
                Console.WriteLine("   3. Promote Employee");
                Console.WriteLine("   4. Transfer Employee To Different Department");
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine("   5. Print Top Employees");
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("   6. Terminate Employee");
                Console.ForegroundColor = ConsoleColor.Black;
                Console.WriteLine("   7. Print Terminated Employees");
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("   8. Add Performance Rating");
                Console.WriteLine("   9. Get Current Rating");
                Console.ForegroundColor = ConsoleColor.Black;
                Console.WriteLine("   10. Back to Main Menu");
                Console.ForegroundColor = ConsoleColor.Black;
                Console.Write("\n   Enter your choice: ");
                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        EmployeeOperations.AddEmployee();
                        break;
                    case "2":
                        Console.Write("\n");
                        Company.PrintAllEmployees();
                        Console.ReadKey();
                        break;
                    case "3":
                        EmployeeOperations.PromoteEmployee();
                        break;
                    case "4":
                        EmployeeOperations.TransferEmployeeFromDepartment();
                        break;
                    case "5":
                        Company.GenerateReport();
                        break;
                    case "6":
                        EmployeeOperations.TerminateEmployee();
                        break;
                    case "7":
                        Console.Write("\n");
                        Company.PrintTerminatedEmployees();
                        Console.ReadKey();
                        break;
                    case "8":
                        EmployeeOperations.AddPerformanceRating();
                        break;
                    case "9":
                        EmployeeOperations.GetCurrentRating();
                        Console.ReadKey(); 
                        break;
                    case "10":
                        return;
                    default:
                        Console.WriteLine("   Invalid choice! Please Choose [1,2,3,4,5,6,7,8,9,10], Try again.");
                        break;
                }
            }
        }
    }
}
