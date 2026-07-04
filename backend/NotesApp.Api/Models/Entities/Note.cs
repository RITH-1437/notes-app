namespace NotesApp.Api.Models.Entities;

public class Note
{
    public Guid Id { get; set; }

    public Guid UserId { get; set; }

    public string Title { get; set; } = string.Empty;

    public Guid? TagId { get; set; }
    public string? Content { get; set; }
    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public bool IsDeleted { get; set; }
}
