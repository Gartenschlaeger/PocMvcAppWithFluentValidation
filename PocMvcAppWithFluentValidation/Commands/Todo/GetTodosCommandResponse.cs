using System.Collections.Immutable;
using PocMvcAppWithFluentValidation.DataAccess.Entities;

namespace PocMvcAppWithFluentValidation.Commands.Todo;

public class GetTodosCommandResponse
{

    public ImmutableList<TodoDao> Todos { get; set; }

}