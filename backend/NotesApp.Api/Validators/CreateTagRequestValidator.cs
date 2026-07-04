using FluentValidation;
using NotesApp.Api.Models.Requests;

namespace NotesApp.Api.Validators;

public class CreateTagRequestValidator : AbstractValidator<CreateTagRequest>
{
    public CreateTagRequestValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .WithMessage("Tag name is required.")
            .MaximumLength(100);
    }
}
