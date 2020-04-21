
using System.Web.Mvc;

namespace Online_Logistics_Registration.App_Start
{
    public class FilterConfig
    {
        public static void GlobalFilters(GlobalFilterCollection globalFilter)
        {
            globalFilter.Add(new HandleErrorAttribute());
        }
    }
}