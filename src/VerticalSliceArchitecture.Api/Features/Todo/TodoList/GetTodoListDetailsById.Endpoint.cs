using MediatR;
using VerticalSliceArchitecture.Api.Extensions;

namespace VerticalSliceArchitecture.Api.Features.Todo.TodoList;

public static class GetTodoListDetailsByIdEndpoint
{
    public static IEndpointRouteBuilder MapGetTodoListDetailsById(this IEndpointRouteBuilder builder)
    {
        builder.MapGet("/{id:long}", async (long id, IMediator mediator) =>
            {
                var details = await mediator.Send(new GetTodoListDetailsByIdQuery(id));
                return details.IsSuccess ? TypedResults.Ok(details.Value) : details.ToProblemDetails();
            })
            .WithName("Get Todo list details");
        return builder;
    }
}
