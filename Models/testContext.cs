using Microsoft.EntityFrameworkCore;

namespace test.Models
{
    public class testContext: DbContext
    {
        public testContext(DbContextOptions<testContext> options) : base(options) { }

        public DbSet<User> users {get;set;}

        public DbSet<Auction> auctions {get; set;}
        public DbSet<Bid> bids {get; set;}
    }

}