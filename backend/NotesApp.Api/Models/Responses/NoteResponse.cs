namespace NotesApp.Api.Models.Responses;

public class NoteResponse
{
    public Guid Id { get; set; }

    public string Title { get; set; } = string.Empty;

    public string? Content { get; set; }

    public Guid? TagId { get; set; }

public string? TagName { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
}
