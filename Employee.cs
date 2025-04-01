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
        private bool TerminatedStatus;
        //public Dictionary<int, List<PerformanceReview>> PerformanceReviews
        //{ get; private set; } = new Dictionary<int, List<PerformanceReview>>();//
        private Rating rating;

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
            TerminatedStatus = false;
            rating = Rating.NotRated;
           // PerformanceReviews[this.GetId()] = new List<PerformanceReview>(); //
        }
        public void AddDepartmentHead(int EmployeeId,string Name)
        {
            var employee = Company.Employees.FirstOrDefault(e => e.Id == EmployeeId);
            if (employee == null)
            {
                Console.WriteLine("   Employee doesn't exist");
                return;
            }
            var department = Company.Departments.FirstOrDefault(d => d.Name == Name);
            if (department == null)
            {
                Console.WriteLine("  Department not exist");
                return;
            }
            if(employee.PositionLevel==PositionLevel.teamleader|| employee.PositionLevel == PositionLevel.head) { 
                department.DepartmentHead = employee;
                department.EmployeeId = EmployeeId;
                Console.WriteLine("   Successfully you became a Head for your department");
            }
            else
            {
                Console.WriteLine("   Unfortunatily, You can't be a head right now " +
                    "Do your best to deserve it ");
            }
        }


        public void AddPerformanceReview(Rating rating)
        {
            if (Company.PerformanceReviews.Count == 4)
            {
                Console.WriteLine("This Employee Can't  be more rated this year");
                return;
            }

            #region Trash
            //var employee = Company.Employees.FirstOrDefault(e => e.GetId() == employeeId);
            //if (employee == null) throw new Exception("Employee doesn't exist");
            //var review = new PerformanceReview(rating);
            ////if (!Company.PerformanceReviews.ContainsKey(this))
            ////{
            ////    Company.PerformanceReviews[this] = new List<PerformanceReview>();
            ////}
            //Company.PerformanceReviews[this] = new List<PerformanceReview>();
            //this.PerformanceReviews[this].Add(review); 
            #endregion 
            if (!Company.PerformanceReviews.ContainsKey(this))
            {
                Company.PerformanceReviews[this] = new List<PerformanceReview>(4);
            }
            Company.PerformanceReviews[this].Add(new PerformanceReview(rating));
        }
        public Employee GetEmployeeById(int id)
        {

            return Company.Employees.FirstOrDefault(employee => employee.GetId() == id);

        }
        public  void ResetPerformanceReviews()
        {
            foreach (var employee in Company.Employees.Where(e => !e.TerminatedStatus)) 
            {
                if (Company.PerformanceReviews.ContainsKey(employee) && Company.PerformanceReviews[employee].Count == 4)
                {
                    Company.PerformanceReviews[employee] = new List<PerformanceReview>(4);
                }
            }
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
        public Rating GetCurrentRating()
        {
            if (!Company.PerformanceReviews.ContainsKey(this) || Company.PerformanceReviews[this].Count == 0)
            {
                return Rating.NotRated;
            }
            return Company.PerformanceReviews[this].Last().rating;
        }
        public DateTime GetEmploymentDate()
        {
            //Console.WriteLine($"{EmploymentDate.ToShortDateString()}");
            return EmploymentDate;

        }
        public void SetEmployeeTerminate()
        {
            TerminatedStatus = true;
        }
        public bool IsEmployeeTerminate()
        {
            return TerminatedStatus;
        }
        public void Promote()
        {

            PositionLevel++;
            Salary = Salary + Salary * 0.10m;
        }


        public void TrasnferDepartment(string NewDepartment)
        {

            if (this.GetDepartment().Name == NewDepartment)
            {
                Console.WriteLine("   You'r already in this department");
                return;
            }
            var department = Company.Departments.FirstOrDefault(d => d.Name == NewDepartment);

            if (department == null)
            {
                Console.Write("\n");
                Console.WriteLine("   Department Doesn't exists!");
                return;
            }
            
                SetDepartment(department);
                Console.Write("\n");
                Console.WriteLine("   Employee Transferred successfully!");
            
            
        }
    }
}