using FluentValidation;

namespace PocMvcAppWithFluentValidation.Models;

public class AddTodoModelValidator : AbstractValidator<AddTodoModel>
{

    public AddTodoModelValidator()
    {
        RuleFor(m => m.Title)
            .MinimumLength(10)
            .NotEmpty();

        RuleFor(m => m.Description)
            .NotEmpty();

        RuleFor(m => m.Title)
            .MustAsync(async (value, cancellationToken) =>
            {
                await Task.Delay(100, cancellationToken);
                return true;
            });
    }

}