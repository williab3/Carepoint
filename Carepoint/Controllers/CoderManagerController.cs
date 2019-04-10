using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Carepoint.Controllers
{
    public class CoderManagerController : Controller
    {
        // GET: CoderManager
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CM()
        {
            return PartialView();
        }
    }
}