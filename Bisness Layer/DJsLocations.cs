using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bisness_Layer
{
    public class DJsLocations
    {
        [ForeignKey("Location")]
        public int LocationId { get; set; }
        [ForeignKey("DJ")]
        public int DJId { get; set; }
        public Location Location { get; set; }
        public DJ DJ { get; set; }
        private DJsLocations()
        {
            
        }
        public DJsLocations(int locationId,int djId)
        {
            LocationId = locationId;
            DJId = djId;
        }
    }
}
