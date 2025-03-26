using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using static EmployeeManagementSystem.PerformanceReview;

namespace EmployeeManagementSystem
{
    public  class Company
    {
        public List<Department> Departments = new List<Department>();
        public List<Employee> Employees = new List<Employee>();
        public Dictionary<Employee, List<PerformanceReview>> PerformanceReviews
        { get; private set; }
 = new Dictionary<Employee, List<PerformanceReview>>();


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
        public void RemoveEmployee(Employee employee) {
            if (Employees.Any(Employeee => Employeee.GetId() == employee.GetId()))
            {
                Employees.Remove(employee);
                Console.WriteLine("This Employee Has been Removed!");
                return;
            }
        }
        public void AddDepartment(Department department)
        {
            Departments.Add(department);
        }
        public void RemoveDepartment(Department department)
        {
            Departments.Remove(department);
        }
        public void Promote(int id)
        {
            Company company = new Company();
            Employee employee = GetEmployeeById(id);
            if (employee == null)
            {
                Console.WriteLine("This Employee does not Exist!");
                return ;
            }
            if (employee.GetPositionLevel() == PositionLevel.head)
                Console.WriteLine("Employee can not promote than a head ");
            else
            {
                // Calculate Average rate
                var AverageRate = company.PerformanceReviews[employee].Average(r => (int)r.rating);
                Rating roundedAverage = (Rating)Math.Round(AverageRate);
                switch (roundedAverage)
                {
                    case Rating.Poor:
                        Console.WriteLine($" Employee does not qualify for a promotion.");
                        break;
                    case Rating.Average:
                        Console.WriteLine($" Employee needs to improve performance for promotion.");
                        break;
                    case Rating.Good:
                    case Rating.Excellent:
                        {
                            employee.Promote();
                            Console.WriteLine($" Employee is Promoted to {employee.GetPositionLevel().ToString()}");
                        }
                        break;

                }
            }
        }

        public void GenerateReport()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(new string('=', 55));
            Console.WriteLine("                    COMPANY REPORT          ");
            Console.WriteLine(new string('=', 55));
            Console.WriteLine("\n");
            Console.WriteLine("                    *DEPARTMENTS*            ");
            Console.WriteLine(new string('-', 55));
            Console.WriteLine(" {0,-15} | {1,-20 :C}", "Department Name", "Department Head");
            Console.WriteLine(new string('-', 55));

            foreach (var departments in Departments)
            {
                Console.WriteLine(" {0,-15} | {1,-20 :C}", departments.Name,departments.DepartmentHead);
            }

            Console.WriteLine("\n");
            Console.WriteLine("                    *EMPLOYEES*            ");
            Console.WriteLine(new string('-', 75));

            Console.WriteLine(" {0,-10} | {1,-20} | {2,-10} | {3,-10} | {4,-10}", "Name", "Age", "Salary", "Department","Position");
            Console.WriteLine(new string('-', 75));

            foreach (var employeees in Employees)
            {
                Console.WriteLine(" {0,-10} | {1,-20} | {2,-10} | {3,-10:C} | {4,-10}", employeees.GetName(), employeees.GetAge(), employeees.GetSalary(), employeees.GetDepartment().Name , employeees.GetPositionLevel().ToString());
            }
            Console.ReadKey();
        }
    }
}
