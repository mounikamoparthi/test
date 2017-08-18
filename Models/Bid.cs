using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using test.Models;

namespace test.Models
{
    public class Bid : BaseEntity
    {
        [Key]
        public int BidsId { get; set; }
        public double Amount { get; set;}
 
        public int UsersId { get; set; }
        public User users { get; set; }
 
        public int AuctionsId { get; set; }
        public Auction auctions { get; set; }
        public DateTime CreatedAt {get; set;}
        public DateTime UpdatedAt {get; set;}
    }
}