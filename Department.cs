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
        public int EmployeeId { get; set; }
        public List<Employee> Employees { get; set; }
        public Department(string Name)
        {
            this.Name = Name;
            // Employees = new List<Employee>();
        }
        public void AddEmployee(Employee employee)
        {

            if (employee == null) throw new ArgumentNullException("employee not exist");
            Employees.Add(employee);
       
        }
        public void RemoveEmployee(Employee employee)
        {
            Employees.Remove(employee);
        }




    }
}