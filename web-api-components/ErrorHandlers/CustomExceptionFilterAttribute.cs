using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http.Filters;

namespace web_api_components.ErrorHandlers
{
    public class CustomExceptionFilterAttribute : Attribute, IExceptionFilter
    {
        public Task ExecuteExceptionFilterAsync(
            HttpActionExecutedContext actionExecutedContext,
            CancellationToken cancellationToken)
        {
            if (actionExecutedContext.Exception != null)
            {
                actionExecutedContext.Response = actionExecutedContext.Request.CreateErrorResponse(
                HttpStatusCode.BadRequest, "Error appears. Pls change request and try again");
            }
            return Task.FromResult<object>(null);
        }

        public bool AllowMultiple
        {
            get { return true; }
        }
    }
}