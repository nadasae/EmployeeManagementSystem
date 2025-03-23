using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagementSystem
{
    public class Department
    {
        private static int id = 1;
        public int Id { get; private set; }
        public string Name { get; set; }

        public Department()
        {
            Id = id++;
        }
        public static int  AddDeartment(string Name) { 
        Department department = new Department();
            department.Name = Name;
            return department.Id;
        }
        public static Department GetDepartmentById(int Id) 
        { 
         Department  department = Company.Departments.FirstOrDefault(x => x.Id == Id);
            if (department== null)
            {
                throw
                    new Exception("Department doesn't exist");
            }
            return department;
        
        }
        public static List<Department> GetAllDepartments()
        {
            return Company.Departments; 
        }


    }
}
