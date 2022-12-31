using FluentValidation;
using Microsoft.AspNetCore.Mvc.Filters;
using PocMvcAppWithFluentValidation.Extensions;

namespace PocMvcAppWithFluentValidation.Filters;

public class ValidationActionAsyncFilter : ActionFilterAttribute
{

    private readonly IServiceProvider _serviceProvider;

    public ValidationActionAsyncFilter(
        IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public override async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
        var validator = context.ActionArguments.Values
            .Where(x => x != null)
            .Select(x =>
            {
                var valueType = x.GetType();
                var validatorType = typeof(IValidator<>);
                validatorType = validatorType.MakeGenericType(valueType);

                var validator = _serviceProvider.GetService(validatorType);
                var validatorCorrectType = (IValidator) validator;

                return new
                {
                    Value = x,
                    Validator = validatorCorrectType
                };
            })
            .Where(x => x.Validator != null)
            .ToArray();

        foreach (var item in validator)
        {
            var validationContext = new ValidationContext<object>(item.Value);

            var validationResult = await item.Validator.ValidateAsync(validationContext);
            if (validationResult != null && !validationResult.IsValid)
            {
                validationResult.AddToModelState(context.ModelState);
            }
        }

        await base.OnActionExecutionAsync(context, next);
    }

}