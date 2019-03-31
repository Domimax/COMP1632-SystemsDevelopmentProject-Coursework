using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemsDevProject.Model
{
    public class Customer : User
    {
        public int CustomerID { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Username { get; set; }
    }
}
