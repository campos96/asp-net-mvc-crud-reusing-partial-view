using System.Web;
using System.Web.Mvc;

namespace asp_net_mvc_crud_reusing_partial_view
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
