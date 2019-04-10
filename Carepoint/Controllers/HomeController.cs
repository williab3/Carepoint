using Carepoint.Models;
using Carepoint.ViewModel;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Carepoint.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext dbContext;

        public HomeController()
        {
            dbContext = new ApplicationDbContext();
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";
            var data = Request.Params["workout"] ?? String.Empty;

            return View();
        }

        [ChildActionOnly]
        public PartialViewResult _LoginPartial()
        {
            if (Request.IsAuthenticated)
            {
                UserManager<ApplicationUser> testManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext()));
                var currentUser = testManager.FindById(User.Identity.GetUserId());
                if (currentUser != null)
                {
                    ViewModelBase userModel = new ViewModelBase()
                    {
                        CurrentFirstName = currentUser.FirstName,
                        UserName = currentUser.UserName,
                        LastName = currentUser.LastName,
                        CarePointName = currentUser.CarePointName,
                        UserId = currentUser.Id
                    };
                    return PartialView("_LoginPartial", userModel);

                }
                else
                {
                    return PartialView();
                }
            }
            else
            {
                return PartialView();
            }
        }

        //TODO: Figure out how to restrict access to these actions
        //[ChildActionOnly]<-- Can't do this because of the way the action is called
        public ActionResult MyPasbaApps()
        {
            AppsViewModel viewModel = new AppsViewModel();
            viewModel.Apps = dbContext.PasbaApps.Where(a => a.IsFavorite == true);

            return PartialView("_MyAppsPartial",viewModel);
        }

        public ActionResult AllPasbaApps()
        {
            AppsViewModel viewModel = new AppsViewModel();
            viewModel.Apps = dbContext.PasbaApps.ToList();
            return PartialView(viewModel);
        }

        [HttpPost]
        public ActionResult SetFavoriteApp(PasbaApp app)
        {
            PasbaApp pasbaApp = dbContext.PasbaApps.FirstOrDefault(a => a.Id == app.Id);
            pasbaApp.IsFavorite = app.IsFavorite;
            dbContext.SaveChanges();
            return Content("Saved dude!!");
        }

        [ChildActionOnly]
        public ActionResult _InstantMessanger()
        {
            List<Friend> friends = new List<Friend>();
            foreach (ApplicationUser user in dbContext.Users)
            {
                Friend friend = new Friend()
                {
                    Id = user.Id,
                    FirstName = user.FirstName,
                    UserId = user.UserName
                };
                friends.Add(friend);
            }
            friends = friends.Where(f => f.Id != this.User.Identity.GetUserId()).ToList();
            return PartialView(friends);
        }
    }
}