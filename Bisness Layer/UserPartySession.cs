using Business_Layer;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bisness_Layer
{
    public class UserPartySession
    {
        [ForeignKey("User")]
        public int UserId { get; set; }
        [ForeignKey("PartySession")]
        public int PartySessionId { get; set; }
        [NotNull]
        public User User { get; set; }
        [NotNull]
        public PartySession PartySession { get; set; }
        public UserPartySession(User user,PartySession partySession)
        {
            PartySession=partySession;
            User = user;
        }
        public UserPartySession()
        {
       
        }
    }
}
