using Microsoft.EntityFrameworkCore;
using VerticalSliceArchitecture.Api.Database;
using VerticalSliceArchitecture.SharedKernel;

namespace VerticalSliceArchitecture.Api.Features.Todo.TodoList;

public sealed class GetTodoListDetailsByIdQueryHandler(ApplicationDbContext dbContext, ILogger<GetTodoListDetailsByIdQueryHandler> logger) : IQueryHandler<GetTodoListDetailsByIdQuery, Result<TodoListResponse>>
{
    public async Task<Result<TodoListResponse>> Handle(GetTodoListDetailsByIdQuery request, CancellationToken cancellationToken)
    {
        var details = await dbContext
            .TodoList
            .Include(x => x.TodoItems)
            .Where(x => x.Id == request.Id)
            .Select(x => new TodoListResponse()
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
                IsCompleted = x.IsCompleted
            })
            .FirstOrDefaultAsync(cancellationToken);

        if (details is null)
        {
            logger.LogWarning("Todo list details not found with the request: {@request}", request);
            return Error.NotFound("TodoListDetails", $"Todo list details not found with ID: {request.Id}");
        }

        return details;
    }
}
