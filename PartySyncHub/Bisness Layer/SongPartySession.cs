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
    public class SongPartySession
    {
        [ForeignKey("Song")]
        public int SongId { get; set; }
        [ForeignKey("PartySession")]
        public  int PartySessionId { get; set; }
        [NotNull]
        public Song Song { get; set; }
        [NotNull]
        public PartySession PartySession { get; set; }
        public SongPartySession(Song song,PartySession partySession)
        {
            PartySession = partySession;
            Song = song;
        }
    }
}
