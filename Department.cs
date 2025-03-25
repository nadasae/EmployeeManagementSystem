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
        public Department(string Name)
        {
            this.Name = Name;
           // Employees = new List<Employee>();
        }
        public  void AddEmployee(Employee employee)
        {
            
                if (employee == null) throw new ArgumentNullException("employee not exist");
                Employees.Add(employee);
        }
        public void RemoveEmployee(Employee employee)
        {
                Employees.Remove(employee);
        }
        // remove static keywords 
        // class  Implementing Performance Management
        //Add performance ratings for employees.
        //Create a PerformanceReview class.
        //Implement logic to promote employees based on ratings.

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
