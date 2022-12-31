using PocMvcAppWithFluentValidation.DataAccess.Entities;

namespace PocMvcAppWithFluentValidation.Models;

public class TodosModel
{

    public IList<TodoDao> Todos { get; set; }

}