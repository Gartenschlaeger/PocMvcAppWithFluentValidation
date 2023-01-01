using MediatR;
using PocMvcAppWithFluentValidation.DataAccess;

namespace PocMvcAppWithFluentValidation.Requests.Todo;

public class GetTodosQueryHandler : IRequestHandler<GetTodosQuery, GetTodosQueryResponse>
{

    private readonly ITodoRepository _todoRepository;

    public GetTodosQueryHandler(
        ITodoRepository todoRepository)
    {
        _todoRepository = todoRepository;
    }

    public async Task<GetTodosQueryResponse> Handle(
        GetTodosQuery request,
        CancellationToken cancellationToken)
    {
        return new GetTodosQueryResponse
        {
            Todos = await _todoRepository.GetTodosAsync()
        };
    }

}