using FluentValidation;
using PocMvcAppWithFluentValidation.DataAccess;

namespace PocMvcAppWithFluentValidation.Models.Todo;

public class AddTodoModelValidator : AbstractValidator<AddTodoModel>
{

    public AddTodoModelValidator(
        ITodoRepository todoRepository)
    {
        RuleFor(m => m.Title)
            .MinimumLength(5)
            .NotEmpty();

        RuleFor(m => m.Description)
            .MaximumLength(100)
            .NotEmpty();

        RuleFor(m => m.Title)
            .MustAsync(async (value, cancellationToken) =>
            {
                return await todoRepository
                    .GetByTitleAsync(value) == null;
            })
            .WithMessage("'Title' is already in use");
    }

}