using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Carepoint.Custom_Helpers
{
    public class BendoHtml
    {
        public static IHtmlString Checkbox(string isChecked)
        {
            TagBuilder div = new TagBuilder("div");
            div.MergeAttribute("data-bendo-checked", isChecked);
            return new HtmlString(div.ToString());
            //return String.Format(@"<div data-bendo-checked='{0}'></div>", isChecked);
        }

        public static IHtmlString Checkbox(string isChecked, int dataItemId)
        {
            string id = dataItemId.ToString();
            TagBuilder div = new TagBuilder("div");
            div.MergeAttribute("data-bendo-checked", isChecked);
            div.MergeAttribute("data-bendo-dataId", dataItemId.ToString());
            return new HtmlString(div.ToString());
        }
    }
}