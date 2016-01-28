using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.Identity;

namespace SirnalRUserId.Hubs
{
    public class ChatHub : Hub
    {
        public void Send(String UserId, String Message)
        {            
            Clients.User(UserId).addNewMessageToPage(UserId, Message);
        }
    }
}