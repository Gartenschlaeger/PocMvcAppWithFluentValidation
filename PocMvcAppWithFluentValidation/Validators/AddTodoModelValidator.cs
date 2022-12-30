using FluentValidation;
using PocMvcAppWithFluentValidation.Models;

namespace PocMvcAppWithFluentValidation.Validators;

public class AddTodoModelValidator : AbstractValidator<AddTodoModel>
{

    public AddTodoModelValidator()
    {
        RuleFor(m => m.Title)
            .MinimumLength(10)
            .NotEmpty();

        RuleFor(m => m.Description)
            .NotEmpty();
    }

}