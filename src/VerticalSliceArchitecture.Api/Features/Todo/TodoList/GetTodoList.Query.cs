using VerticalSliceArchitecture.SharedKernel;

namespace VerticalSliceArchitecture.Api.Features.Todo.TodoList;

public sealed record GetTodoListQuery : QueryStringParameter, IQuery<Result<PaginatedList<TodoListResponse>>>;
