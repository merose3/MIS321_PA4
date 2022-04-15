using System.Collections.Generic;
using api.models;
using api.database;
using MySql.Data.MySqlClient;
using api.Interfaces;
using System;

namespace api.database
{
    public class UpdateSong : IUpdateSong
    {
         public void Update(int id)
        {
            
            connectionstring myConnection = new connectionstring();
            string cs = myConnection.cs;
            using var con = new MySqlConnection(cs);
            con.Open(); 
            // Read reading = new Read();
            // reading.GetAll();
            // System.Console.WriteLine("Please select the ID of the song you would like to delete");
            // id = int.Parse(Console.ReadLine());

            string stm = @"Update Songs set favorited = 'y' where songID = @blah";

            using var cmd = new MySqlCommand (stm, con);
            cmd.Parameters.AddWithValue("@blah", id);

            cmd.ExecuteNonQuery();
            con.Close();
        }

        
    }
}