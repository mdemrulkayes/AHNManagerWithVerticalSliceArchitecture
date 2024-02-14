using MediatR;

namespace VerticalSliceArchitecture.Api.Features.Todo.TodoList;

public static class CreateTodoListEndpoint
{
    public static IEndpointRouteBuilder MapCreateTodo(this IEndpointRouteBuilder builder)
    {
        builder.MapPost("/", async (CreateTodoListCommand request,IMediator mediator) =>
        {
            var result = await mediator.Send(request);
            return TypedResults.Ok(result.Value);
        }).WithName("Create Todo list item");

        return builder;
    }
}
