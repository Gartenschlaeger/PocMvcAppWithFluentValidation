using System.Collections.Immutable;
using PocMvcAppWithFluentValidation.DataAccess.Entities;

namespace PocMvcAppWithFluentValidation.DataAccess;

public interface ITodoRepository
{

    Task AddAsync(TodoDao todo);

    Task<TodoDao?> GetByIdAsync(long id);

    Task<TodoDao?> GetByTitleAsync(string title);

    Task<ImmutableList<TodoDao>> GetTodosAsync();

    Task UpdateAsync(TodoDao todo);

    Task DeleteAsync(long id);

}