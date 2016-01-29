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
        public void Send(String UserId, String Message)
        {
            var UserId2 = Context.User.Identity.GetUserId();
            var Username = Context.User.Identity.Name;

            var obj = new UserViewModel()
            {
                UserId = UserId2,
                Message = Message,
                Name = Username
            };

            Clients.User(UserId).addNewMessageToPage(obj);
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