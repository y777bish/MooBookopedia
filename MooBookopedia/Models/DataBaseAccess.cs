using MooBookopedia.Data.ViewModels;
using System;
using System.Data.SQLite;
using System.IO;
using System.Reflection.Metadata;
using System.Security.Cryptography;

namespace MooBookopedia.Models
{
    public class DataBaseAccess
    {
        SQLiteConnection conn = new SQLiteConnection(@"Datasource=C:\Users\pawel\source\repos\MooBookopedia\filmoteka.db;Version=3");

        public void CreateAccount(string login, string email, string password)
        {
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

        public void CreatePost(string title, string directors, string actors, int yoproduction, string description, string imagelink)
        {
            try
            {
                conn.Open();
                var command = conn.CreateCommand();
                command.CommandText =
                @"
                INSERT INTO post (Title, Directors, Actors, YOProduction, Description, ImageLink)
                VALUES($Title, $Directors, $Actors, $YOProduction, $Description, $ImageLink)
                ";
                command.Parameters.AddWithValue("$Title", title);
                command.Parameters.AddWithValue("$Directors", directors);
                command.Parameters.AddWithValue("$Actors", actors);
                command.Parameters.AddWithValue("$YOProduction", yoproduction);
                command.Parameters.AddWithValue("$Description", description);
                command.Parameters.AddWithValue("$ImageLink", imagelink);
                command.ExecuteNonQuery();
                conn.Close();
            }
            catch (SQLiteException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void AddToFavorites(int userID, int postID)
        {
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

        public void AddComment(int userID, int postID, string content)
        {
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
        
        public string Login(string loginOrEmail)
        {
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
                return "cos nie działa"; //mozna zmienic na cos innego 
            }
        }

        public void GetCommentsForPost(int postID)
        {
            try
            {
                conn.Open();
                SQLiteDataReader datareader;
                var command = conn.CreateCommand();
                command.CommandText =
                @"
                SELECT (UserID, Content)., FROM favaorites WHERE UserID = $PserID
                ";
                command.Parameters.AddWithValue("$ostID", postID);
                datareader = command.ExecuteReader();
                while (datareader.Read())
                {
                    //pobieranie danych
                }

                conn.Close();
            }
            catch (SQLiteException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        fda
        public void GetFavouritesForUser(int userID)
        {
            try
            {
                conn.Open();
                SQLiteDataReader datareader;
                var command = conn.CreateCommand();
                command.CommandText =
                @"
                SELECT * FROM favorites WHERE UserID = $userID
                ";
                command.Parameters.AddWithValue("$userID", userID);
                datareader = command.ExecuteReader();
                while(datareader.Read())
                {
                    //pobieranie danych
                }

                conn.Close();
            }
            catch (SQLiteException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
