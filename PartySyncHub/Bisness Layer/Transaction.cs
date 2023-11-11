using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Layer
{
    public class Transaction
    {
        [Key]
        public int Id { get; set; }
        
        [Range(1, int.MaxValue)]
        public decimal Operation { get; set; }
        public List<Transaction> Transactions { get; set; } 
        public List<User> Users { get; set; }
        public Transaction(decimal Operation)
        {
            List<User> users = new List<User>();
            Transactions = new List<Transaction>();
        }
    }
}
