using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using test.Models;
using System.Linq;

namespace test.Controllers
{
    public class UserController : Controller
    {
        private testContext _context;
 
        public UserController(testContext context)
        {
            _context = context;
        }
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [Route("register")]
        public IActionResult Register(RegisterViewModel model)
        {
            if(ModelState.IsValid){
                User NewUser = new User
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    UserName = model.UserName,
                    WalletAmount = 1000,
                    Password = model.Password,
                   
                };
 
                System.Console.WriteLine("Came here");
                _context.Add(NewUser);
                _context.SaveChanges();
                System.Console.WriteLine("Done adding to DB");
                User EnteredPerson = _context.users.SingleOrDefault(user => user.UserName == model.UserName);
                HttpContext.Session.SetString("UserName", EnteredPerson.UserName);
                HttpContext.Session.SetInt32("UserId",EnteredPerson.UsersId);
                return RedirectToAction("show","Auction");
            }
            else 
            {
                // ViewBag.errors = ModelState.Values;
                //  ViewBag.errors = new List<string>();
                return View("Index");
            }
        }
        [HttpPost]
        [Route("PostLogin")]
        public IActionResult PostLogin(string UserName, string Password)
        {
            
             User loggedUser = _context.users.SingleOrDefault(user => user.UserName == UserName && user.Password == Password);
             if (loggedUser != null)
             {
                HttpContext.Session.SetString("UserName", loggedUser.UserName);
                HttpContext.Session.SetInt32("UserId", loggedUser.UsersId);
                return RedirectToAction("show","Auction");
             }

               ViewBag.Errors = new List<string>(){ "Check Username and password"};
                return View("Index");
        }
        [HttpGet]
        [Route("logout")]
        public IActionResult Logout(){
            HttpContext.Session.Clear();
            return RedirectToAction("Index");
        }
       
    }
}

