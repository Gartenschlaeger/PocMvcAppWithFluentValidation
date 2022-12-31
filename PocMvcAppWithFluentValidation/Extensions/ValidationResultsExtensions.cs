using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace PocMvcAppWithFluentValidation.Extensions;

public static class ValidationResultsExtensions
{

    public static void AddToModelState(this ValidationResult validationResult,
        ModelStateDictionary modelState)
    {
        foreach (var error in validationResult.Errors)
        {
            modelState.AddModelError(error.PropertyName, error.ErrorMessage);
        }
    }

}