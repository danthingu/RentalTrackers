using System.Web;
using System.Web.Mvc;

namespace RentalTrackers
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute()); // redirect user to error pages when action throws exception
            filters.Add(new AuthorizeAttribute());
        }
    }
}
