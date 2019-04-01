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

        //Dalia's stuff

        //this method refreshes seats data and makes all seats available
        public void refreshSeating(int id, BookingData bd)
        {
            String connection = @"Provider=Microsoft.JET.OLEDB.4.0; 
				        Data Source =" + Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"DB\SystemsDevProjectDB.mdb");
            OleDbConnection myConnection = new OleDbConnection(connection);
            //quert to insert booking data
            string query = "Insert into Booking Values(" + id + "," + "'" + bd.getcategory() + "'," + bd.getseatnumber() + ",'" + "available" + "')";
            OleDbCommand Command = new OleDbCommand(query, myConnection);
            try
            {
                Command.CommandType = CommandType.Text;
                myConnection.Open();
                //adding parameters to query
                Command.Parameters.AddWithValue("@SeatType", bd.getcategory());
                Command.Parameters.AddWithValue("@Number", bd.getseatnumber());
                Command.Parameters.AddWithValue("@Availability", "available");
                Command.ExecuteNonQuery();


            }

            catch (Exception ex)
            {
                //MessageBox.Show(ex.ToString());
                System.Diagnostics.Debug.WriteLine("Exception: " + ex);
            }
            finally
            {
                myConnection.Close();
            }

        }
        //insert booking data into db 
        public void InsertList(List<BookingData> bookinglist)
        {
            foreach (BookingData item in bookinglist)
            {
                OleDbConnection connection = GetOleDbConnection();
                //updating the booking values
                string query = "Update Booking SET  Availability='booked' where SeatType='" + item.getcategory() + "' and Number=" + item.getseatnumber();
                OleDbCommand Command = new OleDbCommand(query, connection);
                try
                {

                    connection.Open();
                    //query parameters
                    Command.CommandType = CommandType.Text;
                    Command.Parameters.AddWithValue("@Availability", "booked");

                    Command.Parameters.AddWithValue("@SeatType", item.getcategory());
                    Command.Parameters.AddWithValue("@Number", item.getseatnumber());
                    Command.ExecuteNonQuery();

                }


                catch (Exception ex)
                {
                    //    MessageBox.Show(ex.ToString());
                    System.Diagnostics.Debug.WriteLine("Exception: " + ex);
                }
                finally
                {
                    connection.Close();
                }
            }
        }
        public List<BookingData> getBookingData()
        {
            //create a list of booking data
            List<BookingData> bookinglist = new List<BookingData>();
            OleDbConnection connection = GetOleDbConnection();
            //write query to retreive all data
            string query = "SELECT * from Booking ";
            OleDbCommand Command = new OleDbCommand(query, connection);
            try
            {
                connection.Open();
                OleDbDataReader Reader = Command.ExecuteReader();
                //reading each row after query execution
                while (Reader.Read())
                {
                    int id = (int)Reader["ID"];
                    string SeatType = (string)Reader["SeatType"];
                    int Number = (int)Reader["Number"];
                    string Availability = (string)Reader["Availability"];

                    //creating object from each row and adding into booking list
                    BookingData BD = new BookingData(Number, SeatType, Availability);
                    bookinglist.Add(BD);

                }
            }
            catch (Exception ex)
            {
                //   MessageBox.Show(ex.ToString());
                System.Diagnostics.Debug.WriteLine("Exception: " + ex);
            }
            finally
            {
                connection.Close();
            }

            return bookinglist;

        }

        public void InsertCardDetails(CardDetails cd)
        {

            //insert query to add card details in database
            OleDbConnection connection = GetOleDbConnection();
            string query = "insert into carddetails values ('" + cd.tickepurchase + "','" + cd.cardnumber + "','" + cd.cardtype + "','" + cd.MM + "','" + cd.YY + "','" + cd.CVV + "')";

            OleDbCommand Command = new OleDbCommand(query, connection);
            try
            {

                connection.Open();
                //adding parameters to query
                Command.CommandType = CommandType.Text;


                Command.Parameters.AddWithValue("@purchaselocation", cd.tickepurchase);

                Command.Parameters.AddWithValue("@CardNumber", cd.cardnumber);

                Command.Parameters.AddWithValue("@Type", cd.cardtype);
                Command.Parameters.AddWithValue("@ExpiryDateMM", cd.MM);
                Command.Parameters.AddWithValue("@ExpiryDateDD", cd.YY);
                Command.Parameters.AddWithValue("@CVV", cd.CVV);

                Command.ExecuteNonQuery();

            }


            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                //System.Diagnostics.Debug.WriteLine("Exception: " + ex);
            }
            finally
            {
                connection.Close();
            }
        }

        //Roshaans stuff

        //Get connection MY METHOD
        public static OleDbConnection GetConnection()
        {
            String connectionString;
            connectionString = @"Provider=Microsoft.JET.OLEDB.4.0;Data Source=I:\SystemsDev.mdb";
            return new OleDbConnection(connectionString);
        }

        //Method to add a review to the database
        public void WriteReview(string name, string review, DateTime date)
        {
            OleDbConnection connection = GetConnection();
            //OleDbConnection connection = GetOleDbConnection();
            string query = "INSERT INTO Review( [Date and Time of attendance], [Name of Performance], Review) VALUES( '" + date + "' , " + review + " )";
            OleDbCommand cmd = new OleDbCommand(query, connection);
            try
            {
                connection.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Failed. Error " + ex);
            }
            finally
            {
                connection.Close();
            }
        }
        //Method to add a review to the databse
        public void InsertReview(int playID, DateTime date, string review, int rating, int userID)
        {
            OleDbConnection connection = GetOleDbConnection();
            string query = "INSERT INTO Review ( ReviewDate, ReviewText, Rating, PlayID, UserID) VALUES ( '" + date + "' , '" + review + "' , '" + rating + "' , '" + playID + "' , '" + userID + "')";
            OleDbCommand playCommand = new OleDbCommand(query, connection);

            try
            {
                connection.Open();
                playCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Sorry. Unable to save your review right now. Please try again later: " + ex);
            }
            finally
            {
                connection.Close();
            }
        }
        //Method to display existing reviews to the user
        public List<String> readReview(int performanceID, List<String> r, List<int> i)
        {
            //Creating a connection
            OleDbConnection connection = GetOleDbConnection();
            string query = "SELECT * FROM [Review] WHERE PlayID =" + performanceID;
            OleDbCommand cmd = new OleDbCommand(query, connection);
            OleDbDataReader reader;
            //Clears the list on each instance to ensure reviews for other plays are not being stored
            r.Clear();
            i.Clear();
            try
            {
                connection.Open();
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    r.Add(reader["ReviewText"].ToString());
                    i.Add((int)reader["Rating"]);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                connection.Close();
            }
            return r;
        }
        public Receipt printReceipt(DateTime date, int i, double a, string performance, string fileName)
        {
            Receipt r = new Receipt(date, i, a, performance);
            r.printReceipt(fileName);
            return r;
        }
        public List<String> GetPerformance(string s, List<String> list)
        {
            OleDbConnection connection = GetConnection();
            string query = ("SELECT * FROM Performance WHERE [Type of performance]='" + s + "' ");
            OleDbCommand cmd = new OleDbCommand(query, connection);
            OleDbDataReader reader;
            list.Add("test");
            list.Clear();
            try
            {
                connection.Open();
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    list.Add(reader["Name of"].ToString());
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error. Could not perform the requested action. Error: " + ex);
            }
            finally
            {
                connection.Close();
            }
            return list;
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
                    employee = new Employee((int)reader["ID"], (string)reader["Role"], (int)reader["Salary"]);
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
                    agency = new Agency((int)reader["ID"], (string)reader["AgencyName"]);
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
                    customer = new Customer((int)reader["ID"], (DateTime)reader["DateOfBirth"]);
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
