using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleObjectValidation.Filters
{
    [AttributeUsage(AttributeTargets.Method)]
    public sealed class ValidateModelStateAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            // First, check all action arguments and make sure they aren't null
            foreach (var argument in context.ActionArguments)
            {
                if (argument.Value == null)
                {
                    context.ModelState.AddModelError(argument.Key, $"{argument.Key} cannot be null");
                }
            }

            // Now we check if the model stat is valid. The IsValid property
            // Checks to see if any erros have been added to the ModelState
            // Since we add an error if any action arguments are null, this
            // Would be true if we found any. It will also be true if the
            // Supplied model to the controller failed validation from data
            // Annotations.
            if (!context.ModelState.IsValid)
            {
                context.Result = new BadRequestObjectResult(context.ModelState);
            }
        }
    }
}
