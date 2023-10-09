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
        public string Phone { get; set; }

        //[Required]
        //[CreditCard]
        //public string CreditCard { get; set; } //dali trqbva da e string?        
        [ForeignKey("PartySession")]
        public int PartySessionID { get; set; }

        public PartySession PartySession { get; set; }
        private DJ()
        {
            
            
        }
        public DJ(int id,string nickname,string password, string email, string phone,PartySession partySession)
        {
            Id= id;
            Nickname = nickname;
            Password = password;
            Email = email;
            Phone = phone;
            PartySession = partySession;
        }

    }
}
