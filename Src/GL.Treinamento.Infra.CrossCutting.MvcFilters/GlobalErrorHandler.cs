using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace GL.Treinamento.Infra.CrossCutting.MvcFilters
{
   public class GlobalErrorHandler : ActionFilterAttribute
                                     
    {
        public GlobalErrorHandler()
        {

        }

        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            if (filterContext.Exception !=null)
            {
                filterContext.Controller.TempData["ErrorCode"] = "000555";
            }

            base.OnActionExecuted(filterContext);
        }
    }
}
