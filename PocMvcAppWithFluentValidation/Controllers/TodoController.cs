using MediatR;
using Microsoft.AspNetCore.Mvc;
using PocMvcAppWithFluentValidation.Commands;
using PocMvcAppWithFluentValidation.DataAccess;
using PocMvcAppWithFluentValidation.Models;

namespace PocMvcAppWithFluentValidation.Controllers;

[Route("todo")]
public class TodoController : Controller
{

    private readonly IMediator _mediator;
    private readonly ITodoRepository _todoRepository;

    public TodoController(
        IMediator mediator,
        ITodoRepository todoRepository)
    {
        _mediator = mediator;
        _todoRepository = todoRepository;
    }

    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var model = new TodosModel();
        model.Todos = await _todoRepository.GetTodosAsync();

        return View(model);
    }

    [HttpGet("add")]
    public IActionResult AddTodo()
    {
        return View();
    }

    [HttpPost("add")]
    public async Task<IActionResult> AddTodo(AddTodoModel model)
    {
        if (ModelState.IsValid)
        {
            await _mediator.Send(new AddTodoCommand
            {
                Title = model.Title,
                Description = model.Description
            });

            return RedirectToAction("Index");
        }

        return View(model);
    }

    [HttpGet("delete/{todoId}")]
    public async Task<IActionResult> DeleteTodo(long todoId)
    {
        await _todoRepository.DeleteAsync(todoId);
        return RedirectToAction("Index");
    }

}