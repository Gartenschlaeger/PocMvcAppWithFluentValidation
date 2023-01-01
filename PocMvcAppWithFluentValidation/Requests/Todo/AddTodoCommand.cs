using MediatR;

namespace PocMvcAppWithFluentValidation.Requests.Todo;

public class AddTodoCommand : IRequest<AddTodoCommandResponse>
{

    public string? Title { get; set; }

    public string? Description { get; set; }

}