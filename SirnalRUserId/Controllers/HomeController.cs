using Microsoft.AspNet.SignalR;
using SirnalRUserId.Hubs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;

namespace SirnalRUserId.Controllers
{
    public class HomeController : Controller
    {
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
            var context = GlobalHost.ConnectionManager.GetHubContext<ChatHub>();
            var userId = User.Identity.GetUserId();

            if (context != null)
                context.Clients.User(userId).addNewMessageToPage(userId, "Poruka");

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}