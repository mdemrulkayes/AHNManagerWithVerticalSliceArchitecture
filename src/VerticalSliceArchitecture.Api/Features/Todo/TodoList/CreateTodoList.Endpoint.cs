using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace VerticalSliceArchitecture.Api.Features.Todo.TodoList;

public static class CreateTodoListEndpoint
{
    public static IEndpointRouteBuilder MapCreateTodo(this IEndpointRouteBuilder builder)
    {
        builder.MapPost("", async ([FromBody]CreateTodoListRequest request,IMediator mediator) =>
        {
            var result = await mediator.Send(request);
            return TypedResults.Ok(result.Value);
        });

        return builder;
    }
}
