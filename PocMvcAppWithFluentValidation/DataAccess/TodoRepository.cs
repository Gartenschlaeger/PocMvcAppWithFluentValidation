using System.Collections.Immutable;
using PocMvcAppWithFluentValidation.DataAccess.Entities;

namespace PocMvcAppWithFluentValidation.DataAccess;

public class TodoRepository : ITodoRepository
{

    private long _nextId = 1;
    private readonly List<TodoDao> _todos = new();

    public Task AddAsync(TodoDao todo)
    {
        todo.Id = _nextId;
        _nextId++;

        _todos.Add(todo);

        return Task.CompletedTask;
    }

    public Task<TodoDao> GetById(long id)
    {
        throw new NotImplementedException();
    }

    public Task<ImmutableList<TodoDao>> GetTodos()
    {
        return Task.FromResult(_todos.ToImmutableList());
    }

    public Task Update(TodoDao todo)
    {
        throw new NotImplementedException();
    }

    public Task Delete(long id)
    {
        throw new NotImplementedException();
    }

}