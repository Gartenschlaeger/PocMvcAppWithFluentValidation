using MediatR;
using PocMvcAppWithFluentValidation.DataAccess;
using PocMvcAppWithFluentValidation.DataAccess.Entities;

namespace PocMvcAppWithFluentValidation.Commands;

public class AddTodoCommandHandler : IRequestHandler<AddTodoCommand, AddTodoCommandResponse>
{

    private readonly ITodoRepository _todoRepository;

    public AddTodoCommandHandler(
        ITodoRepository todoRepository)
    {
        _todoRepository = todoRepository;
    }

    public async Task<AddTodoCommandResponse> Handle(
        AddTodoCommand request,
        CancellationToken cancellationToken)
    {
        var todo = new TodoDao
        {
            Title = request.Title,
            Description = request.Description
        };

        await _todoRepository.AddAsync(todo);

        return new AddTodoCommandResponse
        {
            Id = todo.Id
        };
    }

}