using PocMvcAppWithFluentValidation.DataAccess.Entities;

namespace PocMvcAppWithFluentValidation.Models.Todo;

public class TodosModel
{

    public IList<TodoDao> Todos { get; set; } = null!;

}