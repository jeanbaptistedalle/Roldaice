using Roldaice.Helpers.Helpers;
using Roldaice.Web.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Roldaice.Web.Attributes
{
    public class LogHandleErrorAttribute : HandleErrorAttribute
    {
        public override void OnException(ExceptionContext filterContext)
        {
            if (filterContext == null)
            {
                throw new ArgumentNullException("filterContext");
            }
            if (filterContext.IsChildAction)
            {
                return;
            }

            if (filterContext.ExceptionHandled || !filterContext.HttpContext.IsCustomErrorEnabled)
            {
                return;
            }

            Exception exception = filterContext.Exception;
            if (new HttpException(null, exception).GetHttpCode() != 500)
            {
                return;
            }

            if (!ExceptionType.IsInstanceOfType(exception))
            {
                return;
            }

            var guid = GuidHelper.GenerateGuid();
            var controllerName = (string)filterContext.RouteData.Values["controller"];
            var actionName = (string)filterContext.RouteData.Values["action"];
            var model = new HandleErrorInfoLogged(filterContext.Exception, controllerName, actionName, guid);

            filterContext.Result = new ViewResult
            {
                ViewName = View,
                MasterName = Master,
                ViewData = new ViewDataDictionary<HandleErrorInfoLogged>(model),
                TempData = filterContext.Controller.TempData
            };

            filterContext.ExceptionHandled = true;
            filterContext.HttpContext.Response.Clear();
            filterContext.HttpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            filterContext.HttpContext.Response.TrySkipIisCustomErrors = true;

            var logger = UnityConfig.GetLogger();
            logger.Error($"Identifiant de l'erreur : {guid}", filterContext.Exception);
        }
    }
}