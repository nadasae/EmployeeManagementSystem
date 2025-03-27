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
            Employees.Add(employee);
            Console.WriteLine("   Employee added successfully.");
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
            // Calculate Average rate
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
            //PrintTopEmployees();
            PrintTerminatedEmployees();

            Console.ForegroundColor = ConsoleColor.Black;
            Console.Write("   ");
            Console.WriteLine("\n \n   Press any key to Exit...");
            Console.ReadKey();
            Console.Clear();
            return;
        }

        private static void PrintDepartments()
        {
            Console.WriteLine("                    *DEPARTMENTS*            ");
            Console.Write("   ");
            Console.WriteLine(new string('-', 60));
            Console.Write("   ");
            Console.WriteLine(" {0,-20} | {1,-20}", "Department Name", "Department Head");
            Console.Write("   ");
            Console.WriteLine(new string('-', 60));


            foreach (var department in Departments.Distinct())
            {
                Console.Write("   ");
                Console.WriteLine(" {0,-20} | {1,-20}", department.Name, department.DepartmentHead);
            }

            Console.WriteLine("\n");
            return;
        }

        private static void PrintEmployeesByDepartment()
        {
            Console.WriteLine("                    *EMPLOYEES BY DEPARTMENT*            ");
            Console.Write("   ");
            Console.WriteLine(new string('-', 80));
            Console.Write("   ");
            foreach (var department in Departments.Distinct())
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.Write("\n");
                Console.Write("   ");
                Console.WriteLine($"Department: {department.Name}");

                Console.Write("   ");
                Console.WriteLine(new string('-', 80));
                Console.Write("   ");
                Console.WriteLine(" {0,-10} | {1,-20} | {2,-10} | {3,-10} | {4,-10}",
                                  "ID", "Name", "Age", "Salary", "Position");
                Console.Write("   ");
                Console.WriteLine(new string('-', 80));

                var employeesInDept = Employees.Where(e => e.GetDepartment().Name == department.Name).Distinct().ToList();

                if (employeesInDept.Count == 0)
                {
                    Console.Write("   ");
                    Console.WriteLine(" No employees in this department.\n");

                }
                else
                {
                    foreach (var emp in employeesInDept)
                    {
                        if (emp.IsEmployeeTerminate() == false)
                        {
                            Console.Write("   ");
                            Console.WriteLine(" {0,-10} | {1,-20} | {2,-10} | {3,-10:C} | {4,-10}",
                   emp.GetId(), emp.GetName(), emp.GetAge(), emp.GetSalary(),
                   emp.GetPositionLevel());
                        }

                    }
                    Console.WriteLine("\n");

                }
            }
            return;
        }

        private static void PrintAllEmployees()
        {
            Console.WriteLine("\n");
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine("                    *ALL EMPLOYEES*            ");
            Console.Write("   ");
            Console.WriteLine(new string('-', 100));
            Console.Write("   ");
            Console.WriteLine(" {0,-10} | {1,-20} | {2,-10} | {3,-10} | {4,-10} | {5,-10}",
                              "ID", "Name", "Age", "Salary", "Position", "Department");
            Console.Write("   ");
            Console.WriteLine(new string('-', 100));

            foreach (var employee in Employees.Distinct())
            {
                if (employee.IsEmployeeTerminate() == false)
                {
                    Console.Write("   ");
                    Console.WriteLine(" {0,-10} | {1,-20} | {2,-10} | {3,-10:C} | {4,-10} | {5,-10}",
                                  employee.GetId(), employee.GetName(), employee.GetAge(),
                                  employee.GetSalary(), employee.GetPositionLevel(),
                                  employee.GetDepartment().Name);
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
        //            if (employee.GetRating() > EmployeeRating.Average)
        //            {
        //                Console.Write("   ");
        //                Console.WriteLine(" {0,-10} | {1,-20} | {2,-10} | {3,-10:C} | {4,-10} | {5,-10} | {6,-10}",
        //                          employee.GetId(), employee.GetName(), employee.GetAge(),
        //                          employee.GetSalary(), employee.GetPositionLevel(),
        //                          employee.GetDepartment().Name, employee.GetRating());
        //                return;
        //            }

        //            Console.WriteLine("No Employee has been in Top!");
        //            return;

        //        }
        //    }
        //}
        private static void PrintTerminatedEmployees()
        {
            Console.WriteLine("\n");
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("                    *TERMINATED EMPLOYEES*            ");
            Console.Write("   ");
            Console.WriteLine(new string('-', 100));
            Console.Write("   ");
            Console.WriteLine(" {0,-10} | {1,-20} | {2,-10} | {3,-10} | {4,-10} | {5,-10}",
                              "ID", "Name", "Age", "Salary", "Position", "Department");
            Console.Write("   ");
            Console.WriteLine(new string('-', 100));

            foreach (var employee in Employees.Distinct())
            {
                if (employee.IsEmployeeTerminate() == true)
                {
                    Console.Write("   ");
                    Console.WriteLine(" {0,-10} | {1,-20} | {2,-10} | {3,-10:C} | {4,-10} | {5,-10}",
                                  employee.GetId(), employee.GetName(), employee.GetAge(),
                                  employee.GetSalary(), employee.GetPositionLevel(),
                                  employee.GetDepartment().Name);
                    return;
                }
                Console.Write("   ");
                Console.WriteLine("Thers is no Terminated Employees!");
                return;

            }
        }
    }
}
