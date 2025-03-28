using EmployeeManagementSystem;
using System;
using System.Linq;

namespace EmployeeManagementSystem.Operations
{
    public static class CompanyOperations
    {
        public static bool IsValidDepartmentName(string name)
        {

            return name.All(c => char.IsLetter(c) || char.IsWhiteSpace(c));
        }
        public static bool CheckForCancel(string input)
        {
            if (input.Equals("CANCEL", StringComparison.OrdinalIgnoreCase))
            {
                Console.Write("\n");
                Console.WriteLine("   Operation canceled.");
                return true;
            }
            return false;
        }

        public static Department CheckDepartmentExisting(string NameOfDepartment)
        {
            return Company.Departments.FirstOrDefault(department => department.Name == NameOfDepartment);
        }
    }
       
    }
