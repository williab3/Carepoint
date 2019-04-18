using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Carepoint.Models
{
    public class MessegeConnection
    {
        public int Id { get; set; }
        public string ConnectionId { get; set; }
        public string UserId { get; set; }
        public bool IsConnectionActive { get; set; }
        public string UserName { get; set; }
        public DateTime ConnectionTime { get; set; }
    }
}