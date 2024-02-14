using VerticalSliceArchitecture.SharedKernel;

namespace VerticalSliceArchitecture.Api.Features.Todo.TodoList;

public sealed record CreateTodoListRequest(string Name, string Description) : ICommand<Result<CreateTodoListResponse>>;
