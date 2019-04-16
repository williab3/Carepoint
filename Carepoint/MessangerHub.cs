using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Carepoint.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.SignalR;
using System.Data.Entity;

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
            ApplicationDbContext dbContext = new ApplicationDbContext();
            IdentityUser  _user = dbContext.Users.SingleOrDefault(u => u.Id == userId);
            Clients.User(_user.UserName).send(message);
            //Clients.All.broadcastMessage(userId, message);
            Clients.User(_user.UserName).broadcastMessage(userId, message);
        }
    }
}