using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using static EmployeeManagementSystem.PerformanceReview;

namespace EmployeeManagementSystem
{
    public static class Company
    {
        public static List<Department> Departments = new List<Department>();
        public static List<Employee> Employees = new List<Employee>();
        public static Dictionary<Employee, List<PerformanceReview>> PerformanceReviews
        { get; private set; } = new Dictionary<Employee, List<PerformanceReview>>();


        public static Employee GetEmployeeById(int id)
        {
            return Employees.FirstOrDefault(employee => employee.GetId() == id);
        }

        public static void AddEmployee(Employee employee)
        {
            if (Employees.Any(emp => emp.GetId() == employee.GetId()))
            {
                Console.WriteLine("   This Employee with this ID already exists!");
                return;
            }
            PerformanceReviews[employee] = new List<PerformanceReview>(4);
            Employees.Add(employee);
            
        }

        public static void RemoveEmployee(Employee employee)
        {
            if (Employees.Remove(employee))
            {
                Console.WriteLine("   This Employee has been removed!");
            }
            else
            {
                Console.WriteLine("   Employee not found!");
            }
        }

        public static void AddDepartment(Department department)
        {
            if (Departments.Any(d => d.Name == department.Name))
            {
                Console.WriteLine("   This Department already exists!");
                return;
            }
            Departments.Add(department);
        }

        public static void RemoveDepartment(Department department)
        {
            Departments.Remove(department);
        }

        public static void Promote(int id)
        {
            Employee employee = GetEmployeeById(id);
            if (employee == null)
            {
                Console.WriteLine("   This Employee does not exist!");
                return;
            }

            if (employee.GetPositionLevel() == PositionLevel.head)
            {
                Console.WriteLine("   Employee cannot be promoted further than Head.");
                return;
            }

            // ✅ Check if the employee has performance reviews before accessing the dictionary
            if (!PerformanceReviews.ContainsKey(employee) || PerformanceReviews[employee].Count == 0)
            {
                Console.WriteLine($"   No performance reviews found for {employee.GetName()}. Cannot promote.");
                return;
            }

            // Calculate Average rate
            if (PerformanceReviews.ContainsKey(employee))
            {
                if (PerformanceReviews[employee].Count == 4)
                {
                    var AverageRate = PerformanceReviews[employee].Average(r => (int)r.rating);
                    Rating roundedAverage = (Rating)Math.Round(AverageRate);

                    switch (roundedAverage)
                    {
                        case Rating.Poor:
                            Console.WriteLine($"   Employee does not qualify for a promotion.");
                            break;
                        case Rating.Average:
                            Console.WriteLine($"   Employee needs to improve performance for promotion.");
                            break;
                        case Rating.Good:
                        case Rating.Excellent:
                            {
                                employee.Promote();
                                Console.WriteLine($"   Employee is Promoted to {employee.GetPositionLevel().ToString()}");
                            }
                            break;
                    }
                }
                else {
                    Console.WriteLine($"   No performance reviews found for {employee.GetName()}. Cannot promote.");
                }
            }
        }

        public static void GenerateReport()
        {

            Console.Clear();
            Console.Write("   ");
            Console.WriteLine(new string('=', 112));
            Console.WriteLine("                                                    COMPANY REPORT          ");
            Console.Write("   ");
            Console.WriteLine(new string('=', 112));
            Console.WriteLine("\n");

            PrintDepartments();
            PrintEmployeesByDepartment();
            PrintAllEmployees();
            PrintTopEmployees();
            PrintTerminatedEmployees();

            Console.ForegroundColor = ConsoleColor.Black;
            Console.Write("   ");
            Console.WriteLine("\n \n   Press any key to Exit...");
            Console.ReadKey();
            Console.Clear();
            return;
        }

        public static void PrintDepartments()
        {
            Console.WriteLine("                    *DEPARTMENTS*            ");
            Console.Write("   ");
            Console.WriteLine(new string('-', 60));
            Console.Write("   ");
            Console.WriteLine(" {0,-20} | {1,-20}", "Department Name",  "Department Head");
            Console.Write("   ");
            Console.WriteLine(new string('-', 60));

            foreach (var department in Departments.Distinct())
            {
                string headName = "No Head Assigned";
                if (department.DepartmentHead != null && !department.DepartmentHead.IsEmployeeTerminate())
                {
                    headName = department.DepartmentHead.GetName();
                }

                Console.Write("   ");
                Console.WriteLine(" {0,-20} | {1,-20}", department.Name,  headName);
            }

            Console.WriteLine("\n");
        }

        public static void PrintEmployeesByDepartment()
        {
            Console.WriteLine("                    EMPLOYEES BY DEPARTMENT            ");
            Console.Write("   ");
            Console.WriteLine(new string('-', 100));

            foreach (var department in Departments.Distinct())
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine($"\n   Department: {department.Name}");

                Console.WriteLine("   " + new string('-', 80));
                Console.WriteLine("   {0,-10} | {1,-20} | {2,-10} | {3,-15} | {4,-15}",
                                  "ID", "Name", "Age", "Salary", "Position");
                Console.WriteLine("   " + new string('-', 80));

                var employeesInDept = Employees
                    .Where(e => e.GetDepartment() != null && e.GetDepartment().Name == department.Name)
                    .Distinct()
                    .ToList();

                if (employeesInDept.Count == 0)
                {
                    Console.WriteLine("   No employees in this department.\n");
                }
                else
                {
                    foreach (var employee in employeesInDept)
                    {
                        if (!employee.IsEmployeeTerminate())
                        {
                            string headIndicator = (department.DepartmentHead != null && department.DepartmentHead.GetId() == employee.GetId())
                                ? " (Head)" : "";

                            Console.Write("   ");
                            Console.WriteLine(" {0,-10} | {1,-20} | {2,-10} | {3,-15:C} | {4,-15}{5}",
                                             employee.GetId(), employee.GetName(), employee.GetAge(),
                                             employee.GetSalary(), employee.GetPositionLevel(), headIndicator);
                        }
                    }
                    Console.WriteLine("\n");
                }
            }
            Console.ForegroundColor = ConsoleColor.Black;
        }

        public static void PrintAllEmployees()
        {
            Console.WriteLine("\n");
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine("                    *ALL EMPLOYEES*            ");
            Console.Write("   ");
            Console.WriteLine(new string('-', 100));
            Console.Write("   ");
            Console.WriteLine(" {0,-10} | {1,-20} | {2,-10} | {3,-10} | {4,-10} | {5,-10} | {6,-10}",
                              "ID", "Name", "Age", "Salary", "Position", "Department","Performance ");
            Console.Write("   ");
            Console.WriteLine(new string('-', 100));

            foreach (var employee in Employees.Distinct())
            {
                if (!employee.IsEmployeeTerminate())
                {
                    string departmentName = employee.GetDepartment() != null ? employee.GetDepartment().Name : "No Department";

                    Console.Write("   ");
                    Console.WriteLine(" {0,-10} | {1,-20} | {2,-10} | {3,-10:C} | {4,-10} | {5,-10} | {6,-10}",
                              employee.GetId(), employee.GetName(), employee.GetAge(),
                              employee.GetSalary(), employee.GetPositionLevel(),
                              departmentName, employee.GetCurrentRating());
                }
            }
        }

        //private static void PrintTopEmployees()
        //{
        //    Console.WriteLine("\n");
        //    Console.ForegroundColor = ConsoleColor.Green;
        //    Console.WriteLine("                    *TOP EMPLOYEES*            ");
        //    Console.Write("   ");
        //    Console.WriteLine(new string('-', 100));
        //    Console.Write("   ");
        //    Console.WriteLine(" {0,-10} | {1,-20} | {2,-10} | {3,-10} | {4,-10} | {5,-10} | {6,-10}",
        //                      "ID", "Name", "Age", "Salary", "Position", "Department", "Performance");
        //    Console.Write("   ");
        //    Console.WriteLine(new string('-', 100));

        //    foreach (var employee in Employees.Distinct())
        //    {
        //        if (employee.IsEmployeeTerminate() == false)
        //        {
        //            if (employee.GetCurrentRating() > Rating.Average)
        //            {
        //                Console.Write("   ");
        //                Console.WriteLine(" {0,-10} | {1,-20} | {2,-10} | {3,-10:C} | {4,-10} | {5,-10} | {6,-10}",
        //                          employee.GetId(), employee.GetName(), employee.GetAge(),
        //                          employee.GetSalary(), employee.GetPositionLevel(),
        //                          employee.GetDepartment().Name, employee.GetCurrentRating());
        //                return;
        //            }

        //            Console.WriteLine("No Employee has been in Top!");
        //            return;

        //        }
        //        Console.ForegroundColor = ConsoleColor.Black;
        //    }
        //}
        public static void PrintTopEmployees()
        {
            Console.WriteLine("\n");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("                    *TOP EMPLOYEES*            ");
            Console.Write("   ");
            Console.WriteLine(new string('-', 100));
            Console.Write("   ");
            Console.WriteLine(" {0,-10} | {1,-20} | {2,-10} | {3,-10} | {4,-10} | {5,-10} | {6,-10}",
                              "ID", "Name", "Age", "Salary", "Position", "Department", "Performance");
            Console.Write("   ");
            Console.WriteLine(new string('-', 100));

            bool topEmployeeFound = false; // Flag to check if any top employee exists

            foreach (var employee in Employees.Distinct())
            {
                if (!employee.IsEmployeeTerminate() && employee.GetCurrentRating() > Rating.Average)
                {
                    string departmentName = employee.GetDepartment() != null ? employee.GetDepartment().Name : "No Department";

                    Console.Write("   ");
                    Console.WriteLine(" {0,-10} | {1,-20} | {2,-10} | {3,-10:C} | {4,-10} | {5,-10} | {6,-10}",
                              employee.GetId(), employee.GetName(), employee.GetAge(),
                              employee.GetSalary(), employee.GetPositionLevel(),
                              departmentName, employee.GetCurrentRating());

                    topEmployeeFound = true; // At least one top employee found
                }
            }

            // Print message only if no top employees were found
            if (!topEmployeeFound)
            {
                Console.WriteLine("\n   No Employee has been in Top!");
            }

            
        }

        public static void PrintTerminatedEmployees()
        {
            Console.WriteLine("\n");
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("                    *TERMINATED EMPLOYEES*            ");
            Console.Write("   ");
            Console.WriteLine(new string('-', 100));
            Console.Write("   ");
            Console.WriteLine(" {0,-10} | {1,-20} | {2,-10} | {3,-15} | {4,-15} | {5,-15}",
                              "ID", "Name", "Age", "Salary", "Position", "Department");
            Console.Write("   ");
            Console.WriteLine(new string('-', 100));

            bool foundTerminated = false;

            foreach (var employee in Employees.Distinct())
            {
                if (employee.IsEmployeeTerminate())
                {
                    string departmentName = employee.GetDepartment() != null ? employee.GetDepartment().Name : "No Department";
                    Console.Write("   ");
                    Console.WriteLine(" {0,-10} | {1,-20} | {2,-10} | {3,-15:C} | {4,-15} | {5,-15}",
                                      employee.GetId(), employee.GetName(), employee.GetAge(),
                                      employee.GetSalary(), employee.GetPositionLevel(), departmentName);
                    foundTerminated = true;
                }
            }

            if (!foundTerminated)
            {
                Console.Write("   ");
                Console.WriteLine("There are no Terminated Employees!");
            }

        Console.ForegroundColor = ConsoleColor.Black;
      
        }

    }
}
