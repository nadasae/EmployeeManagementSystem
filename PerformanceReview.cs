using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagementSystem
{
    public class PerformanceReview
    {
        public Rating rating { get; set; }
        public PerformanceReview(Rating rating)
        {
            this.rating = rating;
        }
        public enum Rating
        {
            Poor,
            Average,
            Good,
            Excellent
        }

    }
}