using System;
namespace api.models
{
    public class Songs: IComparable<Songs>
    {
        //already added a favorited into the PA 4 songs C#
        // auto implemented properties
        public int SongID {get; set;}
        public string SongTitle {get; set;}
        public DateTime SongTimestamp {get; set;}
        public string Deleted { get; set; }
        public string Favorited {get; set;}

        public override string ToString() // overriding the ToString for the song class to include all properties of the class
        {
            return SongTitle + " (ID: " + SongID + ", Added " + SongTimestamp + ")";
        }

        public string ToFile(){
            return SongID + "#" + SongTitle + "#" + SongTimestamp + "#" + Deleted + "#" + Favorited;
        }

        public int CompareTo(Songs temp) { // since I am using IComparable, I need a CompareTo for "contract"
            return -this.SongTimestamp.CompareTo(temp.SongTimestamp); // negative sign allows the timestamps to be sorted in descending order
        }
    }
}
    