using static System.Runtime.InteropServices.JavaScript.JSType;

namespace EmployeeManagementSystem
{


    internal class Program
    {

      
        
        static void Main()
        {
            while (true)
            {
                Console.BackgroundColor = ConsoleColor.White;
                Console.ForegroundColor = ConsoleColor.Black;
                Thread.Sleep(2000);
                Console.Clear();
                Console.WriteLine("                                             ╔════════════════════════════╗");
                Console.WriteLine("                                             ║  EMPLOYEE MANGMENT SYSTEM  ║");
                Console.WriteLine("                                             ╚════════════════════════════╝");
                Console.WriteLine("\n");
                Console.WriteLine("   1. Add Department ");
                Console.WriteLine("   2. Add Employee");
                Console.WriteLine("   3. Terminate Employee");
                Console.WriteLine("   4. Promote Employee");
                Console.WriteLine("   5. Generate Report");
                Console.WriteLine("   6. Exit");
                Console.Write("\n");
                Console.Write("   Enter your choice: ");

                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        AddDepartment();
                        break;
                    case "2":
                        AddEmployee();
                        break;
                    case "3":
                        TerminateEmployee();
                       break;
                    case "4":
                        PromoteEmployee();
                        break;
                    case "5":
                        Company.GenerateReport();
                        break;
                    case "6":
                        Console.WriteLine("Exiting...");
                        return;
                    default:
                        Console.WriteLine("Invalid choice! Please Choose [1,2,3,4,5,6], Try again.");
                        break;
                }
            }
        }



        static void AddEmployee()
        {
            try
            {
                string name = ReadFromUser.ReadString("   Enter Employee Name: ");
                int age = ReadFromUser.ReadInteger("   Enter Employee Age: ", 20, 60);
                decimal salary = ReadFromUser.ReadRealNumber("   Enter Employee Salary: ", 5000, 1000000);

                Department department = null;
                while (department == null)
                {
                    Console.Write("   Enter Employee Department: ");
                    string NameOfDepartmentAsString = Console.ReadLine().Trim().ToUpper();

                    department = CheckDepartmentExisting(NameOfDepartmentAsString);
                    if (department == null)
                    {
                        Console.WriteLine("   This department does not exist! Please enter a valid one.");
                    }
                }

                PositionLevel positionLevel;
                while (true)
                {
                    Console.WriteLine("   Choose The Position Level: ");
                    Console.WriteLine("   1- fresh, 2- junior, 3- senior, 4- teamleader, 5- head");
                    Console.Write("   Enter the number corresponding to the position level: ");

                    string input = Console.ReadLine();
                    if (Enum.TryParse(input, out positionLevel) && Enum.IsDefined(typeof(PositionLevel), positionLevel))
                    {
                        break; 
                    }
                    Console.WriteLine("   Invalid position level! Please enter a valid number (1-5).");
                }

                
                Employee emp = new Employee(name, age, salary, department, positionLevel.ToString());
                Company.AddEmployee(emp);

                Console.Beep();
               
            }
            catch (Exception ex)
            {
                Console.WriteLine($"   Error: {ex.Message}");
            }
        }

        static void AddDepartment()
        {
            try
            {
                Console.Write("   Enter Department Name: ");
                string name = Console.ReadLine().Trim().ToUpper(); 

                if (string.IsNullOrWhiteSpace(name) || !IsValidDepartmentName(name))
                {
                    Console.WriteLine("   Invalid department name! Please enter a valid name.");
                    return; 
                }

                Department existingDept = CheckDepartmentExisting(name);
                if (existingDept != null)
                {
                    Console.WriteLine("   Department already exists!");
                    return;
                }

                Console.Write("   Enter Department Head: ");
                string head = Console.ReadLine().Trim();

                Department dept = new Department(name);

                Company.AddDepartment(dept);

                Console.Beep();
                Console.Write("\n");
                Console.WriteLine("   Department added successfully!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"   Error: {ex.Message}");
            }
        }
        static bool IsValidDepartmentName(string name)
        {
          
            return name.All(c => char.IsLetter(c) || char.IsWhiteSpace(c));
        }
        public static Department CheckDepartmentExisting(string NameOfDepartment)
        {
            return Company.Departments.FirstOrDefault(department => department.Name == NameOfDepartment);
        }
        static void PromoteEmployee()
        {
            Console.Write("   Enter Employee Id: ");
            int Id ;
            if (int.TryParse(Console.ReadLine(), out Id))
            {
                Company.Promote(Id);
            }
            else
            {
                Console.WriteLine("   Invalid number!");
            }

        }
        static void TerminateEmployee()
        {
            try
            {
                Console.Write("   Enter Employee ID: ");
                int id = int.Parse(Console.ReadLine());
                

                Employee employee = Company.GetEmployeeById(id);
                if (employee != null)
                {
                    bool IsEmployeeTerminate = employee.IsEmployeeTerminate();
                    if (IsEmployeeTerminate == false)
                    {
                        employee.SetEmployeeTerminate();
                        Console.WriteLine("   Employee has been Terminated!");
                    }
                    
                }
               
            }
            catch (Exception ex)
            {
                Console.WriteLine($"   Error: {ex.Message}");
            }
        }

        //static void PromoteEmployee()
        //{
        //    try
        //    {
        //        Console.Write("Enter Employee ID: ");
        //        int id = int.Parse(Console.ReadLine());
        //        Console.Write("Enter Promotion Amount: ");
        //        decimal amount = decimal.Parse(Console.ReadLine());

        //        Employee emp = company.GetEmployeeById(id);
        //        if (emp != null)
        //        {
        //            emp.Promote(amount);
        //            Console.WriteLine("Employee promoted successfully!");
        //        }
        //        else
        //        {
        //            Console.WriteLine("Employee not found!");
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine($"Error: {ex.Message}");
        //    }
        //}
    }

}
