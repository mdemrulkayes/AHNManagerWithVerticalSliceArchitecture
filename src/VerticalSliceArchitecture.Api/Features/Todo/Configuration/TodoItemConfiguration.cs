using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VerticalSliceArchitecture.Api.Features.Todo.Domain;

namespace VerticalSliceArchitecture.Api.Features.Todo.Configuration;

public sealed class TodoItemConfiguration : IEntityTypeConfiguration<TodoItem>
{
    public void Configure(EntityTypeBuilder<TodoItem> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.ItemName)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(x => x.Description)
            .IsRequired(false)
            .HasMaxLength(300);

        builder.Property(x => x.IsDone)
            .HasDefaultValue(false);
    }
}
