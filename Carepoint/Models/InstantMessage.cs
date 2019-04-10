using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Carepoint.Models
{
    public class InstantMessage
    {
        public int Id { get; set; }
        public ApplicationUser Sender { get; set; }
        public ApplicationUser Recipient { get; set; }
        public DateTime TimeStamp { get; set; }
        public string Message { get; set; }
        public bool HasBeenRead { get; set; }
    }
}