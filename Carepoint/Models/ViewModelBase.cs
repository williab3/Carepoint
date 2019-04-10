using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Carepoint.Models
{
    public class ViewModelBase
    {
        public string CurrentFirstName { get; set; }
        public string UserName { get; set; }
        public string LastName { get; set; }
        public string CarePointName { get; set; }
        public string UserId { get; set; }
    }
}