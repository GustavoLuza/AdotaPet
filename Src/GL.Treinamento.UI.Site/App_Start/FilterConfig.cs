using GL.Treinamento.Infra.CrossCutting.MvcFilters;
using System.Web;
using System.Web.Mvc;

namespace GL.Treinamento.UI.Site
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new GlobalErrorHandler());
        }
    }
}
