using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using PocMvcAppWithFluentValidation.Models;

namespace PocMvcAppWithFluentValidation.Controllers;

[Route("todo")]
public class TodoController : Controller
{

    private readonly IValidator<AddTodoModel> _addTodoValidator;

    public TodoController(
        IValidator<AddTodoModel> addTodoValidator)
    {
        _addTodoValidator = addTodoValidator;
    }

    [HttpGet("add")]
    public IActionResult AddTodo()
    {
        return View();
    }

    [HttpPost("add")]
    public async Task<IActionResult> AddTodo(AddTodoModel model)
    {
        var validationResult = await _addTodoValidator.ValidateAsync(model);
        validationResult.AddToModelState(ModelState);

        if (ModelState.IsValid)
        {
            ViewBag.Saved = true;
        }

        return View(model);
    }

}