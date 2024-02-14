using VerticalSliceArchitecture.SharedKernel;

namespace VerticalSliceArchitecture.Api.Features.Todo.Domain;

public sealed class TodoItem : BaseAuditableEntity
{
    public long Id { get; private set; }
    public string ItemName { get; private set; }
    public string Description { get; private set; }
    public bool IsDone { get; private set; }

    public long TodoListId { get; private set; }
    public TodoList TodoList { get; private set; }
}
