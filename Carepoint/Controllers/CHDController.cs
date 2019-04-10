using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Carepoint.Controllers
{
    public class CHDController : Controller
    {
        // GET: CHD
        public ActionResult Index()
        {
            return PartialView();
        }

        public ActionResult Test()
        {
            return View();
        }

        public ActionResult SaveTest()
        {
            return View();
        }
    }
}