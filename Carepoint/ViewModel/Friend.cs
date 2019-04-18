using Carepoint.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Carepoint.ViewModel
{
    public class Friend
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string UserId { get; set; }
        public bool HasMesseges { get; set; }
        public List<InstantMessage> InstantMessages { get; set; }



        public Friend( string friendId, string userId)
        {
            ApplicationDbContext dbContext = new ApplicationDbContext();
            ApplicationUser friend = dbContext.Users.SingleOrDefault(f => f.Id == friendId);
            Id = friend.Id;
            FirstName = friend.FirstName;
            UserId = friend.Email;
        }
        public Friend()
        {

        }
    }
}