using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace VerticalSliceArchitecture.Api.Features.Todo.TodoList;

public static class GetTodoListEndpoint
{
    public static IEndpointRouteBuilder MapGetTodos(this IEndpointRouteBuilder builder)
    {
        builder.MapGet("/", async ([AsParameters] GetTodoListQuery query, IMediator mediatr) =>
        {
            var todoLists = await mediatr.Send(query);
            return TypedResults.Ok(todoLists.Value);
        })
        .WithName("Get all todos");
        return builder;
    }
}
