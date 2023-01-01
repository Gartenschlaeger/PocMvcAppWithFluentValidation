using MediatR;
using PocMvcAppWithFluentValidation.DataAccess;

namespace PocMvcAppWithFluentValidation.Requests.Todo;

public class DeleteTodoCommandHandler : IRequestHandler<DeleteTodoCommand>
{

    private readonly ITodoRepository _todoRepository;

    public DeleteTodoCommandHandler(
        ITodoRepository todoRepository)
    {
        _todoRepository = todoRepository;
    }

    public async Task<Unit> Handle(DeleteTodoCommand request, CancellationToken cancellationToken)
    {
        await _todoRepository.DeleteAsync(request.Id);

        return Unit.Value;
    }

}