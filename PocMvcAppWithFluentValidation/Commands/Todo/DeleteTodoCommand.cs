using MediatR;

namespace PocMvcAppWithFluentValidation.Commands.Todo;

public class DeleteTodoCommand : IRequest
{

    public long Id { get; set; }

}