using VerticalSliceArchitecture.Api.Database;
using VerticalSliceArchitecture.SharedKernel;

namespace VerticalSliceArchitecture.Api.Features.Todo.TodoList;

public sealed class CreateTodoListCommandHandler(ApplicationDbContext dbContext, ILogger<CreateTodoListCommandHandler> logger) : ICommandHandler<CreateTodoListCommand, Result<CreateTodoListResponse>>
{
    public async Task<Result<CreateTodoListResponse>> Handle(CreateTodoListCommand command, CancellationToken cancellationToken = default)
    {
        logger.LogDebug("Inside Create todo list command handler");
        var todoList = Domain.TodoList.Create(command.Name, command.Description);
        if (!todoList.IsSuccess || todoList.Value is null)
        {
            return todoList.Error;
        }

        logger.LogDebug("Create todo list object from the domain");

        await dbContext.TodoList.AddAsync(todoList.Value, cancellationToken);
        await dbContext.SaveChangesAsync(cancellationToken);

        logger.LogDebug("Todo list created");

        return new CreateTodoListResponse(todoList.Value.Id, todoList.Value.Name, todoList.Value.Description, todoList.Value.IsCompleted);
    }
}