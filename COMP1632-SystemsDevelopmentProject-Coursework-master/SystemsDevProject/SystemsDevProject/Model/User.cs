using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemsDevProject.Model
{
    public abstract class User
    {
        public int UserID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string MobileNumber { get; set; }
        public string EmailAddress { get; set; }
        public string Username { get; set; }

        public void InitialiseUser(int userID, string firstName, string lastName, string address, string mobileNumber, string emailAddress, string username)
        {
            UserID = userID;
            FirstName = firstName;
            LastName = lastName;
            Address = address;
            MobileNumber = mobileNumber;
            EmailAddress = emailAddress;
            Username = username;
        }

        public void InitialiseUser(string firstName, string lastName, string address, string mobileNumber, string emailAddress, string username)
        {
            FirstName = firstName;
            LastName = lastName;
            Address = address;
            MobileNumber = mobileNumber;
            EmailAddress = emailAddress;
            Username = username;
        }
    }
}
