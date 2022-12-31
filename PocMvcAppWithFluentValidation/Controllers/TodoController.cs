using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using PocMvcAppWithFluentValidation.Commands.Todo;
using PocMvcAppWithFluentValidation.Controllers.BaseTypes;
using PocMvcAppWithFluentValidation.Extensions;
using PocMvcAppWithFluentValidation.Models.Todo;

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
        var request = new GetTodosCommand();
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
        try
        {
            var request = new AddTodoCommand
            {
                Title = model.Title,
                Description = model.Description
            };

            await _mediator.Send(request);
        }
        catch (ValidationException validationException)
        {
            validationException.AddToModelState(ModelState);
        }

        if (ModelState.IsValid)
        {
            return RedirectToAction("Index");
        }

        return View(model);
    }

    [HttpGet("delete/{todoId}")]
    public async Task<IActionResult> DeleteTodo(long todoId)
    {
        var request = new DeleteTodoCommand { Id = todoId };
        await _mediator.Send(request);

        return RedirectToAction("Index");
    }

}