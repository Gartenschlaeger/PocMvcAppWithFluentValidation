using MediatR;

namespace PocMvcAppWithFluentValidation.Requests.Todo;

public class DeleteTodoCommand : IRequest
{

    public long Id { get; set; }

}