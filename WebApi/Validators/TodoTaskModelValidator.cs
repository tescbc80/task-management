using CBC.TaskManagement.WebApi.Models;
using FluentValidation;

namespace CBC.TaskManagement.WebApi.Validators
{
    public class TodoTaskModelValidator : AbstractValidator<TodoTaskModel>
    {
        public TodoTaskModelValidator()
        {
            RuleFor(x => x.Title)
                .NotNull()
                .MaximumLength(50)
                .MinimumLength(3)
                .WithMessage("The title must be at least 3 and a maximum of 50 characters long.");

            RuleFor(x => x.Description)
                .MaximumLength(500).WithMessage("The description must be a maximum of 500 characters long.");
        }
    }
}