using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using test.Models;

namespace test.Models
{
    public class Auction : BaseEntity
    {
        [Key]
        public int AuctionsId { get; set; }
        [Required]
        [MinLength(3, ErrorMessage ="Productname has to be 3 characters in length at least")]
        public string ProductName { get; set; }
        [Required]
        [MinLength(10, ErrorMessage ="Description has to be 10 characters in length at least")]
        public string Description { get; set; }
        public double StartingBid { get; set;}
        [FutureDate]
        public DateTime EndDate { get; set;}
        public int UsersId {get; set;}
        public User users {get; set;}

        public DateTime CreatedAt {get; set;}
        public DateTime UpdatedAt { get; set;}
        public List<Bid> bids { get; set; }
 
        public Auction()
        {
            bids = new List<Bid>();
        }
        
    }
}
    