using MediatR;

namespace PocMvcAppWithFluentValidation.Commands;

public class AddTodoCommand : IRequest<AddTodoCommandResponse>
{

    public string? Title { get; set; }

    public string? Description { get; set; }

}