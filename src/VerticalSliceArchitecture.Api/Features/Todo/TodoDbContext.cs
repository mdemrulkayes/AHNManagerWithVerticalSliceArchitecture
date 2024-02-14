using Microsoft.EntityFrameworkCore;
using VerticalSliceArchitecture.Api.Features.Todo.Domain;

// Disable as we want the partial class to be in the same namespace as the original class
// ReSharper disable once CheckNamespace
namespace VerticalSliceArchitecture.Api.Database;

public sealed partial class ApplicationDbContext
{
    public DbSet<TodoList> TodoList { get; set; }
    public DbSet<TodoItem> TodoItem { get; set; }
}
