using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Carepoint.Models;

namespace Carepoint.ViewModel
{
    public class AppsViewModel
    {
        public IEnumerable<PasbaApp> Apps { get; set; }
    }
}