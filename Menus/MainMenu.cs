using System;

namespace EmployeeManagementSystem.Menus
{
    public static class MainMenu
    {
        public static void Show()
        {
            while (true)
            {
                Console.BackgroundColor = ConsoleColor.White;
                Console.ForegroundColor = ConsoleColor.Black;
                Thread.Sleep(2000);
                Console.Clear();
                Console.WriteLine("                                             ╔══════════════════════════════╗");
                Console.WriteLine("                                             ║  EMPLOYEE MANAGEMENT SYSTEM  ║");
                Console.WriteLine("                                             ╚══════════════════════════════╝\n");
                Console.Write("\n");
                Console.WriteLine("   1. Department Operations");
                Console.WriteLine("   2. Employee Operations");
                Console.WriteLine("   3. Generate Report");
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("   4. Exit");
                Console.ForegroundColor = ConsoleColor.Black;
                Console.Write("\n   Enter your choice: ");

                string mainChoice = Console.ReadLine();
                switch (mainChoice)
                {
                    case "1":
                        DepartmentMenu.Show();
                        break;
                    case "2":
                        EmployeeMenu.Show();
                        break; 
                    case "3":
                        Company.GenerateReport();
                        break;
                    case "4":
                        Console.WriteLine("   Exiting...");
                        Environment.Exit(0);
                        return;
                    default:
                        Console.WriteLine("   Invalid choice! Please Choose [1,2,3,4], Try again.");
                        break;
                }
            }
        }
    }
}
