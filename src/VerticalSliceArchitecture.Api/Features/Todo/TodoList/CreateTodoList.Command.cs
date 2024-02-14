using VerticalSliceArchitecture.SharedKernel;

namespace VerticalSliceArchitecture.Api.Features.Todo.TodoList;

public sealed record CreateTodoListCommand(string Name, string Description) : ICommand<Result<CreateTodoListResponse>>;
