﻿using EmployeeManagementSystem;
using System;

namespace EmployeeManagementSystem.Operations
{
    public static class EmployeeOperations
    {
        public static void AddEmployee()
        {
            try
            {
                string name = ReadFromUser.ReadString("   Enter Employee Name (or type 'CANCEL' to stop): ");
                if (CompanyOperations.CheckForCancel(name)) return;

                int age = ReadFromUser.ReadInteger("   Enter Employee Age (or type 'CANCEL' to stop): ", 20, 60);
                if (CompanyOperations.CheckForCancel(age.ToString()))
                { return; }
               
                if (age == -1) return; 

                decimal salary = ReadFromUser.ReadRealNumber("   Enter Employee Salary (or type 'CANCEL' to stop): ", 5000, 1000000);
                if (CompanyOperations.CheckForCancel(salary.ToString())) return;
                if (salary == -1) return;

                Department department = null;
                while (department == null)
                {
                    string departmentInput = ReadFromUser.ReadString("   Enter Employee Department (or type 'CANCEL' to stop): ").ToUpper();
                    if (CompanyOperations.CheckForCancel(departmentInput)) return;

                    department = CompanyOperations.CheckDepartmentExisting(departmentInput);
                    if (department == null)
                    {
                        Console.WriteLine("   This department does not exist! Please enter a valid one.");
                    }
                }

                int positionInput = ReadFromUser.ReadInteger("   Choose The Position Level: \n   1- fresh, 2- junior, 3- senior, 4- teamleader, 5- head\n   Enter the number (or type 'CANCEL' to stop): ", 1, 5);
                if (CompanyOperations.CheckForCancel(positionInput.ToString())) return;
                if (positionInput == -1) return;

                PositionLevel positionLevel = (PositionLevel)positionInput;

                Employee emp = new Employee(name, age, salary, department, positionLevel.ToString());
                Company.AddEmployee(emp);
                Console.Write("\n");
                Console.WriteLine("   Employee added successfully!");
                Console.Beep();
                Console.Write("\n");
                
            }
            catch (Exception ex)
            {
                Console.WriteLine($"   Error: {ex.Message}");
            }
        }

        //public static void PromoteEmployee()
        //{
        //    Console.Write("   Enter Employee Id (or type 'CANCEL' to stop): ");
        //    string input = Console.ReadLine();

        //    if (CompanyOperations.CheckForCancel(input)) return;

        //    if (int.TryParse(input, out int Id))
        //    {
        //        Company.Promote(Id);
        //    }
        //    else
        //    {
        //        Console.Write("\n");
        //        Console.WriteLine("   Invalid number!");
        //    }
        //}
        public static void PromoteEmployee()
        {
            Console.Write("   Enter Employee Id (or type 'CANCEL' to stop): ");
            string input = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(input) || CompanyOperations.CheckForCancel(input))
                return;

            if (int.TryParse(input, out int Id))
            {
                Employee employee = Company.GetEmployeeById(Id);
                if (employee == null)
                {
                    Console.Write("\n");
                    Console.WriteLine("   Employee not found!");
                    return;
                }

                if (employee.IsEmployeeTerminate())
                {
                    Console.Write("\n");
                    Console.WriteLine("   Cannot promote a terminated employee!");
                    return;
                }

                // Call the promote function (doesn't return a value)
                Company.Promote(Id);
            }
            else
            {
                Console.Write("\n");
                Console.WriteLine("   Invalid number!");
            }
        }


        public static void TerminateEmployee()
        {
            try
            {
                Console.Write("   Enter Employee ID (or type 'CANCEL' to stop): ");
                string inputId = Console.ReadLine();
                if (CompanyOperations.CheckForCancel(inputId)) return;

                if (!int.TryParse(inputId, out int id))
                {
                    Console.Write("\n");
                    Console.WriteLine("   Invalid ID! Please enter a valid number.");
                    return;
                }

                Employee employee = Company.GetEmployeeById(id);
                if (employee != null)
                {
                    if (!employee.IsEmployeeTerminate())
                    {
                        employee.SetEmployeeTerminate();
                        Console.Write("\n");
                        Console.WriteLine("   Employee has been terminated!");
                    }
                    else
                    {
                        Console.Write("\n");
                        Console.WriteLine("   Employee is already terminated.");
                    }
                }
                else
                {
                    Console.Write("\n");
                    Console.WriteLine("   Employee not found!");
                }
            }
            catch (Exception ex)
            {
                Console.Write("\n");
                Console.WriteLine($"   Error: {ex.Message}");
            }
        }

        public static void TransferEmployeeFromDepartment()
        {
            try
            {
                Console.Write("   Enter Employee ID (or type 'CANCEL' to stop): ");
                string inputId = Console.ReadLine();
                if (CompanyOperations.CheckForCancel(inputId)) return;

                if (!int.TryParse(inputId, out int id))
                {
                    Console.Write("\n");
                    Console.WriteLine("   Invalid ID! Please enter a valid number.");
                    return;
                }

                Console.Write("   Enter Department You want to Transfer to (or type 'CANCEL' to stop): ");
                string department = Console.ReadLine().Trim().ToUpper();
                if (CompanyOperations.CheckForCancel(department)) return;

                Employee employee = Company.GetEmployeeById(id);
                if (employee != null)
                {
                    employee.TrasnferDepartment(department);
                    Console.Write("\n");
                    Console.WriteLine("   Employee Transferred successfully!");
                }
                else
                {
                    Console.Write("\n");
                    Console.WriteLine("   Employee not found!");
                }
            }
            catch (Exception ex)
            {
                Console.Write("\n");
                Console.WriteLine($"   Error: {ex.Message}");
            }
        }

    }
}
