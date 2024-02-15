using Microsoft.EntityFrameworkCore;
using VerticalSliceArchitecture.Api.Database;
using VerticalSliceArchitecture.SharedKernel;
using VerticalSliceArchitecture.SharedKernel.Extensions;

namespace VerticalSliceArchitecture.Api.Features.Todo.TodoList;

public sealed class GetTodoListQueryHandler(ApplicationDbContext dbContext) : IQueryHandler<GetTodoListQuery, Result<PaginatedList<TodoListResponse>>>
{
    public async Task<Result<PaginatedList<TodoListResponse>>> Handle(GetTodoListQuery request, CancellationToken cancellationToken)
    {
        return await dbContext
            .TodoList
            .Include(x => x.TodoItems)
            .Select(x => new TodoListResponse()
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
                IsCompleted = x.IsCompleted
            })
            .ToPaginatedListAsync(request.PageNumber, request.PageSize, cancellationToken);
    }
}
