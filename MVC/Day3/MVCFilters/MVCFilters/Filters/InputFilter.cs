using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace MVCFilters.Filters
{
    public class InputFilter : ActionFilterAttribute
    {

        // BEFORE Action Executes
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            // Example: Validate input parameters
            foreach (var param in context.ActionArguments)
            {
                if (param.Value == null)
                {
                    context.Result = new BadRequestObjectResult("Input parameter cannot be null");
                    return;
                }
            }

            base.OnActionExecuting(context);
        }


        // AFTER Action Executes
        public override void OnActionExecuted(ActionExecutedContext context)
        {
            base.OnActionExecuted(context);
        }

    }
}