using FluentValidation;
using NotesApp.Api.Models.Requests;

namespace NotesApp.Api.Validators;

public class UpdateNoteRequestValidator : AbstractValidator<UpdateNoteRequest>
{
    public UpdateNoteRequestValidator()
    {
        RuleFor(x => x.Title)
            .NotEmpty()
            .WithMessage("Title is required.")
            .MaximumLength(200);

        RuleFor(x => x.Content)
            .NotEmpty()
            .WithMessage("Content is required.")
            .MaximumLength(5000);
    }
}
