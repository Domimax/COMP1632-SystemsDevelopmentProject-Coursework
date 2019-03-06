using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.OleDb;
using System.IO;

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

        // Method returns a database connection.
        /*
        private OleDbConnection GetOleDbConnection()
        {
            String connection = @"Provider=Microsoft.JET.OLEDB.4.0; 
				 Data Source =" + Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"DB\SystemsDevProjectDB.mdb");
            OleDbConnection myConnection = new OleDbConnection(connection);
            return myConnection;
        }
        */
        /*
        //Method returns a List of all questions in a database.
        public List<Question> GetQuestions(string amount)
        {
            List<Question> questions = new List<Question>();
            OleDbConnection connection = GetOleDbConnection();
            //Selects the amount of questions selected by the user from a database.
            string query = "SELECT TOP  " + amount.ToString() + " * FROM Question;";
            OleDbCommand questionCommand = new OleDbCommand(query, connection);
            try
            {
                connection.Open();
                OleDbDataReader questionReader = questionCommand.ExecuteReader();
                while (questionReader.Read())
                {
                    int id = (int)questionReader["ID"];
                    string questionText = (string)questionReader["QuestionText"];
                    string questionType = (string)questionReader["QuestionType"];
                    Question newQuestion = null;
                    //A switch case is used to determine which kind of question has been extracted from a database.
                    switch (questionType)
                    {
                        case "InputAnswer":
                            newQuestion = new InputAnswerQuestion(id, questionText, questionType, GetAnswers(id, connection));
                            break;
                        case "MultipleChoice":
                            newQuestion = new MultipleChoiceQuestion(id, questionText, questionType, GetAnswers(id, connection));
                            break;
                        case "Music":
                            newQuestion = new MusicQuestion(id, questionText, questionType, GetAnswers(id, connection));
                            break;
                        case "Picture":
                            newQuestion = new PictureQuestion(id, questionText, questionType, GetAnswers(id, connection));
                            break;
                        case "YesOrNo":
                            newQuestion = new YesOrNoQuestion(id, questionText, questionType, GetAnswers(id, connection));
                            break;
                    }
                    //If an abnormal question type is discovered, an exception is thrown.
                    if (newQuestion != null)
                    {
                        questions.Add(newQuestion);
                    }
                    else
                    {
                        throw new Exception("newQuestion object is null.");
                    }
                }
                //Checking if there are any questions in the database at all.
                if (questions.Count == 0)
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
            return questions;
        }

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
        */
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
            string query = "INSERT INTO Reviews( [Date and Time of attendance], [Name of Performance], Review) VALUES( '" + date + "' , " + review + " )";
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
            string query = ("SELECT * FROM Performances WHERE [Type of performance]='" + s + "' ");
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
            /*
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
