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

    public Task<TodoDao?> GetByIdAsync(long id)
    {
        throw new NotImplementedException();
    }

    public Task<TodoDao?> GetByTitleAsync(string title)
    {
        var todo = _todos.SingleOrDefault(todo
            => todo.Title != null && todo.Title.Equals(title));

        return Task.FromResult(todo);
    }

    public Task<ImmutableList<TodoDao>> GetTodosAsync()
    {
        return Task.FromResult(_todos.ToImmutableList());
    }

    public Task UpdateAsync(TodoDao todo)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(long id)
    {
        var index = _todos.FindIndex(t => t.Id == id);
        if (index != -1)
        {
            _todos.RemoveAt(index);
        }

        return Task.CompletedTask;
    }

}