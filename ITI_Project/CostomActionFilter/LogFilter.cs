using Microsoft.AspNetCore.Mvc.Filters;
using System.Diagnostics;

namespace ITI_Project.CostomActionFilter
{
    public class LogFilter : ActionFilterAttribute
    {
        Stopwatch sp = new Stopwatch();
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            sp.Start();
            Debug.WriteLine("Action Method Executing");
            base.OnActionExecuting(context);
        }
        public override void OnActionExecuted(ActionExecutedContext context)
        {
            sp.Stop();
            Debug.WriteLine("Action Method Executed in " + sp.ElapsedMilliseconds + "ms");
            base.OnActionExecuted(context);
        }
    }
}
