using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagementSystem
{
     public class Employee
    {
        private int Id;
        private string Name;
        private int Age;
        private decimal Salary;
        private Department Department;
        private DateTime EmploymentDate;
        private static int counter = 0;
        private PositionLevel PositionLevel;

        public Employee(string name, int age, decimal salary, Department department, string positionLevel, DateTime employmentDate)
        {
            Id = ++counter;
            Name = name;
            Age = age;
            Salary = salary;
            Department = department;
            PositionLevel = (PositionLevel)Enum.Parse(typeof(PositionLevel), positionLevel, true);
            EmploymentDate = employmentDate;
        }
        public int GetId()
        {
            return Id;
        }
        public void SetName(string name)
        {
            Name = name;

        }
        public String GetName()
        {
            return Name;
        }
        public void SetSalary(decimal salary)
        {
            Salary = Salary;

        }
        public decimal GetSalary()
        {
            return Salary;
        }
        public void SetAge(int age)
        {
            Age = age;

        }
        public int GetAge()
        {
            return Age;
        }
        public void SetDepartment(Department department)
        {
            Department = department;
        }
        public Department GetDepartment()
        {
            return Department;

        }
        public void SetPositionLevel(string positionLevel)
        {
            PositionLevel = (PositionLevel)Enum.Parse(typeof(PositionLevel), positionLevel, true);
        }
        public PositionLevel GetPositionLevel()
        {
            return PositionLevel;
        }
        public void SetEmploymentDate(int year, int month, int day)
        {

            EmploymentDate = new DateTime(year, month, day);

        }
        public void GetEmploymentDate()
        {
            Console.WriteLine($"{EmploymentDate.ToShortDateString()}");
        }

        public  void TrasnferDepartment(string NewDepartment )
        {
           
            if (GetDepartment().Name == NewDepartment)
                throw new Exception("You'r already in this department");
            var department = Company.Departments.FirstOrDefault(d => d.Name == NewDepartment);

            if (department == null)
            {
                department = new Department(NewDepartment);
                Company.Departments.Add(department); 
            }
            SetDepartment(department) ;

        }

    }
}
