using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bisness_Layer
{
    public class Location
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public DateTime Workig_time { get; set; }

        [ForeignKey("Admin")]
        public int AdminId { get; set; }

        public Admin Admin { get; set; }
        private Location()
        {
            
        }
        public Location(int id, string name, DateTime working_time,Admin admin)
        {           
            Id = id;
            Name = name;
            Workig_time=working_time;
            Admin = admin;
        }

    }
}
