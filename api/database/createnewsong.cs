using System;
using System.Collections.Generic;
using api.models;
using api.database;
using MySql.Data.MySqlClient;
using api.Interfaces;

namespace api.database
{
    public class createnewsong : ICreateNewSong
    {
        public List<Songs> playlist { get; set; }
        public void CreateSongTable()
        {
            connectionstring myConnection = new connectionstring();
            string cs = myConnection.cs; //this is actually grabbing the connection string 

            using var con = new MySqlConnection(cs); // con = connection, now pulling the mysql connection (pulling connection string from above)
            con.Open();  //opens the connection 

            string stm = @"CREATE TABLE Songs(SongID INTEGER PRIMARY KEY AUTO_INCREMENT, SongTitle TEXT, SongTimestamp DATETIME, Deleted TEXT, Favorited TEXT)"; //sql statement 
            //should i only execute this once in SQL? or does it need to be done from the program?
            //string stm = @""; //sql statement 

            using var cmd = new MySqlCommand (stm, con); //creating the command

            cmd.ExecuteNonQuery(); //execute to actually make it happen
            con.Close();
        }

        public void Create(string songTitle) //make sure this is passing correctly from HTML
        {
            connectionstring myConnection = new connectionstring();
            string cs = myConnection.cs; //this is actually grabbing the connection string 

            Songs newSongs = new Songs(){SongTitle = songTitle, SongTimestamp = DateTime.Now, Deleted = "n", Favorited = "n"};

            using var con = new MySqlConnection(cs); // con = connection, now pulling the mysql connection (pulling connection string from above)
            con.Open();  //opens the connection
            
             
            // System.Console.WriteLine("Please enter the song you would like to add");
            // song.SongTitle = Console.ReadLine();
            // song.SongTimestamp = DateTime.Now;
            // song.Deleted = "n";

            string stm = @"INSERT INTO Songs(songID, songTitle, songTimestamp, Deleted, Favorited) VALUES (@songID, @songTitle, @timestamp, @deleted, @favorited)"; //sql statement 

            using var cmd = new MySqlCommand (stm, con); //creating the command
            cmd.Parameters.AddWithValue("@songID", newSongs.SongID);
            cmd.Parameters.AddWithValue("@songTitle", newSongs.SongTitle);
            cmd.Parameters.AddWithValue("@timeStamp", newSongs.SongTimestamp);
            cmd.Parameters.AddWithValue("@deleted", newSongs.Deleted);
            cmd.Parameters.AddWithValue("@favorited", newSongs.Favorited);

            cmd.ExecuteNonQuery(); //execute to actually make it happen
            con.Close();
        }

        public void Create()
        {
            throw new System.NotImplementedException();
        }

        // private class ConnectionString
        // {
        //     internal string cs;

        //     public ConnectionString()
        //     {
        //     }
        // }
    }
}