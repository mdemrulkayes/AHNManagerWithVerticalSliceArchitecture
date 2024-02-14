using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VerticalSliceArchitecture.Api.Features.Todo.Domain;

namespace VerticalSliceArchitecture.Api.Features.Todo.Configuration;

public sealed class TodoListConfiguration : IEntityTypeConfiguration<Domain.TodoList>
{
    public void Configure(EntityTypeBuilder<Domain.TodoList> builder)
    {
        builder.ToTable("TodoList");

        builder.HasKey(t => t.Id);
        builder.Property(x => x.Name)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(x => x.Description)
            .IsRequired(false)
            .HasMaxLength(500);

        builder.Property(x => x.IsCompleted)
            .HasDefaultValue(false);

        builder.HasMany(x => x.TodoItems)
            .WithOne(x => x.TodoList)
            .HasForeignKey(x => x.TodoListId)
            .IsRequired();
    }
}
