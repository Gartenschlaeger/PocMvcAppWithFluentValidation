using System.Collections.Immutable;
using PocMvcAppWithFluentValidation.DataAccess.Entities;

namespace PocMvcAppWithFluentValidation.DataAccess;

public interface ITodoRepository
{

    Task AddAsync(TodoDao todo);

    Task<TodoDao> GetById(long id);

    Task<ImmutableList<TodoDao>> GetTodos();

    Task Update(TodoDao todo);

    Task Delete(long id);

}