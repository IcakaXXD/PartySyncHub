using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bisness_Layer
{
    public class Admin
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        [StringLength(100)]
        public string Password { get; set; }

        public List<Location> Locations { get; set; }


        private Admin()
        {
            Locations = new List<Location>();
        }
        public Admin(int id,string name, string password)
        {
            Id = id;
            Name = name;
            Password = password;
            Locations = new List<Location>();
        }
    }
}
