using CollegeManagementApi.Services;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace CollegeManagementApi.Filter
{
    public class LogNormalActionFilter : ActionFilterAttribute
    {
        private readonly IMyLogger _myLogger;

        public LogNormalActionFilter(IMyLogger myLogger)
        {
            this._myLogger = myLogger;
        }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            string basicLogInfo = GetBasicLogInfo(filterContext);
            string message = basicLogInfo + " OnActionExecuting";
            _myLogger.log(message);
        }
        private string GetBasicLogInfo(FilterContext filterContext)
        {
            string timestamp = DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss.fff", CultureInfo.InvariantCulture);
            string actionName = filterContext.ActionDescriptor.RouteValues["action"];
            string controllerName = filterContext.ActionDescriptor.RouteValues["controller"];

            string message = $"{timestamp} : {controllerName} {actionName}";
            return message;
        }

        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            string basicLogInfo = GetBasicLogInfo(filterContext);
            string message = basicLogInfo + " OnActionExecuted";
            _myLogger.log(message);
        }

        public override void OnResultExecuted(ResultExecutedContext filterContext)
        {
            string basicLogInfo = GetBasicLogInfo(filterContext);
            string message = basicLogInfo + "event fired: OnResultExecuted";
            _myLogger.log(message);
        }
    }
}
