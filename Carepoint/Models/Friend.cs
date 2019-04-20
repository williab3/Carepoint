using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Carepoint.Models
{
    public class Friend
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string UserId { get; set; }
        public bool HasMesseges { get; set; }
        public List<InstantMessage> InstantMessages { get; set; }



        public Friend(string friendId)
        {
            ApplicationDbContext dbContext = new ApplicationDbContext();
            Friend friend = dbContext.Friends.Include(f => f.InstantMessages).SingleOrDefault(f => f.Id == friendId);
            Id = friend.Id;
            FirstName = friend.FirstName;
            UserId = friend.UserId;
            InstantMessages = friend.InstantMessages;
        }
        public Friend()
        {

        }
    }
}