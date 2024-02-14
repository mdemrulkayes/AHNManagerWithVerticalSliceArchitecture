using FluentValidation;

namespace VerticalSliceArchitecture.Api.Features.Todo.TodoList;

public class CreateTodoListRequestValidator : AbstractValidator<CreateTodoListRequest>
{
    public CreateTodoListRequestValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .WithMessage("Todo Name can not be empty")
            .MaximumLength(100)
            .WithMessage("Name maximum length can not be more than 100 characters");
    }
}
