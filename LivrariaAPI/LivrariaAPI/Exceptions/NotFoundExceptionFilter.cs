
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace LivrariaAPI.Exceptions
{
    public class NotFoundExceptionFilter: ExceptionFilterAttribute
    {
        
        public override void OnException(ExceptionContext context)
        {
            if (context.Exception is NotFoundException)
            {
                context.Result = new NotFoundResult();
            }
        }
    }
}
