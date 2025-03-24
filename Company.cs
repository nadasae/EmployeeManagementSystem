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
