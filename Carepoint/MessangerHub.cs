using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Carepoint.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.SignalR;
using System.Data.Entity;
using System.Threading.Tasks;

namespace Carepoint
{
    public class MessangerHub : Hub
    {
        public ApplicationDbContext DbContext { get; set; } = new ApplicationDbContext();
        public void Send(string userId, string message)
        {
            IdentityUser  _user = DbContext.Users.SingleOrDefault(u => u.Id == userId);
            Clients.User(_user.UserName).send(message);
            //Clients.All.broadcastMessage(userId, message);
            Clients.User(_user.UserName).broadcastMessage(userId, message);
        }

        public override Task OnConnected()
        {
            
            string userName = Context.User.Identity.Name;
            var user = DbContext.Users.Include(c => c.UserConnections).SingleOrDefault(u => u.UserName == userName);
            if (user != null)
            {
                MessegeConnection connection = new MessegeConnection()
                {
                    ConnectionId = Context.ConnectionId,
                    UserId = user.Id,
                    IsConnectionActive = true
                };
                user.UserConnections.Add(connection);
                DbContext.SaveChanges(); 
            }

            return base.OnConnected();
        }

        public override Task OnDisconnected(bool stopCalled)
        {
            MessegeConnection disconnect = DbContext.MessegeConnections.SingleOrDefault(c => c.ConnectionId == Context.ConnectionId);
            DbContext.MessegeConnections.Remove(disconnect);
            DbContext.SaveChanges();
            return base.OnDisconnected(stopCalled);
        }
    }
}