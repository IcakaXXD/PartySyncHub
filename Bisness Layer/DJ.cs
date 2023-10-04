using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bisness_Layer
{
    public class DJ
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
        public string Phone { get; set; }//= string.Empty;?? 


        //[Required]
        //[CreditCard]
        //public string CreditCard { get; set; } //dali trqbva da e string?

        //public List<Song> LikedSongs { get; set; } //ima li smisul ot tozi list tuk?
       
        public List<Song> NotAprovedSongs { get;set; } 
        //ne znam kak da svurja tiq dvata lista sus song🥲🥲 ili az sum prost i te sa svurzani 😀🔫

        public List<Song> AcceptedSongs { get; set; }

        private DJ()
        {
            //LikedSongs = new List<Song>();
            NotAprovedSongs = new List<Song>();
            AcceptedSongs = new List<Song>();
        }
        public DJ(int id,string nickname,string password, string email, string phone)
        {
            Id= id;
            Nickname = nickname;
            Password = password;
            Email = email;
            Phone = phone;
            NotAprovedSongs = new List<Song>();
            AcceptedSongs = new List<Song>();
            //LikedSongs= new List<Song>();
        }

    }
}
