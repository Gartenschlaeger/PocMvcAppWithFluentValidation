using Microsoft.AspNetCore.Mvc;
using PocMvcAppWithFluentValidation.Models;

namespace PocMvcAppWithFluentValidation.Controllers;

[Route("todo")]
public class TodoController : Controller
{

    [HttpGet("add")]
    public IActionResult AddTodo()
    {
        return View();
    }

    [HttpPost("add")]
    public Task<IActionResult> AddTodo(AddTodoModel model)
    {
        // var validationResult = await _addTodoValidator.ValidateAsync(model);
        // validationResult.AddToModelState(ModelState);

        if (ModelState.IsValid)
        {
            ViewBag.Saved = true;
        }

        return Task.FromResult<IActionResult>(View(model));
    }

}