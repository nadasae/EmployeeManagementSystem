using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagementSystem
{
    public class Department
    {
     
        public string Name { get; set; }
        public Employee DepartmentHead { get; set; }
        public List<Employee> Employees { get; set; }
        public Department()
        {
            Employees = new List<Employee>();
        }
        public static void AddEmployee(Employee employee)
        {
            var department = Company.Departments.FirstOrDefault(d => d.Name == employee.GetDepartment().Name);
            if (department == null) throw new Exception("Department is null ");
            else
            {
                if (employee == null) throw new ArgumentNullException("employee not exist");

                department.Employees.Add(employee);
            }

        }
        public static void RemoveEmployee( int EmployeeId)
        {
            var employee = Company.Employees.FirstOrDefault(e=> e.GetId() == EmployeeId);
            if (employee == null) throw new ArgumentNullException("employee not exist");

            var department = Company.Departments.FirstOrDefault(d=>d.Name==employee.GetDepartment().Name);
            if (department == null) throw new Exception("Department  of this employee is null ");

                department.Employees.Remove(employee);
            

        }

        #region Trash
        //private static int id = 1;
        //public int Id { get; set; }
        //public Department()
        //{
        //    Id = id++;
        //}
        //public static int  AddDeartment(string Name) { 
        //Department department = new Department();
        //    department.Name = Name;
        //    return department.Id;
        //}
        //public static Department GetDepartmentById(int Id) 
        //{ 
        // Department  department = Company.Departments.FirstOrDefault(x => x.Id == Id);
        //    if (department== null)
        //    {
        //        throw
        //            new Exception("Department doesn't exist");
        //    }
        //    return department;

        //}
        //public static List<Department> GetAllDepartments()
        //{
        //    return Company.Departments; 
        //} 
        #endregion


    }
}
