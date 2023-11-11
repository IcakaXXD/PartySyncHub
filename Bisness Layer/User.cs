using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bisness_Layer;

namespace Business_Layer
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(50, ErrorMessage = "Name cannot be more than 50 symbols!")]
        public string Nickname { get; set; }

        [Required]
        [MaxLength(50, ErrorMessage = "Password cannot be more than 50 symbols!")]
        public string Password { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Phone]
        public string Phone { get; set; }

        //[ForeignKey("PartySession")]
        //public int PartySessionId { get; set; }

        //public PartySession PartySession { get; set; }

        public List<PartySession> PartySessions { get; set; }
        public List<UserPartySession> UserPartySessions { get; set; }
        public User(int id, string nickname, string password, string email, string phone)//,PartySession partySession)
        {
            Id = id;
            Nickname = nickname;
            Password = password;
            Email = email;
            Phone = phone;
            //PartySession = partySession;
            PartySessions = new List<PartySession>();
            UserPartySessions = new List<UserPartySession>();
        }
        public User()
        {
            PartySessions = new List<PartySession>();
            UserPartySessions = new List<UserPartySession>();
        }
    }
}
