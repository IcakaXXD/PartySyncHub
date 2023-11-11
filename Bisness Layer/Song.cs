using Bisness_Layer;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Business_Layer
{
    public class Song
    {
        [Key] 
        public int Id { get; set; }

        [Required]
        [MaxLength(100, ErrorMessage = "Name cannot be more than 100 symbols!")]
        public string Name { get; set; }

        [MaxLength(50, ErrorMessage = "Singer cannot be more than 50 symbols!")]
        public string Singer { get; set; }

        [MaxLength(1000, ErrorMessage = "Description cannot be more than 1000 symbols!")]
        public string Description { get; set; }
        public int LikesCount { get; set; } = 0;

        //[ForeignKey("PartySession")]
        //public int PartySessionID { get; set; }
        //public PartySession PartySession { get; set; }
        public List<PartySession> PartySessions { get; set; }
        public List<SongPartySession> SongPartySessions { get; set; }
        private Song()
        {
            PartySessions = new List<PartySession>();
            SongPartySessions = new List<SongPartySession>();
        }
        public Song(int id, string name, string singer, string description, int likes)/*,PartySession partySession)*/
        {
            id = this.Id;
            name = this.Name;
            singer = this.Singer;
            description = this.Description;
            likes = this.LikesCount;
            SongPartySessions = new List<SongPartySession>();
            PartySessions = new List<PartySession>();

        }
    }
}