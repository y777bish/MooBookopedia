using MooBookopedia.Data.ViewModels;
using System;
using System.ComponentModel.Design;
using System.Data.SQLite;
using System.IO;
using System.Reflection.Metadata;
using System.Security.Cryptography;

namespace MooBookopedia.Models
{
    public class DataBaseAccess
    {
        //everything above SQLiteConnection is to be removed if another way of connection to the database is implemented
        static string FindSolutionFilePath(string directory) //gets a path to a .cs file located in solution folder, idk how it works if theres more than 1, so keep it to 1 .cs file pls
        {                                                    //also pls check if this even works before you start using it, if not hard code database file path
            while (!string.IsNullOrEmpty(directory))
            {
                string[] solutionFiles = Directory.GetFiles(directory, "*.db");
                if (solutionFiles.Length > 0)
                {
                    return solutionFiles[0];
                }
                directory = Directory.GetParent(directory)?.FullName;
            }
            return null;
        }
        static string datasource = "Datasource=" + FindSolutionFilePath(Directory.GetCurrentDirectory()) + ";Version=3";
        SQLiteConnection conn = new SQLiteConnection(datasource);

        public static void CreateAccount(string login, string email, string password) //dodaje konto do bazy danych
        {
            SQLiteConnection conn = new SQLiteConnection(datasource);
            try
            {
                conn.Open();
                var command = conn.CreateCommand();
                command.CommandText =
                @"
                INSERT INTO account (Login, Email, Password)
                VALUES($Login, $Email, $Password)
                ";
                command.Parameters.AddWithValue("$Login", login);
                command.Parameters.AddWithValue("$Email", email);
                command.Parameters.AddWithValue("$Password", password);
                command.ExecuteNonQuery();
                conn.Close();
            }
            catch (SQLiteException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static void CreatePost(string title, string directors, string actors, int yoproduction, string description, string imagelink, int opid/*original poster id*/) //dodaje post do bazy danych
        {
            SQLiteConnection conn = new SQLiteConnection(datasource);
            try
            {
                conn.Open();
                var command = conn.CreateCommand();
                command.CommandText =
                @"
                INSERT INTO post (Title, Directors, Actors, YOProduction, Description, ImageLink, OPID)
                VALUES($Title, $Directors, $Actors, $YOProduction, $Description, $ImageLink, $opid)
                ";
                command.Parameters.AddWithValue("$Title", title);
                command.Parameters.AddWithValue("$Directors", directors);
                command.Parameters.AddWithValue("$Actors", actors);
                command.Parameters.AddWithValue("$YOProduction", yoproduction);
                command.Parameters.AddWithValue("$Description", description);
                command.Parameters.AddWithValue("$ImageLink", imagelink);
                command.Parameters.AddWithValue("$opid", opid);
                command.ExecuteNonQuery();
                conn.Close();
            }
            catch (SQLiteException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static void AddToFavorites(int userID, int postID) //dodaje polubinie do bazy danych
        {
            SQLiteConnection conn = new SQLiteConnection(datasource);
            try
            {
                conn.Open();
                var command = conn.CreateCommand();
                command.CommandText =
                @"
                INSERT INTO favorites (UserID, PostID)
                VALUES($UserID, $PostID)
                ";
                command.Parameters.AddWithValue("$UserID", userID);
                command.Parameters.AddWithValue("$PostID", postID);
                command.ExecuteNonQuery();
                conn.Close();
            }
            catch (SQLiteException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static void AddComment(int userID, int postID, string content) //dodaje komentarz do bazy danych
        {
            SQLiteConnection conn = new SQLiteConnection(datasource);
            try
            {
                conn.Open();
                var command = conn.CreateCommand();
                command.CommandText =
                @"
                INSERT INTO comments (UserID, PostID, Content)
                VALUES($UserID, $PostID, $Content)
                ";
                command.Parameters.AddWithValue("$UserID", userID);
                command.Parameters.AddWithValue("$PostID", postID);
                command.Parameters.AddWithValue("$Content", content);
                command.ExecuteNonQuery();
                conn.Close();
            }
            catch (SQLiteException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static string Login(string loginOrEmail) //zwraca hasło dla danego loginu lub maila, w celu uwierzytleniania 
        {
            SQLiteConnection conn = new SQLiteConnection(datasource);
            try
            {
                conn.Open();
                SQLiteDataReader datareader;
                var command = conn.CreateCommand();
                command.CommandText =
                @"
                SELECT Password FROM account 
                WHERE Login = $loginOrEmail
                OR Email = $loginOrEmail
                ";
                command.Parameters.AddWithValue("$loginOrEmail", loginOrEmail);
                datareader = command.ExecuteReader();
                string password = datareader.GetString(0);
                conn.Close();
                return password;
            }
            catch (SQLiteException ex)
            {
                Console.WriteLine(ex.Message);
                return "cos nie działa"; //wypadałoby zmienic na cos innego 
            }
        }

        public static void GetFullUserInfo(string loginOrEmail) //mozna zmienic na id jesli trzeba, razem ze zmianą query sql
        {
            SQLiteConnection conn = new SQLiteConnection(datasource);
            try
            {
                conn.Open();
                SQLiteDataReader datareader;
                var command = conn.CreateCommand();
                command.CommandText =
                @"
                SELECT * FROM account 
                WHERE Login = $loginOrEmail
                OR Email = $loginOrEmail
                ";
                command.Parameters.AddWithValue("$loginOrEmail", loginOrEmail);
                datareader = command.ExecuteReader();
                while (datareader.Read())
                {
                    //pobieranie danych (ID, Login, Email, Password, Admin)
                }
                conn.Close();
            }
            catch (SQLiteException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static void GetCommentsForPost(int postID) //pobiera komentarze dla danego posta
        {
            SQLiteConnection conn = new SQLiteConnection(datasource);
            try
            {
                conn.Open();
                SQLiteDataReader datareader;
                var command = conn.CreateCommand();
                command.CommandText =
                @"
                SELECT (ID, UserID, Content) FROM comments WHERE PostID = $postID
                ";
                command.Parameters.AddWithValue("$postID", postID);
                datareader = command.ExecuteReader();
                while (datareader.Read())
                {
                    //pobieranie danych (ID, UserID, Content)
                }
                conn.Close();
            }
            catch (SQLiteException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        
        public static void GetFavouritesForUser(int userID) //pobiera polubienia dla danego uzytkownika
        {
            SQLiteConnection conn = new SQLiteConnection(datasource);
            try
            {
                conn.Open();
                SQLiteDataReader datareader;
                var command = conn.CreateCommand();
                command.CommandText =
                @"
                SELECT PostID FROM favorites WHERE UserID = $userID
                ";
                command.Parameters.AddWithValue("$userID", userID);
                datareader = command.ExecuteReader();
                while (datareader.Read())
                {
                    //pobieranie danych (postID)
                }

                conn.Close();
            }
            catch (SQLiteException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static void GetPost(int postID) //można zmienic na Title albo cokolwiek innego po czym chcecie ściągać posta, tylko trzeba zmodyfikować sqla
        {
            SQLiteConnection conn = new SQLiteConnection(datasource);
            try
            {
                conn.Open();
                SQLiteDataReader datareader;
                var command = conn.CreateCommand();
                command.CommandText =
                @"
                SELECT * FROM post WHERE ID = $postID
                ";
                command.Parameters.AddWithValue("$postID", postID);
                datareader = command.ExecuteReader();
                while (datareader.Read())
                {
                    //pobieranie danych (ID, Title, Director, Actors, YOProduction, Description, ImageLink, OPID)
                }

                conn.Close();
            }
            catch (SQLiteException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static void RemoveFromFavorites(int postID, int userID) //self explanatory
        {
            SQLiteConnection conn = new SQLiteConnection(datasource);
            try
            {
                conn.Open();
                var command = conn.CreateCommand();
                command.CommandText =
                @"
                DELETE FROM favorites WHERE PostID = $postID AND UserID = $userID
                ";
                command.Parameters.AddWithValue("$postID", postID);
                command.Parameters.AddWithValue("$userID", userID);
                command.ExecuteNonQuery();
                conn.Close();
            }
            catch (SQLiteException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static void ADMINDeleteAccount(string email) //delete account w/o verification, can be changed to ID with query modification
        {
            SQLiteConnection conn = new SQLiteConnection(datasource);
            try
            {
                conn.Open();
                var command = conn.CreateCommand();
                command.CommandText =
                @"
                DELETE FROM account WHERE Email = $email 
                ";
                command.Parameters.AddWithValue("$email", email);
                command.ExecuteNonQuery();
                conn.Close();
            }
            catch (SQLiteException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static void USERDeleteAccount(string email, string password) //delete account with verification
        {
            SQLiteConnection conn = new SQLiteConnection(datasource);
            try
            {
                conn.Open();
                var command = conn.CreateCommand();
                command.CommandText =
                @"
                DELETE FROM account WHERE Email = $email AND Password = $password   
                ";
                command.Parameters.AddWithValue("$email", email);
                command.Parameters.AddWithValue("$password", password);
                conn.Close();
            }
            catch (SQLiteException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static void ADMINDeletePost(int postID) //delete any users' post
        {
            SQLiteConnection conn = new SQLiteConnection(datasource);
            try
            {
                conn.Open();
                var command = conn.CreateCommand();
                command.CommandText =
                @"
                DELETE FROM post WHERE ID = $postID 
                ";
                command.Parameters.AddWithValue("$postID", postID);
                command.ExecuteNonQuery();
                conn.Close();
            }
            catch (SQLiteException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public static void USERDeletePost(int postID, int opid) //delete current users post, if current userid is passed as opid
        {
            SQLiteConnection conn = new SQLiteConnection(datasource);
            try
            {
                conn.Open();
                var command = conn.CreateCommand();
                command.CommandText =
                @"
                DELETE FROM post WHERE ID = $postID AND OPID = $opid
                ";
                command.Parameters.AddWithValue("$postID", postID);
                command.Parameters.AddWithValue("$opid", opid);
                command.ExecuteNonQuery();
                conn.Close();
            }
            catch (SQLiteException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static void ADMINDeleteComment(int commentID) //self explanatory
        {
            SQLiteConnection conn = new SQLiteConnection(datasource);
            try
            {
                conn.Open();
                var command = conn.CreateCommand();
                command.CommandText =
                @"
                DELETE FROM comments WHERE ID = $commentID
                ";
                command.Parameters.AddWithValue("$commentID", commentID);
                command.ExecuteNonQuery();
                conn.Close();
            }
            catch (SQLiteException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static void USERDeleteComment(int commentID, int userID) //restricts comment deletion to own comments, if current user id passed as userID
        {
            SQLiteConnection conn = new SQLiteConnection(datasource);
            try
            {
                conn.Open();
                var command = conn.CreateCommand();
                command.CommandText =
                @"
                DELETE FROM comments WHERE ID = $commentID AND UserID = $userID
                ";
                command.Parameters.AddWithValue("$commentID", commentID);
                command.Parameters.AddWithValue("$userID", userID);
                command.ExecuteNonQuery();
                conn.Close();
            }
            catch (SQLiteException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static void ChangeAdminPrivelages(int userID) //Adds or removes user as admin, to be replaced if another way of discerning admins is introduced (mby an admin table?)
        {
            SQLiteConnection conn = new SQLiteConnection(datasource);
            try
            {
                conn.Open();
                var command = conn.CreateCommand();
                command.CommandText =
                @"
                UPDATE account SET Admin = CASE Admin
                    WHEN 1 THAN 0
                    WHEN 0 THAN 1
                    END
                WHERE UserID = $userID
                ";
                command.Parameters.AddWithValue("$userID", userID);
                command.ExecuteNonQuery();
                conn.Close();
            }
            catch (SQLiteException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }


        public static void ChangePassword(int loginOrEmail, string newPassword) //can be changed to ID, with sql query modification
        {
            SQLiteConnection conn = new SQLiteConnection(datasource);
            try
            {
                conn.Open();
                var command = conn.CreateCommand();
                command.CommandText =
                @"
                UPDATE account SET Password = $newPassword
                WHERE Login = $loginOrEmail OR Email = $loginOrEmail
                ";
                command.Parameters.AddWithValue("$newPassword", newPassword);
                command.Parameters.AddWithValue("$loginOrEmail", loginOrEmail);
                command.ExecuteNonQuery();
                conn.Close();
            }
            catch (SQLiteException ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        public static void ChangeLogin(int userID, string newLogin) //pass current user ID as userID
        {
            SQLiteConnection conn = new SQLiteConnection(datasource);
            try
            {
                conn.Open();
                var command = conn.CreateCommand();
                command.CommandText =
                @"
                UPDATE account SET Login = $newLogin
                WHERE UserID = $userID
                ";
                command.Parameters.AddWithValue("$newLogin", newLogin);
                command.Parameters.AddWithValue("$userID", userID);
                command.ExecuteNonQuery();
                conn.Close();
            }
            catch (SQLiteException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static void EditComment(int commentID, int userID, string content) //pass current user id as userID, or pass comment's UserID if current user is flagged as admin
        {
            SQLiteConnection conn = new SQLiteConnection(datasource);
            try
            {
                conn.Open();
                var command = conn.CreateCommand();
                command.CommandText =
                @"
                UPDATE comments SET Content = $content
                WHERE UserID = $userID AND CommentID = $commentID
                ";
                command.Parameters.AddWithValue("$content", content);
                command.Parameters.AddWithValue("$userID", userID);
                command.Parameters.AddWithValue("$commentID", commentID);
                command.ExecuteNonQuery();
                conn.Close();
            }
            catch (SQLiteException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static void EditPost(int postID, string title, string directors, string actors, int yoproduction, string description, string imagelink, int opid) //pass current user id as opid to verify user, or pass post OPID as opid if current user is flagged admin
        {
            SQLiteConnection conn = new SQLiteConnection(datasource);
            try
            {
                conn.Open();
                var command = conn.CreateCommand();
                command.CommandText =
                @"
                UPDATE post SET Title = $Title, Directors = $Directors, Actors = $Actors, YOProduction = $YOProduction, Description = $Description, ImageLink = $ImageLink
                WHERE OPID = $opid AND ID = $postID
                ";
                command.Parameters.AddWithValue("$postID", postID);
                command.Parameters.AddWithValue("$Title", title);
                command.Parameters.AddWithValue("$Directors", directors);
                command.Parameters.AddWithValue("$Actors", actors);
                command.Parameters.AddWithValue("$YOProduction", yoproduction);
                command.Parameters.AddWithValue("$Description", description);
                command.Parameters.AddWithValue("$ImageLink", imagelink);
                command.Parameters.AddWithValue("$opid", opid);
                command.ExecuteNonQuery();
                conn.Close();
            }
            catch (SQLiteException ex)
            {
                Console.WriteLine(ex.Message);
            }


        }

        public static List<Movies> GetAllFilms()
        {
            SQLiteConnection conn = new SQLiteConnection(datasource);
            List<Movies> films = new List<Movies>();

            try
            {
                conn.Open();
                var command = conn.CreateCommand();
                command.CommandText = @"
                    SELECT Title, Description, ImageLink, OPID
                    FROM post
                ";

                SQLiteDataReader datareader = command.ExecuteReader();

                while (datareader.Read())
                {
                    Movies film = new Movies
                    {
                        MovieName = datareader.GetString(0),
                        MoviePictureURL = datareader.GetString(1),
                        MovieDescription = datareader.GetString(2),
                        /*MovieCategory = datareader.GetString(3)*/
                    };

                    films.Add(film);
                }

                conn.Close();
            }
            catch (SQLiteException ex)
            {
                Console.WriteLine(ex.Message);
            }

            return films;
        }
    }
}
