namespace VerticalSliceArchitecture.Api.Features.Todo.TodoList;

public sealed record CreateTodoListResponse(long Id, string Name, string Description, bool IsCompleted);
