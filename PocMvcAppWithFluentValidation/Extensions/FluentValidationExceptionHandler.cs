using FluentValidation;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace PocMvcAppWithFluentValidation.Extensions;

public static class FluentValidationExceptionHandler
{

    public static void UseFluentValidationExceptionHandler(this IApplicationBuilder app)
    {
        app.UseExceptionHandler(builder =>
        {
            builder.Run(async context =>
            {
                var errorFeature = context.Features.Get<IExceptionHandlerFeature>();
                var routingFeature = context.Features.Get<IRoutingFeature>();

                var exception = errorFeature.Error;

                if (exception is ValidationException validationException)
                {
                    var errors = validationException.Errors
                        .Select(err => new
                        {
                            err.PropertyName,
                            err.ErrorMessage
                        });

                    var controller = routingFeature.RouteData.Values["controller"] as ControllerBase;
                    var modelState = controller.ModelState;

                    foreach (var error in errors)
                    {
                        modelState.AddModelError(
                            error.PropertyName,
                            error.ErrorMessage);
                    }
                }
            });
        });
    }

}