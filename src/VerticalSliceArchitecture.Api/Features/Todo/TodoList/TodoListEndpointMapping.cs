namespace VerticalSliceArchitecture.Api.Features.Todo.TodoList;

public static class TodoListEndpointMapping
{
    public static IEndpointRouteBuilder MapTodoListRoutes(this IEndpointRouteBuilder builder)
    {
        builder.MapGroup("Todo")
            .WithTags("Todo")
            .WithOpenApi()
            .MapCreateTodo();
        return builder;
    }
}
