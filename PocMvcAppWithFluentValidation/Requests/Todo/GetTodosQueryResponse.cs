using System.Collections.Immutable;
using PocMvcAppWithFluentValidation.DataAccess.Entities;

namespace PocMvcAppWithFluentValidation.Requests.Todo;

public class GetTodosQueryResponse
{

    public ImmutableList<TodoDao> Todos { get; set; }

}