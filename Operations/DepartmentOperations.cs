using EmployeeManagementSystem;
using System;
using System.Linq;

namespace EmployeeManagementSystem.Operations
{
    public static class DepartmentOperations
    {
        public static void AddDepartment()
        {
            try
            {
                Console.Write("   Enter Department Name (or type 'CANCEL' to stop): ");
                string name = Console.ReadLine().Trim().ToUpper();
                if (CompanyOperations.CheckForCancel(name)) return;

                if (string.IsNullOrWhiteSpace(name) || !CompanyOperations.IsValidDepartmentName(name))
                {
                    Console.Write("\n");
                    Console.WriteLine("   Invalid department name! Please enter a valid name.");
                    return;
                }

                Department existingDept = CompanyOperations.CheckDepartmentExisting(name);
                if (existingDept != null)
                {
                    Console.Write("\n");
                    Console.WriteLine("   Department already exists!");
                    return;
                }
                Department dept = new Department(name);
                Company.AddDepartment(dept);

                Console.Beep();
                Console.Write("\n");
                Console.WriteLine("   Department added successfully!");
            }
            catch (Exception ex)
            {
                Console.Write("\n");
                Console.WriteLine($"   Error: {ex.Message}");
            }
        }
        public static void AddDepartmentHead()
        {
            try
            {
                int id = ReadFromUser.ReadInteger("   Enter Department Head ID (or type 'CANCEL' to stop): ");
                if (CompanyOperations.CheckForCancel(id.ToString())) return;
                Employee employee = Company.GetEmployeeById(id);
                if (employee == null)
                {
                    Console.Write("\n");
                    Console.WriteLine("   Employee not found!");
                    return;
                }

                string departmentName = ReadFromUser.ReadString("   Enter Department Name (or type 'CANCEL' to stop): ").Trim().ToUpper();
                if (CompanyOperations.CheckForCancel(departmentName)) return;
                Department department = CompanyOperations.CheckDepartmentExisting(departmentName);
                if (department == null)
                {
                    Console.Write("\n");
                    Console.WriteLine("   Department not found.");
                    return;
                }
                if (!employee.GetDepartment().Name.Equals(departmentName, StringComparison.OrdinalIgnoreCase))
                {
                    Console.Write("\n");
                    Console.WriteLine($"   Error: {employee.GetName()} does not belong to {departmentName} department.");
                    return;
                }

                string employeePosition = employee.GetPositionLevel().ToString();
                if (employeePosition != "senior" && employeePosition != "teamleader" && employeePosition != "head")
                {
                    Console.Write("\n");
                    Console.WriteLine($"   Error: {employee.GetName()} is a {employee.GetPositionLevel()} and cannot be a Department Head.");
                    return;
                }

                department.DepartmentHead = employee;
                Console.Write("\n");
                Console.WriteLine($"   {employee.GetName()} Has become head of {departmentName} Department.");
            }
            catch (Exception ex)
            {
                Console.Write("\n");
                Console.WriteLine($"   Error: {ex.Message}");
            }
        }



    }
}
