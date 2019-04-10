using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Carepoint
{
    public class AuthorizeOnlyAttribute : AuthorizeAttribute
    {
        public string View { get; set; }
        public string Master { get; set; }

        public AuthorizeOnlyAttribute()
        {
            View = "error";
            Master = String.Empty;
        }

        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            base.OnAuthorization(filterContext);
            AuthenticationCheck(filterContext);
        }

        private void AuthenticationCheck(AuthorizationContext filterContext)
        {
            if (filterContext.Result == null)
            {
                return;
            }
            if (filterContext.HttpContext.User.Identity.IsAuthenticated)
            {
                if (String.IsNullOrEmpty(View))
                {
                    return;
                }
                else
                {
                    ViewResult viewResult = new ViewResult()
                    {
                        ViewName = View,
                        MasterName = Master
                    };
                    filterContext.Result = viewResult;
                }
            }
        }
    }
}