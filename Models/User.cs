using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using test.Models;

namespace test.Models
{
    public class User : BaseEntity
    {
        [Key]
        public int UsersId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public double WalletAmount { get; set; }
        public string Password { get; set; }
        public DateTime CreatedAt { get; set;}
        public DateTime UpdatedAt { get;set;}
        public List<Bid> bids { get; set; }
 
        public User()
        {
            bids = new List<Bid>();
        
        }
    }
}
    