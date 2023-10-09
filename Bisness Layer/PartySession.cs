using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bisness_Layer
{
    public class PartySession
    {
        [ForeignKey("Admin")]
        public int AdminId { get; set; }              
        [ForeignKey("Location")]
        public int LocationId { get; set; }
        public List<DJ> DJs { get; set; } //- за това не бях сигурен дали да бъде лист, но тъй като може да са двама DJ мисля, че така е по-добре😎😎
        public List<Member> Members { get; set; }
        public List<Song> NotAprovedSongs { get; set; }
        public List<Song> AcceptedSongs { get; set; }
        public Admin Admin { get; set; }
        public Location Location { get; set; }
        private PartySession()
        {
            NotAprovedSongs = new List<Song>();
            AcceptedSongs = new List<Song>();
            DJs = new List<DJ>();
            Members = new List<Member>();
        }
        public PartySession(Admin admin,Location location)
        {
            admin = Admin;
            location = Location;
            NotAprovedSongs = new List<Song>();
            AcceptedSongs = new List<Song>();
            DJs = new List<DJ>();
            Members = new List<Member>();
        }
    }
}
