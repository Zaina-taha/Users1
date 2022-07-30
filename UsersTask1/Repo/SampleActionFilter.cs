using Microsoft.AspNetCore.Mvc.Filters;
using System.Web.Http.Filters;

namespace UsersTask1.Repo
{
    public class SampleActionFilter : Microsoft.AspNetCore.Mvc.Filters.IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext context)
        {


            var parm = context.HttpContext.Request.Headers["Admin"].ToString();
            
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            // Do something after the action executes.
        }
    }
}
