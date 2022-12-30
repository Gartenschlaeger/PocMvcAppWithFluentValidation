using System.ComponentModel.DataAnnotations;

namespace PocMvcAppWithFluentValidation.Models;

public class AddTodoModel
{

    [Required]
    public string? Title { get; set; }

    [Required]
    public string? Description { get; set; }

}