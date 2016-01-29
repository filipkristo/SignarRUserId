using Microsoft.AspNet.SignalR;
using SirnalRUserId.Hubs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using SirnalRUserId.Models;
using Microsoft.AspNet.Identity.Owin;

namespace SirnalRUserId.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationUserManager _userManager;
        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        [System.Web.Mvc.Authorize]
        public ActionResult Chat()
        {
            var users = UserManager.Users.ToList();            

            var context = GlobalHost.ConnectionManager.GetHubContext<ChatHub>();
            var userName = User.Identity.Name;
            var userId = User.Identity.GetUserId();

            ViewBag.Users = new SelectList(users, users.Where(x => x.Id == userId).FirstOrDefault());

            if (context != null)
            {
                var obj = new UserViewModel()
                {
                    UserId = userId,
                    Message = "Poruka sa servera",
                    Name = userName
                };

                context.Clients.User(userId).addNewMessageToPage(obj);
            }
                

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}