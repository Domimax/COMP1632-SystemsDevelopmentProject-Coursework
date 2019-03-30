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

        //Method returns a List of all plays in a database.
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

        //Method returns a List of all performances in a database.
        public List<Performance> GetPerformances(int playId, OleDbConnection connection)
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
                    newPerformance.PerformanceDate = performanceDate;
                    newPerformance.PerformanceStatus = performanceStatus;
                    performances.Add(newPerformance);
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Exception: " + ex);
            }
            return performances;
        }

        //Method returns a user based on the provided username, password.
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

        /*
        //Returns a list of answers by using a provided id of a specific question.
        private List<Answer> GetAnswers(int questionId, OleDbConnection connection)
        {
            List<Answer> answers = new List<Answer>();
            //Query to select all answers which have a specific question_id.
            string query = "SELECT * FROM Answer WHERE Question_Id = " + questionId + ";";
            OleDbCommand answerCommand = new OleDbCommand(query, connection);
            try
            {
                OleDbDataReader answerReader = answerCommand.ExecuteReader();
                while (answerReader.Read())
                {
                    int id = (int)answerReader["ID"];
                    string answerText = (string)answerReader["AnswerText"];
                    bool correct = (bool)answerReader["Correct"];
                    answers.Add(new Answer(id, answerText, correct));
                }
                //Checks if there are any answers at all.
                if (answers.Count == 0)
                {
                    throw new Exception("Database is empty.");
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Exception: " + ex);
            }
            return answers;
        }

        //Returns a list of all the scores stored in the database to show in the leaderboards.
        public List<Score> GetScores()
        {
            List<Score> scores = new List<Score>();
            OleDbConnection connection = GetOleDbConnection();
            //Nested Select query used to retrieve top 15 scores based on percentage of correctly answered questions and the time it took
            //to complete the quiz.
            string query = "SELECT TOP 15 * FROM (SELECT * FROM Score ORDER BY CorrectPercentage DESC, TimeTook ASC, PlayerName DESC);";
            OleDbCommand scoreCommand = new OleDbCommand(query, connection);
            try
            {
                connection.Open();
                OleDbDataReader scoreReader = scoreCommand.ExecuteReader();
                while (scoreReader.Read())
                {
                    int id = (int)scoreReader["ID"];
                    double correctPercentage = (int)scoreReader["CorrectPercentage"];
                    DateTime completed = (DateTime)scoreReader["Completed"];
                    string playerName = (string)scoreReader["PlayerName"];
                    int timeTook = (int)scoreReader["TimeTook"];
                    int correctAnswers = (int)scoreReader["CorrectAnswers"];
                    int questionNumber = (int)scoreReader["QuestionNumber"];
                    Score newScore = new Score(id, correctAnswers, correctPercentage,
                        playerName, completed, timeTook, questionNumber);
                    //Check if it is a suitable score.
                    if (newScore != null)
                    {
                        scores.Add(newScore);
                    }
                    else
                    {
                        throw new Exception("newScore object is null.");
                    }
                }
                //Check if there are any score at all.
                if (scores.Count == 0)
                {
                    throw new Exception("Database is empty.");
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
            return scores;
        }

        //Method is used to store the score of a completed quiz to a database.
        public void AddScore(Score score)
        {
            OleDbConnection connection = GetOleDbConnection();
            //Query used to find the highest id in the table.
            string query = "SELECT ID FROM Score;";
            OleDbCommand maxIDCommand = new OleDbCommand(query, connection);
            int maxID = 0;
            try
            {
                connection.Open();
                OleDbDataReader maxIDReader = maxIDCommand.ExecuteReader();
                while (maxIDReader.Read())
                {
                    if (maxID < (int)maxIDReader["ID"])
                    {
                        maxID = (int)maxIDReader["ID"];
                    }
                }
                maxID++;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Exception: " + ex);
            }
            finally
            {
                connection.Close();
            }
            //A query used to insert a new tuple into the table.
            query = "INSERT INTO Score(ID, CorrectPercentage, Completed, PlayerName, TimeTook, CorrectAnswers, QuestionNumber)" +
                "VALUES (" + maxID + " , " + score.CorrectPercentage + " , #" + score.Completed.Date + "# , '" +
                 score.PlayerName + "' , " + score.TimeTook + " , " + score.CorrectAnswers + " , " + score.QuestionNumber + ");";
            OleDbCommand scoreCommand = new OleDbCommand(query, connection);
            try
            {
                connection.Open();
                scoreCommand.ExecuteNonQuery();
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
        */
    }
}
