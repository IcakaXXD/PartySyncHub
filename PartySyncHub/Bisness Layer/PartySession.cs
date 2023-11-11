using Bisness_Layer;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Layer
{
    public class PartySession
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Admin")]
        public int AdminId { get; set; }              
        [ForeignKey("Location")]
        public int LocationId { get; set; }
        public List<User> Users { get; set; }
        public List<Song> NotAprovedSongs { get; set; }
        public List<Song> AcceptedSongs { get; set; }     
        public Admin Admin { get; set; }
        public Location Location { get; set; }
        public List<UserPartySession> UserPartySessions { get; set; }
        public List<SongPartySession> SongPartySessions { get; set; }
        private PartySession()
        {
            NotAprovedSongs = new List<Song>();
            AcceptedSongs = new List<Song>();
            UserPartySessions = new List<UserPartySession>();
            SongPartySessions = new List<SongPartySession>();
            Users = new List<User>();
            
        }
        public PartySession(int id,Admin admin,Location location)
        {
            id = Id;
            admin = Admin;
            location = Location;
            NotAprovedSongs = new List<Song>();
            AcceptedSongs = new List<Song>();
            UserPartySessions = new List<UserPartySession>();
            SongPartySessions = new List<SongPartySession>();
            Users = new List<User>();
        }
    }
}
