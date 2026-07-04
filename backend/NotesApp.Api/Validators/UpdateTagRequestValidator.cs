using FluentValidation;
using NotesApp.Api.Models.Requests;

namespace NotesApp.Api.Validators;

public class UpdateTagRequestValidator : AbstractValidator<UpdateTagRequest>
{
    public UpdateTagRequestValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .WithMessage("Tag name is required.")
            .MaximumLength(100);
    }
}
