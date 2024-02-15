namespace VerticalSliceArchitecture.Api.Features.Todo.TodoList;

public static class TodoListEndpointMapping
{
    public static IEndpointRouteBuilder MapTodoListRoutes(this IEndpointRouteBuilder builder)
    {
        builder.MapGroup("/api/todo")
            .WithTags("Todo")
            .WithOpenApi()
            .MapCreateTodo()
            .MapGetTodos()
            .MapGetTodoListDetailsById();
        return builder;
    }
}
