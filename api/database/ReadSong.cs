using System.Collections.Generic;
using api.models;
using api.database;
using MySql.Data.MySqlClient;
using api.Interfaces;

namespace api.database
{
    public class ReadSong : IReadSong
    {
        public List<Songs> playlist { get; set; }
        // public Read()
        // {

        // }

        public void ReadSongTable()
        {
            connectionstring myConnection = new connectionstring();
            string cs = myConnection.cs;

            using var con = new MySqlConnection(cs);
            con.Open(); 

            string stm = @"Select * from songs where deleted = 'n'";
            //is not null

            using var cmd = new MySqlCommand (stm, con);

            cmd.ExecuteNonQuery();
            con.Close();
        }

        public List<Songs> GetAll()
        {
            List<Songs> songs = new List<Songs>();
            connectionstring myConnection = new connectionstring();
            string cs = myConnection.cs;

            using var con = new MySqlConnection(cs);
            con.Open();

            string stm = @"SELECT * from songs where deleted = 'n' ORDER BY SongTimestamp DESC";
            using var cmd = new MySqlCommand(stm, con);
            using MySqlDataReader rdr = cmd.ExecuteReader();
            while(rdr.Read())
            {
                //System.Console.WriteLine($"{rdr.GetInt32(0)} {rdr.GetString(1)} {rdr.GetDateTime(2)} {rdr.GetString(3)}");
                songs.Add(new Songs(){SongID = rdr.GetInt32(0), SongTitle = rdr.GetString(1), SongTimestamp = rdr.GetDateTime(2), Deleted = rdr.GetString(3), Favorited = rdr.GetString(4)});
                //System.Console.WriteLine($"ID: {rdr.GetValue(0).ToString()} | Title: {rdr.GetValue(1).ToString()} | SongTimestamp: {rdr.GetValue(2).ToString()} | Deleted: {rdr.GetValue(3).ToString()}");
            }
            return songs;

        }
        public void PrintPlaylist()
        {
            playlist = GetAll();
            foreach(Songs songs in playlist)
            {
                if(songs.Deleted == "n")
                {
                    System.Console.WriteLine(songs.ToString());
                }
            }
        }

        public Songs GetOne(int id)
        {
            throw new System.NotImplementedException();
        }
        // public Songs GetOne(int id)
        // {
        //     throw new NotImplementedException();
        // }
    }
}