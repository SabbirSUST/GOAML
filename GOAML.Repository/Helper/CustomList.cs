using System.Collections.Generic;
using System.Web.Mvc;
using GOAML.Repository.CustomStatic;

namespace GOAML.Repository.Helper
{
    public class CustomList
    {
        public static SelectList GetMonths()
        {
            var values = new List<SelectListItem>
            {
                new SelectListItem {Value = "1-"+System128.GetCurrentDateTimeForOnlineServer().Year, Text = "January-"+System128.GetCurrentDateTimeForOnlineServer().Year},
                new SelectListItem {Value = "2-"+System128.GetCurrentDateTimeForOnlineServer().Year, Text = "February-"+System128.GetCurrentDateTimeForOnlineServer().Year},
                new SelectListItem {Value = "3-"+System128.GetCurrentDateTimeForOnlineServer().Year , Text = "March-"+System128.GetCurrentDateTimeForOnlineServer().Year},
                new SelectListItem {Value = "4-"+System128.GetCurrentDateTimeForOnlineServer().Year, Text = "April-"+System128.GetCurrentDateTimeForOnlineServer().Year},
                new SelectListItem {Value = "5-"+System128.GetCurrentDateTimeForOnlineServer().Year, Text = "May-"+System128.GetCurrentDateTimeForOnlineServer().Year},
                new SelectListItem {Value = "6-"+System128.GetCurrentDateTimeForOnlineServer().Year, Text = "June-"+System128.GetCurrentDateTimeForOnlineServer().Year},
                new SelectListItem {Value = "7-"+System128.GetCurrentDateTimeForOnlineServer().Year, Text = "July-"+System128.GetCurrentDateTimeForOnlineServer().Year},
                new SelectListItem {Value ="8-"+System128.GetCurrentDateTimeForOnlineServer().Year , Text = "August-"+System128.GetCurrentDateTimeForOnlineServer().Year},
                new SelectListItem {Value = "9-"+System128.GetCurrentDateTimeForOnlineServer().Year, Text = "September-"+System128.GetCurrentDateTimeForOnlineServer().Year},
                new SelectListItem {Value = "10-"+System128.GetCurrentDateTimeForOnlineServer().Year, Text = "October-"+System128.GetCurrentDateTimeForOnlineServer().Year},
                new SelectListItem {Value = "11-"+System128.GetCurrentDateTimeForOnlineServer().Year, Text = "November-"+System128.GetCurrentDateTimeForOnlineServer().Year},
                new SelectListItem {Value = "12-"+System128.GetCurrentDateTimeForOnlineServer().Year, Text = "December-"+System128.GetCurrentDateTimeForOnlineServer().Year}
            };
            return new SelectList(values, "Value", "Text");
        }
    }
}
