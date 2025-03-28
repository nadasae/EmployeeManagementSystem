using EmployeeManagementSystem.Operations;
using System;

namespace EmployeeManagementSystem.Menus
{
    public static class DepartmentMenu
    {
        public static void Show()
        {
            while (true)
            {
                Thread.Sleep(2000);
                Console.Clear();
                Console.WriteLine("                                             ╔════════════════════════════╗");
                Console.WriteLine("                                             ║   DEPARTMENT OPERATIONS    ║");
                Console.WriteLine("                                             ╚════════════════════════════╝\n");
                Console.Write("\n");

                Console.WriteLine("   1. Add Department");
                Console.WriteLine("   2. Assign Head Department");
                Console.WriteLine("   3. Print All Departments");
                Console.WriteLine("   4. Print Empolyee of Departments");
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("   5. Back to Main Menu");
                Console.ForegroundColor = ConsoleColor.Black;

                Console.Write("\n   Enter your choice: ");
                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        DepartmentOperations.AddDepartment();
                        break;
                    case "2":
                        DepartmentOperations.AddDepartmentHead();
                        break; 
                    case "3":
                        Console.WriteLine("\n");
                        Company.PrintDepartments();
                        Console.ReadKey();
                        break; 
                    case "4":
                        Console.WriteLine("\n");
                        Company.PrintEmployeesByDepartment();
                        Console.ReadKey();
                        break;
                    case "5":
                        return;
                    default:
                        Console.WriteLine("   Invalid choice! Please Choose [1,2,3,4,5], Try again.");
                        break;
                }
            }
        }
    }
}
