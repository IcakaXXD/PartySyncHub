using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bisness_Layer
{
    public class Member
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(50, ErrorMessage = "Name cannot be more than 50 symbols!")]
        public string Nickname { get; set; }

        [Required]
        [MaxLength(50, ErrorMessage = "Password cannot be more than 50 symbols!")]
        public string Password { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        [Phone]
        public string Phone { get; set; }//= string.Empty;

        List<Song> LikedSongs { get; set; } //tuka sushtoto neshto

        List<Song> AcceptedSongs { get; set; }

        //[Required]
        //[CreditCard]
        //public string CreditCard { get; set; }

        private Member()
        {
            LikedSongs = new List<Song>();
            AcceptedSongs = new List<Song>();
        }
        public Member(int id, string name, string password, string email, string phone)
        {
            Id = id;
            Nickname = name;
            Password = password;
            Email = email;
            Phone = phone;
            LikedSongs = new List<Song>();
            AcceptedSongs= new List<Song>();
        }
    }
}
