using MediatR;
using PocMvcAppWithFluentValidation.DataAccess;

namespace PocMvcAppWithFluentValidation.Commands.Todo;

public class GetTodosCommandHandler : IRequestHandler<GetTodosCommand, GetTodosCommandResponse>
{

    private readonly ITodoRepository _todoRepository;

    public GetTodosCommandHandler(
        ITodoRepository todoRepository)
    {
        _todoRepository = todoRepository;
    }

    public async Task<GetTodosCommandResponse> Handle(
        GetTodosCommand request,
        CancellationToken cancellationToken)
    {
        return new GetTodosCommandResponse
        {
            Todos = await _todoRepository.GetTodosAsync()
        };
    }

}