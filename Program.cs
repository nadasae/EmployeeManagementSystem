namespace EmployeeManagementSystem
{


    internal class Program
    {

        static Company company = new Company();

        static void Main()
        {
            while (true)
            {
                Console.WriteLine("\nEmployee Management System");
                Console.WriteLine("1. Add Employee");
                Console.WriteLine("2. Add Department");
                //Console.WriteLine("3. Transfer Employee");
                //Console.WriteLine("4. Promote Employee");
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
                    //case "4":
                    //    PromoteEmployee();
                    //    break;
                    case "5":
                        company.GenerateReport();
                        break;
                    case "6":
                        Console.WriteLine("Exiting...");
                        return;
                    default:
                        Console.WriteLine("Invalid choice! Try again.");
                        break;
                }
            }
        }



        static void AddEmployee()
        {
            try
            {
                

                Console.Write("Enter Name: ");
                string name = Console.ReadLine();
                Console.Write("Enter Age: ");
                if (!int.TryParse(Console.ReadLine(), out int age))
                {
                    throw new Exception("Invalid Age format!");
                }

                Console.Write("Enter Salary: ");
                if (!decimal.TryParse(Console.ReadLine(), out decimal salary))
                {
                    throw new Exception("Invalid Salary format!");
                }

                Console.Write("Enter Department: ");
                string department = Console.ReadLine();

                Employee emp = new Employee(id, name, age, salary, department);
                company.AddEmployee(emp);
                Console.WriteLine("Employee added successfully!");
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

                Department dept = new Department(name, head);
                company.AddDepartment(dept);
                Console.WriteLine("Department added successfully!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
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
