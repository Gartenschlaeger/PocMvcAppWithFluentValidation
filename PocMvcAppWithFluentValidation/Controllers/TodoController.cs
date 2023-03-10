using MediatR;
using Microsoft.AspNetCore.Mvc;
using PocMvcAppWithFluentValidation.Controllers.BaseTypes;
using PocMvcAppWithFluentValidation.Models.Todo;
using PocMvcAppWithFluentValidation.Requests.Todo;

namespace PocMvcAppWithFluentValidation.Controllers;

[Route("todo")]
public class TodoController : WebController
{

    private readonly IMediator _mediator;

    public TodoController(
        IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var request = new GetTodosQuery();
        var response = await _mediator.Send(request);

        var model = new TodosModel();
        model.Todos = response.Todos;

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
            var request = new AddTodoCommand
            {
                Title = model.Title,
                Description = model.Description
            };

            await _mediator.Send(request);

            return RedirectToAction("Index");
        }

        return View(model);
    }

    [HttpGet("delete/{todoId}")]
    public async Task<IActionResult> DeleteTodo(long todoId)
    {
        var request = new DeleteTodoCommand
        {
            Id = todoId
        };

        await _mediator.Send(request);

        return RedirectToAction("Index");
    }

}