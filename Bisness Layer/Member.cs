using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Phone]
        public string Phone { get; set; }

        //[Required]
        //[CreditCard]
        //public string CreditCard { get; set; }
        [ForeignKey("PartySession")]
        public int PartySessionID { get; set; }
        public PartySession PartySession { get; set; }
        private Member()
        {
        
        }
        public Member(int id, string name, string password, string email, string phone,PartySession partySession)
        {
            Id = id;
            Nickname = name;
            Password = password;
            Email = email;
            Phone = phone;
            partySession = PartySession;
        }
    }
}
