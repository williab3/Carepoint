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



        public Friend( string userId)
        {
            ApplicationDbContext dbContext = new ApplicationDbContext();
        }
        public Friend()
        {

        }
    }
}