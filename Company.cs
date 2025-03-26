﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace EmployeeManagementSystem
{
    public static class Company
    {
        public static List<Department> Departments = new List<Department>();
        public static List<Employee> Employees = new List<Employee>();

        public static Employee GetEmployeeById(int id)
        {
            return Employees.FirstOrDefault(employee => employee.GetId() == id);
        }

        public static void AddEmployee(Employee employee)
        {
            if (Employees.Any(emp => emp.GetId() == employee.GetId()))
            {
                Console.WriteLine("This Employee with this ID already exists!");
                return;
            }
            Employees.Add(employee);
            Console.WriteLine("Employee added successfully.");
        }

        public static void RemoveEmployee(Employee employee)
        {
            if (Employees.Remove(employee))
            {
                Console.WriteLine("This Employee has been removed!");
            }
            else
            {
                Console.WriteLine("Employee not found!");
            }
        }

        public static void AddDepartment(Department department)
        {
            if (Departments.Any(d => d.Name == department.Name))
            {
                Console.WriteLine("This Department already exists!");
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
                Console.WriteLine("This Employee does not exist!");
                return;
            }

            if (employee.GetPositionLevel() == PositionLevel.head)
            {
                Console.WriteLine("Employee cannot be promoted further than Head.");
                return;
            }

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
                    employee.Promote();
                    Console.WriteLine($" Employee is promoted to {employee.GetPositionLevel()}.");
                    break;
            }
        }

        public static void GenerateReport()
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Clear();
            Console.WriteLine(new string('=', 55));
            Console.WriteLine("                    COMPANY REPORT          ");
            Console.WriteLine(new string('=', 55));
            Console.ResetColor();
            Console.WriteLine("\n");

            PrintDepartments();
            PrintEmployeesByDepartment();
            PrintAllEmployees();

            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
            Console.Clear();
        }

        private static void PrintDepartments()
        {
            Console.WriteLine("                    *DEPARTMENTS*            ");
            Console.WriteLine(new string('-', 60));
            Console.WriteLine(" {0,-20} | {1,-20}", "Department Name", "Department Head");
            Console.WriteLine(new string('-', 60));

            foreach (var department in Departments.Distinct())
            {
                Console.WriteLine(" {0,-20} | {1,-20}", department.Name, department.DepartmentHead);
            }

            Console.WriteLine("\n");
        }

        private static void PrintEmployeesByDepartment()
        {
            Console.WriteLine("                    *EMPLOYEES BY DEPARTMENT*            ");
            Console.WriteLine(new string('-', 80));

            foreach (var department in Departments.Distinct())
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"\nDepartment: {department.Name}");
                Console.ResetColor();

                Console.WriteLine(new string('-', 80));
                Console.WriteLine(" {0,-10} | {1,-20} | {2,-10} | {3,-10} | {4,-10}",
                                  "ID", "Name", "Age", "Salary", "Position");
                Console.WriteLine(new string('-', 80));

                var employeesInDept = Employees.Where(e => e.GetDepartment().Name == department.Name).Distinct().ToList();

                if (employeesInDept.Count == 0)
                {
                    Console.WriteLine(" No employees in this department.\n");
                }
                else
                {
                    foreach (var emp in employeesInDept)
                    {
                        Console.WriteLine(" {0,-10} | {1,-20} | {2,-10} | {3,-10:C} | {4,-10}",
                                          emp.GetId(), emp.GetName(), emp.GetAge(), emp.GetSalary(),
                                          emp.GetPositionLevel());
                    }
                    Console.WriteLine("\n");
                }
            }
        }

        private static void PrintAllEmployees()
        {
            Console.WriteLine("\n");
            Console.WriteLine("                    *ALL EMPLOYEES*            ");
            Console.WriteLine(new string('-', 75));
            Console.WriteLine(" {0,-10} | {1,-20} | {2,-10} | {3,-10} | {4,-10} | {5,-10}",
                              "ID", "Name", "Age", "Salary", "Position", "Department");
            Console.WriteLine(new string('-', 75));

            foreach (var employee in Employees.Distinct())
            {
                Console.WriteLine(" {0,-10} | {1,-20} | {2,-10} | {3,-10:C} | {4,-10} | {5,-10}",
                                  employee.GetId(), employee.GetName(), employee.GetAge(),
                                  employee.GetSalary(), employee.GetPositionLevel(),
                                  employee.GetDepartment().Name);
            }
        }
    }
}
