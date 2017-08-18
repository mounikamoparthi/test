using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using test.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;


namespace test.Controllers
{
    public class AuctionController : Controller
    {
        private testContext _context;
 
        public AuctionController(testContext context)
        {
            _context = context;
        }
        [HttpGet]
        [Route("show")]
        public IActionResult show()
        {

            List<Auction> auction = _context.auctions
                                        .Include(a => a.bids)
                                        .Include(a => a.users)
                                        .OrderBy(a => a.EndDate)
                                        .ToList();
            ViewBag.auctions = auction;
            ViewBag.name = HttpContext.Session.GetString("UserName");
            ViewBag.UserId = HttpContext.Session.GetInt32("UserId");
            return View("show");
        }
        [HttpGet]
        [Route("/create")]
        public IActionResult create()
        {
            return View("Create");
        }
        [HttpPost]
        [Route("/Auctionform")]
        public IActionResult Auctionform(Auction NewAuction)
        {
            System.Console.WriteLine("adding newauction");
            if(ModelState.IsValid)
            {

            int? loggedUserId = HttpContext.Session.GetInt32("UserId");

            NewAuction.UsersId = (int)loggedUserId;
           
            if (NewAuction.EndDate > DateTime.Now ){
                NewAuction.CreatedAt = DateTime.Now;
            }
            if(NewAuction.StartingBid > 0 ){
                
                _context.Add(NewAuction);
                _context.SaveChanges();
                return RedirectToAction("show"); 
                }
            else{
                ViewBag.errors = "Date should be in future";
                ViewBag.status="Auctiondatefailure";
                return View("Create");
            }
        }
        else    
        {
            ViewBag.errors = ModelState.Values;
            ViewBag.status="Auctfail";
            return View("Create");
        }

    }
        [HttpGet]
        [Route("test/deleteauction/{auction_Id}")]
        public IActionResult deleteauction(int auction_Id)
        {
            Auction auctionrecord = _context.auctions.SingleOrDefault(a => a.AuctionsId == auction_Id);
            _context.auctions.Remove(auctionrecord);
            _context.SaveChanges();
            return RedirectToAction("show");
        }
        [HttpGet]
        [Route("test/addBids/{auctions_Id}")]
        public IActionResult addBids(int auctions_Id)
        {
             int? loggedUserId = HttpContext.Session.GetInt32("UserId");
             
            Auction auctionrecord= _context.auctions
                            .Include(a=>a.users)
                            .SingleOrDefault(a => a.AuctionsId==auctions_Id);
        
            ViewBag.auctionrecord = auctionrecord;
            return View("addBids");

    }

        [HttpPost]
        [Route("test/PostBids/{auctionid}")]
        public IActionResult PostBids(int auctionid,double Amount){
            System.Console.WriteLine("################", auctionid);
            ViewBag.errors = new List<String>();
            
            Auction auctionrec= _context.auctions
                            .Include(a=>a.users)
                            .SingleOrDefault(a => a.AuctionsId==auctionid);
                            ViewBag.auctionrec= auctionrec;
            
                Bid NewBid= new Bid{
                    Amount= Amount,   
                    AuctionsId=auctionrec.AuctionsId,
                    CreatedAt= DateTime.Now,
                    UpdatedAt=DateTime.Now,
                   
                };
                _context.bids.Add(NewBid);
                
                
                return RedirectToAction("show");
            }
           

            
        }
}
