# Fluent Validation and MediatR

An example POC project showing how to use Fluent Validation and MediatR together.

The validation is handled globally in the
ActionFilter [ValidationActionAsyncFilter.cs](./PocMvcAppWithFluentValidation/Filters/ValidationActionAsyncFilter.cs)
file, so we can simply check the `ModelState.IsValid` property as usual in controller actions. For an example, see
the [TodoController.cs](./PocMvcAppWithFluentValidation/Controllers/TodoController.cs) file."
