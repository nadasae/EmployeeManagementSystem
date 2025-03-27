using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using static EmployeeManagementSystem.PerformanceReview;

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
        private bool Statues;
        public Dictionary<Employee, List<PerformanceReview>> PerformanceReviews
        { get; private set; }
    = new Dictionary<Employee, List<PerformanceReview>>();

        public Employee()
        {

        }
        public Employee(string name, int age, decimal salary, Department department, string positionLevel)
        {
            Id = ++counter;
            Name = name;
            Age = age;
            Salary = salary;
            Department = department;
            PositionLevel = (PositionLevel)Enum.Parse(typeof(PositionLevel), positionLevel, true);
            EmploymentDate = DateTime.Now;
            Statues = true;
          
            //Rating = EmployeeRating.Average;
        }
        public  void AddDepartmentHead(int EmployeeId)
        { 
            var employee = Company.Employees.FirstOrDefault(e => e.GetId() == EmployeeId);
            if (employee == null) throw new Exception("Employee doesn't exist");
            var AverageRate = Company.PerformanceReviews[employee].Average(r => (int)r.rating);
            Rating roundedAverage = (Rating)Math.Round(AverageRate);
            if (roundedAverage == Rating.Excellent) { 
            Department department = employee.GetDepartment();
                department.DepartmentHead = employee;
                department.EmployeeId = EmployeeId;
                Console.WriteLine("Successfully you became a Head for your department");
            }
            else
            {
                Console.WriteLine("Unfortunatily, You can't be a head right now " +
                    "Do your best to deserve it ");
            }
        }
        public void AddPerformanceReview(int employeeId, Rating rating)
        {
            
            var employee = Company.Employees.FirstOrDefault(e => e.GetId() == employeeId);
            if (employee == null) throw new Exception("Employee doesn't exist");
            var review = new PerformanceReview(rating);
            if (!Company.PerformanceReviews.ContainsKey(employee))
            {
                Company.PerformanceReviews[employee] = new List<PerformanceReview>();
            }
            Company.PerformanceReviews[employee].Add(review);
        }
        public Employee GetEmployeeById(int id)
        {
             
            return Company.Employees.FirstOrDefault(employee => employee.GetId() == id);

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
            Salary = salary;

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

        public void GetEmploymentDate()
        {
            Console.WriteLine($"{EmploymentDate.ToShortDateString()}");
        }
        public void SetEmployeeTerminate()
        {
            Statues = false;
        }
        public bool IsEmployeeTerminate()
        {
            return Statues;
        }
        public void Promote()
        {

            PositionLevel++;
            //salary to be added
        }


        public void TrasnferDepartment(string NewDepartment)
        {
          
            if (GetDepartment().Name == NewDepartment)
                throw new Exception("You'r already in this department");
            var department = Company.Departments.FirstOrDefault(d => d.Name == NewDepartment);

            if (department == null)
            {
                department = new Department(NewDepartment);
                Company.Departments.Add(department);
            }
            SetDepartment(department);

        }
    }
}
