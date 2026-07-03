using System.ComponentModel.DataAnnotations;

namespace NotesApp.Api.Models.Requests;

public class UpdateNoteRequest
{
    [Required]
    [MaxLength(200)]
    public string Title { get; set; } = string.Empty;

    public string? Content { get; set; }
}
