using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Carepoint.Models
{
    public class PasbaApp
    {
        public int Id { get; set; }
        public string PasbaAppName { get; set; }
        public string Icon { get; set; }
        public string AppPath { get; set; }
        public bool IsFavorite { get; set; }
        public bool IsRestricted { get; set; }
        public string Description { get; set; }
    }
}