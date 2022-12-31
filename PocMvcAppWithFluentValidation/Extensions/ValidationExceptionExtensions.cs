using FluentValidation;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace PocMvcAppWithFluentValidation.Extensions;

public static class ValidationExceptionExtensions
{

    public static void AddToModelState(this ValidationException validationException,
        ModelStateDictionary modelState)
    {
        foreach (var error in validationException.Errors)
        {
            modelState.AddModelError(error.PropertyName, error.ErrorMessage);
        }
    }

}