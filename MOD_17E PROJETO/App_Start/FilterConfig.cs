using System.Web;
using System.Web.Mvc;

namespace MOD_17E_PROJETO
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
