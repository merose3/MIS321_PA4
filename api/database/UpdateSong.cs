using System.Collections.Generic;
using api.models;
using api.database;
using MySql.Data.MySqlClient;
using api.Interfaces;

namespace api.database
{
    public class UpdateSong : IUpdateSong
    {
         public void Update(Songs song)
        {
            connectionstring myConnection = new connectionstring();
            string cs = myConnection.cs;

            using var con = new MySqlConnection(cs);
            con.Open(); 
            // System.Console.WriteLine("Please select the ID of the song you would like to delete");
            // Read reading = new Read();
            // reading.ShowAllSongs();
            // song.SongID = int.Parse(Console.ReadLine());

            // System.Console.WriteLine("What would you like to change the song title to?");
            // song.SongTitle = Console.ReadLine();

            //string stm = @"Update Songs set songTitle = @songTitle where songID = @songId"; //sql statement 
            string stm = @"Update Songs set songTitle = @song.SongTitle where songID = @Song.SongID";

            using var cmd = new MySqlCommand (stm, con);
            cmd.Parameters.AddWithValue("@song.SongID", song.SongID);
            cmd.Parameters.AddWithValue("@song.SongTitle", song.SongTitle);

            cmd.ExecuteNonQuery();
            con.Close();
        }

    }
}