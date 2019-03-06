using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Roldaice.Web.Helpers
{
    public class HandleErrorInfoLogged : HandleErrorInfo
    {
        public string Identifier { get; set; }
        public HandleErrorInfoLogged(Exception exception, string controllerName, string actionName, string identifier) : base(exception, controllerName, actionName)
        {
            Identifier = identifier;
        }
    }
}