using VerticalSliceArchitecture.Api.Database;
using VerticalSliceArchitecture.SharedKernel;

namespace VerticalSliceArchitecture.Api.Features.Todo.TodoList;

public sealed class CreateTodoList(ApplicationDbContext dbContext, ILogger<CreateTodoList> logger) : ICommandHandler<CreateTodoListRequest, Result<CreateTodoListResponse>>
{
    public async Task<Result<CreateTodoListResponse>> Handle(CreateTodoListRequest request, CancellationToken cancellationToken = default)
    {
        logger.LogInformation("Inside Create todo list command handler");
        var todoList = Domain.TodoList.Create(request.Name, request.Description);
        if (!todoList.IsSuccess || todoList.Value is null)
        {
            return todoList.Error;
        }

        logger.LogInformation("Create todo list object from the domain");

        await dbContext.TodoList.AddAsync(todoList.Value, cancellationToken);
        await dbContext.SaveChangesAsync(cancellationToken);

        return new CreateTodoListResponse(todoList.Value.Id, todoList.Value.Name, todoList.Value.Description, todoList.Value.IsCompleted);
    }
}
