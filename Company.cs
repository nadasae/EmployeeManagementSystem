using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagementSystem
{
    public  class Company
    {
        public  List<Department> Departments { get; set; }
        public  List<Employee> Employees { get; set; }
        public  List<Employee> FakeEmployees { get; set; }

        

        public  Employee GetEmployeeById(int id)
        {
            return Employees.FirstOrDefault(employee => employee.GetId() == id);

        }
        public void AddEmployee(Employee employee)
        {
            if (Employees.Any(Employeee => Employeee.GetId() == employee.GetId()))
            {
                Console.WriteLine("This Employee with this ID already exists!");
                return;
            }
            else {
                Employees.Add(employee);
                Console.WriteLine("Employee added successfully.");
            }
        }
        //public void RemoveEmployeeById(int id) { 

        //}
        public void Promote(int id)
        {
            Employee employee = GetEmployeeById(id);
            if (employee.GetPositionLevel() == PositionLevel.head)
                Console.WriteLine("Employee can not promote than a head ");
            else
            {
                switch (employee.Rating)
                {
                    case EmployeeRating.Poor:
                        Console.WriteLine($" Employee does not qualify for a promotion.");
                        break;
                    case EmployeeRating.Average:
                        Console.WriteLine($" Employee needs to improve performance for promotion.");
                        break;
                    case EmployeeRating.Good:
                        Console.WriteLine($"Employee is considered for a promotion.");
                        break;
                    case EmployeeRating.Excellent:
                        {
                            employee.Promote();
                            Console.WriteLine($" Employee is Promoted to {employee.GetPositionLevel}");
                        }
                        break;

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
        public void AddDepartment(Department department)
        {
            Departments.Add(department);
        }

        public void GenerateReport()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("====================================");
            Console.WriteLine("           Company Report           ");
            Console.WriteLine("====================================");
            Console.ResetColor();

            Console.WriteLine("{0,-10} | {1,-20} | {2,-10} | {3,-10}", "ID", "Name", "Age", "Salary", "Department");
            Console.WriteLine(new string('-', 55));

            foreach (var employeees in Employees)
            {
                Console.WriteLine("{0,-10} | {1,-20} | {2,-10} | {3,-10:C}", employeees.GetName(), employeees.GetAge(), employeees.GetSalary(), employeees.GetDepartment());
            }
        }
    }
}
