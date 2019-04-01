using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemsDevProject.Model
{
    public class Employee : User
    {
        public int EmployeeID { get; set; }
        public string Role { get; set; }
        public int Salary { get; set; }

        public Employee(int employeeID, string role, int salary)
        {
            EmployeeID = employeeID;
            Role = role;
            Salary = salary;
        }

        public Employee(string role, int salary)
        {
            Role = role;
            Salary = salary;
        }
    }
}
