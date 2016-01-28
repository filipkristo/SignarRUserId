using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.Identity;
using System.Threading.Tasks;

namespace SirnalRUserId.Hubs
{
    public class ChatHub : Hub
    {
        public void Send(String Message)
        {
            var UserId = this.Context.User.Identity.GetUserId();
            var Username = Context.User.Identity.Name;

            Clients.User(UserId).addNewMessageToPage(Username, Message);
        }

        //public override Task OnConnected()
        //{
        //    return Clients.All.joined(GetAuthInfo());
        //}

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