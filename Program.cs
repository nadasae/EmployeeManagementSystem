using static System.Runtime.InteropServices.JavaScript.JSType;

namespace EmployeeManagementSystem
{


    internal class Program
    {

        static Company company = new Company();
        
        static void Main()
        {
            while (true)
            {
                Console.BackgroundColor = ConsoleColor.White;
                Console.ForegroundColor = ConsoleColor.Black;
                Thread.Sleep(2000);
                Console.Clear();
                Console.WriteLine("╔════════════════════════════╗");
                Console.WriteLine("║  EMPLOYEE MANGMENT SYSTEM  ║");
                Console.WriteLine("╚════════════════════════════╝");
                Console.WriteLine("\n");
                Console.WriteLine("1. Add Employee");
                Console.WriteLine("2. Add Department");
                //Console.WriteLine("3. Transfer Employee");
                Console.WriteLine("4. Promote Employee");
                Console.WriteLine("5. Generate Report");
                Console.WriteLine("6. Exit");
                Console.Write("Enter your choice: ");

                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        AddEmployee();
                        break;
                    case "2":
                        AddDepartment();
                        break;
                    //case "3":
                    //    TransferEmployee();
                    //    break;
                    case "4":
                        PromoteEmployee();
                        break;
                    case "5":
                        company.GenerateReport();
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
                

                //Console.Write("");

                string name = ReadFromUser.ReadString("Enter Name: ");
                int age = ReadFromUser.ReadInteger("Enter Age: ", 20, 60);
                //if (!int.TryParse(Console.ReadLine(), out int age))
                //{
                //    throw new Exception("Invalid Age format!");
                //}

                //Console.Write("Enter Salary: ");
                decimal salary = ReadFromUser.ReadRealNumber("Enter Salary: ", 5000, 1000000);
                //if (!decimal.TryParse(Console.ReadLine(), out decimal salary))
                //{
                //    throw new Exception("Invalid Salary format!");
                //}

                Console.Write("Enter Department: ");
                string NameOfDepartmentAsString = Console.ReadLine();
                Department department = CheckDepartmentExisiting(NameOfDepartmentAsString);
                //Department department = new Department(NameOfDepartmentAsString);
                Console.Write("Choose then enter The Position Level:  1- fresh, 2- junior, 3- senior, 4- teamleader, 5- head \n ");
                string positionLevel = Console.ReadLine();

                Employee emp = new Employee(name, age, salary,department,positionLevel);
                
                company.AddEmployee(emp);
                Console.Beep();
                
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }


        static void AddDepartment()
        {
            try
            {
                Console.Write("Enter Department Name: ");
                string name = Console.ReadLine();
                Console.Write("Enter Department Head: ");
                string head = Console.ReadLine();

                Department dept = new Department(name);
                company.AddDepartment(dept);
                Console.Beep();
                Console.WriteLine("Department added successfully!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        public static Department CheckDepartmentExisiting(string NameOfDepartment)
        {
            foreach (var department in company.Departments)
            {
                if (department.Name == NameOfDepartment)
                {
                    return department; 
                }
            }
            Department NewDepartment = new Department(NameOfDepartment);
            company.AddDepartment(NewDepartment);
            return NewDepartment;
        }
        static void PromoteEmployee()
        {
            Console.WriteLine("Enter Employee Id: ");
            int Id ;
            if (int.TryParse(Console.ReadLine(), out Id))
            {
                company.Promote(Id);
            }
            else
            {
                Console.WriteLine("Invalid number!");
            }

        }
        //static void TransferEmployee()
        //{
        //    try
        //    {
        //        Console.Write("Enter Employee ID: ");
        //        int id = int.Parse(Console.ReadLine());
        //        Console.Write("Enter New Department: ");
        //        string newDept = Console.ReadLine();

        //        Employee emp = company.GetEmployeeById(id);
        //        if (emp != null)
        //        {
        //            emp.TransferDepartment(newDept);
        //            Console.WriteLine("Employee transferred successfully!");
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
