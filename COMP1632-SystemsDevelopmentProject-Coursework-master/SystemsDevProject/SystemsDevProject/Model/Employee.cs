using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemsDevProject.Model
{
    public class Employee : User
    {
        public int EmployeeID {get; set;}
        public string Role { get; set; }
        public int Salary { get; set; }
    }
}
