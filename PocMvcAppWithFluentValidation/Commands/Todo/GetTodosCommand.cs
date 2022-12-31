using MediatR;

namespace PocMvcAppWithFluentValidation.Commands.Todo;

public class GetTodosCommand : IRequest<GetTodosCommandResponse>
{

}