using VerticalSliceArchitecture.SharedKernel;

namespace VerticalSliceArchitecture.Api.Features.Todo.TodoList;

public sealed record GetTodoListDetailsByIdQuery(long Id) : IQuery<Result<TodoListResponse>>;
