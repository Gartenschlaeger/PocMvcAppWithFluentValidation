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
    public IActionResult AddTodo(AddTodoModel model)
    {
        if (ModelState.IsValid)
        {
            return RedirectToAction("Index", "Home");
        }

        return View(model);
    }

}