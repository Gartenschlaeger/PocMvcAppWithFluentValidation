using FluentValidation;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace PocMvcAppWithFluentValidation.Filters;

public class ValidationActionFilter : ActionFilterAttribute
{

    private readonly IServiceProvider _serviceProvider;

    public ValidationActionFilter(
        IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public override void OnActionExecuting(ActionExecutingContext context)
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

            var validationResult = item.Validator.Validate(validationContext);
            if (!validationResult.IsValid)
            {
                AddErrors(validationResult, context.ModelState);
            }
        }
    }

    private void AddErrors(
        FluentValidation.Results.ValidationResult validationResult,
        ModelStateDictionary modelState)
    {
        foreach (var error in validationResult.Errors)
        {
            modelState.AddModelError(error.PropertyName, error.ErrorMessage);
        }
    }

}