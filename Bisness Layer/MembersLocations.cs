using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bisness_Layer
{
    public class MembersLocations
    {
        [ForeignKey("Location")]
        public int LocationId { get; set; }
        [ForeignKey("Memeber")]
        public int MemberId { get; set; }
        public Location Location { get; set; }
        public Member Member { get; set; }
        private MembersLocations()
        {
            
        }
        public MembersLocations(int locationId, int memeberId)
        {
            LocationId = locationId;
            MemberId = memeberId;
        }
    }
}
