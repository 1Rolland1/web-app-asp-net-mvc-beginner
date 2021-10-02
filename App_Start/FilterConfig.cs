using System.Web;
using System.Web.Mvc;

namespace laba1_Raspisanie_zanyatiy_
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
