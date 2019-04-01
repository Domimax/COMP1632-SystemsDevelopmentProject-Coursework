using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Windows.Forms;
using SystemsDevProject.Model;

namespace SystemsDevProject
{
    // A Database class which uses a Singleton pattern to only allow a single instance of itself and is used for interaction
    //with a database.
    internal sealed class DBSingleton
    {
        //A lock object to make the accessing of a single instance thread safe.
        private static readonly object padlock = new object();
        //A Singleton instance of the class.
        private static DBSingleton instance = null;

        //Property used for the retrieval of the Singleton instance.
        public static DBSingleton GetDBSingletonInstance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new DBSingleton();
                    }
                    return instance;
                }
            }
        }

        // Constructor. Used only once.
        private DBSingleton()
        {

        }

        public void InsertCardDetails(CardDetails cardDetails, int bookingID)
        {
            //insert query to add card details in database
            OleDbConnection connection = GetOleDbConnection();
            string query = "INSERT INTO CardDetails (NameOnCard, CardNumber, CardType, ExpirationDate, CVV, BookingID) VALUES ('" +
                cardDetails.NameOnCard + "' , '" + cardDetails.CardNumber + "' , '" + cardDetails.CardType + "' , '"
                + cardDetails.ExpirationDate + "' , '" + cardDetails.CVV + "' , '" + bookingID + "');";
            OleDbCommand command = new OleDbCommand(query, connection);
            try
            {
                connection.Open();
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Exception: " + ex);
            }
            finally
            {
                connection.Close();
            }
        }

        public void InsertTicket(Ticket ticket, int bookingID)
        {
            //insert query to add card details in database
            OleDbConnection connection = GetOleDbConnection();
            string query = "INSERT INTO Ticket (TicketPrice, TicketType, TicketDescription, BookingID, SeatID) VALUES ('" +
                ticket.TicketPrice + "' , '" + ticket.TicketType + "' , '" + ticket.TicketDescription + "' , '"
                + bookingID + "' , '" + ticket.TicketSeat.SeatID + "');";
            string occupiedQuery = "UPDATE Seat SET Occupied = 1 " + "WHERE ID = " + ticket.TicketSeat.SeatID + ";";
            OleDbCommand command = new OleDbCommand(query, connection);
            OleDbCommand occupiedCommand = new OleDbCommand(occupiedQuery, connection);
            try
            {
                connection.Open();
                command.ExecuteNonQuery();
                occupiedCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Exception: " + ex);
            }
            finally
            {
                connection.Close();
            }
        }

        public int InsertBooking(Booking booking, int userID)
        {
            int bookingID = 0;
            //insert query to add card details in database
            OleDbConnection connection = GetOleDbConnection();
            string query = "INSERT INTO [Booking] (BookingDate, TotalCost, CollectionType, UserID) VALUES ('" + booking.BookingDate +
                "' , '" + booking.TotalCost + "' , '" + booking.CollectionType + "' , '" + userID + "');";
            OleDbCommand command = new OleDbCommand(query, connection);
            string bookingIDQuery = "SELECT MAX(ID) FROM [Booking];";
            OleDbCommand bookingIDCommand = new OleDbCommand(bookingIDQuery, connection);
            try
            {
                connection.Open();
                command.ExecuteNonQuery();
                bookingID = (int)bookingIDCommand.ExecuteScalar();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Exception: " + ex);
            }
            finally
            {
                connection.Close();
            }
            return bookingID;
        }

        // Method returns a database connection.
        private OleDbConnection GetOleDbConnection()
        {
            String connection = @"Provider=Microsoft.JET.OLEDB.4.0; 
				 Data Source =" + Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"DB\SystemsDevProjectDB.mdb");
            OleDbConnection myConnection = new OleDbConnection(connection);
            return myConnection;
        }

        public List<Play> GetPlays()
        {
            List<Play> plays = new List<Play>();
            OleDbConnection connection = GetOleDbConnection();
            string query = "SELECT * FROM Play;";
            OleDbCommand playCommand = new OleDbCommand(query, connection);
            try
            {
                connection.Open();
                OleDbDataReader playReader = playCommand.ExecuteReader();
                while (playReader.Read())
                {
                    int id = (int)playReader["ID"];
                    string playName = (string)playReader["PlayName"];
                    int playDuration = (int)playReader["PlayDuration"];
                    string playCast = (string)playReader["PlayCast"];
                    string pictureString = (string)playReader["PictureString"];
                    Play newPlay = new Play();
                    newPlay.PlayID = id;
                    newPlay.PlayName = playName;
                    newPlay.PlayDuration = playDuration;
                    newPlay.PlayCast = playCast;
                    newPlay.PictureString = pictureString;
                    newPlay.PlayPerformances = GetPerformances(id, connection);
                    plays.Add(newPlay);
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Exception: " + ex);
            }
            finally
            {
                connection.Close();
            }
            return plays;
        }

        private List<Performance> GetPerformances(int playId, OleDbConnection connection)
        {
            List<Performance> performances = new List<Performance>();
            string query = "SELECT * FROM Performance WHERE PlayID = " + playId + ";";
            OleDbCommand performanceCommand = new OleDbCommand(query, connection);
            try
            {
                OleDbDataReader performanceReader = performanceCommand.ExecuteReader();
                while (performanceReader.Read())
                {
                    int id = (int)performanceReader["ID"];
                    DateTime performanceDate = (DateTime)performanceReader["PerformanceDate"];
                    string performanceStatus = (string)performanceReader["PerformanceStatus"];
                    Performance newPerformance = new Performance();
                    newPerformance.PerformanceID = id;
                    newPerformance.PerformanceDate = performanceDate;
                    newPerformance.PerformanceStatus = performanceStatus;
                    newPerformance.PerformanceBands = GetBands(id, connection);
                    performances.Add(newPerformance);
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Exception: " + ex);
            }
            return performances;
        }

        private List<Band> GetBands(int performanceID, OleDbConnection connection)
        {
            List<Band> bands = new List<Band>();
            string query = "SELECT * FROM [Band] WHERE PerformanceID = " + performanceID + ";";
            OleDbCommand command = new OleDbCommand(query, connection);
            try
            {
                OleDbDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    int id = (int)reader["ID"];
                    string bandNumber = (string)reader["BandNumber"];
                    double bandPrice = (int)reader["BandPrice"];
                    Band newBand = new Band();
                    newBand.BandID = id;
                    newBand.BandNumber = bandNumber;
                    newBand.BandPrice = bandPrice;
                    newBand.BandSeats = GetSeats(id, connection);
                    bands.Add(newBand);
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Exception: " + ex);
            }
            return bands;
        }

        private List<Seat> GetSeats(int bandID, OleDbConnection connection)
        {
            List<Seat> seats = new List<Seat>();
            string query = "SELECT * FROM Seat WHERE BandID = " + bandID + ";";
            OleDbCommand command = new OleDbCommand(query, connection);
            try
            {
                OleDbDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    int id = (int)reader["ID"];
                    int seatNumber = (int)reader["SeatNumber"];
                    bool occupied = (bool)reader["Occupied"];
                    Seat newSeat = new Seat();
                    newSeat.SeatID = id;
                    newSeat.SeatNumber = seatNumber;
                    newSeat.Occupied = occupied;
                    seats.Add(newSeat);
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Exception: " + ex);
            }
            return seats;
        }

        public User GetUser(string username, string password)
        {
            User user = null;
            OleDbConnection connection = GetOleDbConnection();
            string userQuery = "SELECT * FROM [User] WHERE Username = '" + username + "' AND Password = '" + password + "';";
            OleDbCommand userCommand = new OleDbCommand(userQuery, connection);
            try
            {
                connection.Open();
                OleDbDataReader userReader = userCommand.ExecuteReader();
                while (userReader.Read())
                {
                    if ((string)userReader["UserType"] == "Employee")
                    {
                        user = GetEmployee(connection, (int)userReader["ID"]);
                    }
                    else if ((string)userReader["UserType"] == "Agency")
                    {
                        user = GetAgency(connection, (int)userReader["ID"]);
                    }
                    else
                    {
                        user = GetCustomer(connection, (int)userReader["ID"]);
                    }
                    user.InitialiseUser((int)userReader["ID"], (string)userReader["FirstName"], (string)userReader["LastName"],
                        (string)userReader["Address"], (string)userReader["MobileNumber"], (string)userReader["EmailAddress"],
                        (string)userReader["Username"]);
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Exception: " + ex);
            }
            finally
            {
                connection.Close();
            }
            return user;
        }

        private Employee GetEmployee(OleDbConnection connection, int userID)
        {
            string query = "SELECT * FROM Employee WHERE UserID = " + userID + ";";
            OleDbCommand command = new OleDbCommand(query, connection);
            Employee employee = null;
            try
            {
                OleDbDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    employee = (Employee)UserFactory.CreateUser("Employee");
                    employee.EmployeeID = (int)reader["ID"];
                    employee.Role = (string)reader["Role"];
                    employee.Salary = (int)reader["Salary"];
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Exception: " + ex);
            }
            return employee;
        }

        private Agency GetAgency(OleDbConnection connection, int userID)
        {
            string query = "SELECT * FROM Agency WHERE UserID = " + userID + ";";
            OleDbCommand command = new OleDbCommand(query, connection);
            Agency agency = null;
            try
            {
                OleDbDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    agency = (Agency)UserFactory.CreateUser("Agency");
                    agency.AgencyID = (int)reader["ID"];
                    agency.AgencyName = (string)reader["AgencyName"];
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Exception: " + ex);
            }
            return agency;
        }

        private Customer GetCustomer(OleDbConnection connection, int userID)
        {
            string query = "SELECT * FROM Customer WHERE UserID = " + userID + ";";
            OleDbCommand command = new OleDbCommand(query, connection);
            Customer customer = null;
            try
            {
                OleDbDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    customer = (Customer)UserFactory.CreateUser("Customer");
                    customer.CustomerID = (int)reader["ID"];
                    customer.DateOfBirth = (DateTime)reader["DateOfBirth"];
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Exception: " + ex);
            }
            return customer;
        }

        public void RegisterEmployee(Employee employee, string password)
        {
            OleDbConnection connection = GetOleDbConnection();
            int userID = RegisterUser(connection, employee, password, "Agency");
            //A query used to insert a new tuple into the table.
            string employeeQuery = "INSERT INTO Employee (Role, Salary, UserID)" +
                " VALUES ('" + employee.Role + "', '" + employee.Salary + "', '" + userID + "');";
            OleDbCommand employeeCommand = new OleDbCommand(employeeQuery, connection);
            try
            {
                connection.Open();
                employeeCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Exception: " + ex);
            }
            finally
            {
                connection.Close();
            }
        }

        public void RegisterAgency(Agency agency, string password)
        {
            OleDbConnection connection = GetOleDbConnection();
            int userID = RegisterUser(connection, agency, password, "Agency");
            //A query used to insert a new tuple into the table.
            string agencyQuery = "INSERT INTO Agency (AgencyName, UserID)" +
                " VALUES ('" + agency.AgencyName + "', '" + userID + "');";
            OleDbCommand agencyCommand = new OleDbCommand(agencyQuery, connection);
            try
            {
                connection.Open();
                agencyCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Exception: " + ex);
            }
            finally
            {
                connection.Close();
            }
        }

        public void RegisterCustomer(Customer customer, string password)
        {
            OleDbConnection connection = GetOleDbConnection();
            int userID = RegisterUser(connection, customer, password, "Customer");
            string customerQuery = "INSERT INTO Customer (DateOfBirth, UserID)" +
                " VALUES ('" + customer.DateOfBirth + "', '" + userID + "');";
            OleDbCommand customerCommand = new OleDbCommand(customerQuery, connection);
            try
            {
                connection.Open();
                customerCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Exception: " + ex);
            }
            finally
            {
                connection.Close();
            }
        }

        private int RegisterUser(OleDbConnection connection, User user, string password, string type)
        {
            int userID = -1;
            string userQuery = "INSERT INTO [User] (FirstName, LastName, Address, MobileNumber, EmailAddress, Username, [Password], UserType) " +
                 "VALUES ('" + user.FirstName + "' , '" + user.LastName + "' , '" + user.Address + "' , '" + user.MobileNumber +
                 "' , '" + user.EmailAddress + "' , '" + user.Username + "' , '" + password + "' , '" + type + "');";
            OleDbCommand userCommand = new OleDbCommand(userQuery, connection);
            string userIDQuery = "SELECT MAX(ID) FROM [User];";
            OleDbCommand userIDCommand = new OleDbCommand(userIDQuery, connection);
            try
            {
                connection.Open();
                userCommand.ExecuteNonQuery();
                userID = (int)userIDCommand.ExecuteScalar();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex);
            }
            finally
            {
                connection.Close();
            }
            return userID;
        }
    }
}
