using SystemsDevProject.Model;

namespace SystemsDevProject
{
    public class UserFactory
    {
        public static User CreateUser(string userType)
        {
            if (userType == "Employee")
            {
                return new Employee();
            }
            else if (userType == "Agency")
            {
                return new Agency();
            }
            else if (userType == "Customer")
            {
                return new Customer();
            }
            else
            {
                return null;
            }
        }
    }
}
