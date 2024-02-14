using System.Collections.ObjectModel;
using VerticalSliceArchitecture.SharedKernel;

namespace VerticalSliceArchitecture.Api.Features.Todo.Domain;

public sealed class TodoList : BaseAuditableEntity
{
    private List<TodoItem> _tasks = new List<TodoItem>();

    public long Id { get; private set; }
    public string Name { get; private set; }
    public string Description { get; private set; }
    public Guid AssignedToGuid { get; private set; }
    public bool IsCompleted { get; private set; }

    public ReadOnlyCollection<TodoItem> TodoItems => _tasks.AsReadOnly();

    private TodoList(string name, string description)
    {
        Name = name;
        Description = description;
    }

    public static Result<TodoList> Create(string name, string description)
    {
        return new TodoList(name, description);
    }
}
