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
         public void Update(Songs song)
        {
            connectionstring myConnection = new connectionstring();
            string cs = myConnection.cs;

            using var con = new MySqlConnection(cs);
            con.Open(); 

            //gonna change this to favorited 
            // string stm = @"Update Songs set songTitle = @song.SongTitle where songID = @Song.SongID";

            // using var cmd = new MySqlCommand (stm, con);
            // cmd.Parameters.AddWithValue("@song.SongID", song.SongID);
            // cmd.Parameters.AddWithValue("@song.SongTitle", song.SongTitle);

            // cmd.ExecuteNonQuery();
            // con.Close();
             string stm = @"Update Songs set favorited = 'yes' where songID = @Song.SongID";

            using var cmd = new MySqlCommand (stm, con);
            cmd.Parameters.AddWithValue("@song.SongID", song.SongID);
            cmd.Parameters.AddWithValue("@song.SongTitle", song.SongTitle);

            cmd.ExecuteNonQuery();
            con.Close();
        }

        internal void Update(int songID)
        {
            throw new NotImplementedException();
        }

        // internal void Update(string songTitle)
        // {
        //     throw new NotImplementedException();
        // }
    }
}