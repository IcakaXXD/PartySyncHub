using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bisness_Layer
{
    public class Song
    {
        [Key] 
        public int Id { get; set; }

        [Required]
        //[MaxLength(100, ErrorMessage = "Name cannot be more than 100 symbols!")]
        public string Name { get; set; }

        //[MaxLength(50, ErrorMessage = "Singer cannot be more than 50 symbols!")]
        public string Singer { get; set; }

        //[MaxLength(1000, ErrorMessage = "Description cannot be more than 1000 symbols!")]
        public string Description { get; set; }

        public int Likes { get; set; }

        public List<Song> AcceptedSongs { get; set; }

        public List<Song> NotApprovedSongs { get; set; }

        public List<Song> LikedSongs { get; set; }

        [ForeignKey("DJ")]
        public int DJId { get; set; }

        public DJ DJ { get; set; }

        [ForeignKey("Member")]
        public int MemberId { get; set; }

        public Member Member { get; set; }

        private Song()
        {
            AcceptedSongs = new List<Song>();
            NotApprovedSongs = new List<Song>();
            LikedSongs = new List<Song>();
        }
        public Song(int id, string name, string singer, string description, int likes,DJ dj, Member member)
        {
            id = this.Id;
            name = this.Name;
            singer = this.Singer;
            description = this.Description;
            likes = this.Likes;
            dj = DJ;
            AcceptedSongs = new List<Song>();
            NotApprovedSongs = new List<Song>();
            LikedSongs = new List<Song>();
            Member = member;
        }
    }
}