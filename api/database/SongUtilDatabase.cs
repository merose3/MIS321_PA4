// using System.Collections.Generic;
// using api.models;
// using api.database;
// using MySql.Data.MySqlClient;
// using System;

// namespace api.database
// {
//     public class SongUtilDatabase
//     {
//         public List<Songs> playlist { get; set; }
//         SongUtil newUtil = new SongUtil();
//         UpdateSong updating = new UpdateSong();
//         ReadSong readin = new ReadSong();
//         CreateNewSong newSong = new CreateNewSong();
//         DeleteSong deleting = new DeleteSong();
//         public void AddSong()
//         {
//             System.Console.WriteLine("What is the title of your song?");
//             string songName = Console.ReadLine();

//             Song songs = new Song(){SongTitle = songName, SongTimestamp = DateTime.Now, Deleted = "n"}; //creates that new instance that will be used below 
            
//             newSong.Create(songs); //updates with the method written in the CreateNewSong class

//             PrintPlaylist();
            
//         }
//         public void DeleteSong()
//         {
//             PrintPlaylist(); //at the bottom reading in and filling the playlist to then write out to the user 
//             //PrintToUser();

//             System.Console.WriteLine("What is the ID of the song you want to delete?");
//             int songID = int.Parse(Console.ReadLine());

//             deleting.Delete(songID);

//             PrintPlaylist();
//         }
//         public void EditSong()
//         {
//             PrintPlaylist(); 
//             // PrintToUser();

//             System.Console.WriteLine("What is the ID of the song you would like to change?");
//             int songID = int.Parse(Console.ReadLine());
//             System.Console.WriteLine("What is the title you would like to change it to?");
//             string title = Console.ReadLine();

//             Song song = new Song(){SongTitle = title, SongID = songID, SongTimestamp = DateTime.Now, Deleted = "n"};
//             updating.Update(song); //this updaes it in the database because of the update method in the updatesong class with the connection and such 
//         }
//         public void PrintToUser()
//         {
//             playlist = readin.GetAll();
//         }
//         public void PrintPlaylist() { // display all items in the playlist to the console
//             Console.Clear();
//             playlist = readin.GetAll();
//             playlist.Sort();
//             foreach (Song song in playlist) { // for every song in the playlist, write the song's ToString to the console
//                 if(song.Deleted != "y"){
//                     Console.WriteLine(song.ToString());
//                 }
//             }
//             Console.WriteLine();
//         }
//     }
// }