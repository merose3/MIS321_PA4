using System.Collections.Generic;
using api.models;
using api.database;
using MySql.Data.MySqlClient;
using api.Interfaces;

namespace api.database
{
    public class DeleteSong : IDeleteSong
    {
        public List<Songs> playlist { get; set; }
        public void DeleteSongTable()
        {
            connectionstring myConnection = new connectionstring();
            string cs = myConnection.cs;

            using var con = new MySqlConnection(cs);
            con.Open(); 

            string stm = @"Drop table songs";

            using var cmd = new MySqlCommand (stm, con);

            cmd.ExecuteNonQuery();
            con.Close();
        }

        public void Delete(int id)
        {
            connectionstring myConnection = new connectionstring();
            string cs = myConnection.cs;
            using var con = new MySqlConnection(cs);
            con.Open(); 

            // Read reading = new Read();
            // reading.GetAll();
            // System.Console.WriteLine("Please select the ID of the song you would like to delete");
            // id = int.Parse(Console.ReadLine());

            string stm = @"Update Songs set deleted = 'y' where songID = @songID"; //sql statement 

            using var cmd = new MySqlCommand (stm, con);
            cmd.Parameters.AddWithValue("@songID", id);

            cmd.ExecuteNonQuery();
            con.Close();
            
        }

        public void Delete()
        {
            throw new System.NotImplementedException();
        }
    }
}