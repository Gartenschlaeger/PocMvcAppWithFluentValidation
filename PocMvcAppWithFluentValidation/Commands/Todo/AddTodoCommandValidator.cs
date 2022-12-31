using FluentValidation;

namespace PocMvcAppWithFluentValidation.Commands.Todo;

public class AddTodoCommandValidator : AbstractValidator<AddTodoCommand>
{

    public AddTodoCommandValidator()
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