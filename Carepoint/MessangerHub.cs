using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;

namespace Carepoint
{
    public class MessangerHub : Hub
    {
        public void Hello()
        {
            Clients.All.hello();
        }
        public void Send(string userId, string message)
        {
            Clients.All.broadcastMessage(userId, message);
        }
    }
}