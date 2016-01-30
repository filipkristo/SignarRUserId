using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.Identity;
using System.Threading.Tasks;
using SirnalRUserId.Models;

namespace SirnalRUserId.Hubs
{
    [Authorize()]
    public class ChatHub : Hub
    {
        // Ako želimo spremati trenutne sesije imamo ovdje dva primjera (in-memory i permental(external) storage)  
        //http://www.asp.net/signalr/overview/guide-to-the-api/mapping-users-to-connections        
        public void Send(String who, String Message)
        {
            var UserId = Context.User.Identity.GetUserId();
            var Username = Context.User.Identity.Name;

            var obj = new UserViewModel()
            {
                UserId = UserId,
                Message = Message,
                Name = Username,                
            };

            Clients.User(who).addNewMessageToPage(obj);
        }

        public override Task OnConnected()
        {
            return Clients.All.joined(GetAuthInfo());
        }

        protected object GetAuthInfo()
        {
            var user = Context.User;
            return new
            {
                IsAuthenticated = user.Identity.IsAuthenticated,
                IsAdmin = user.IsInRole("Admin"),
                UserName = user.Identity.Name
            };
        }

    }
}