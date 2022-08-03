using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace UsersTask1.Extensions
{
    public class XSampleActionFilter : Attribute,IActionFilter
    {
        public string Role;
        public XSampleActionFilter()
        {
            Role= "Admin";
        }


        public void OnActionExecuting(ActionExecutingContext context)
        {


            var parm = context.HttpContext.Request.Headers["Role"].ToString();
            if (parm == "Admin")
            {
                return;
            }

            else
                context.Result = new BadRequestObjectResult("Not autherized");

            return;


        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            // Do something after the action executes.
        }
    }
}
