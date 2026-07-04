namespace NotesApp.Api.Models.Requests;

public class NoteQueryRequest
{
    public string? Search { get; set; }

    public string? Title { get; set; }

    public Guid? TagId { get; set; }

    public string SortBy { get; set; } = "createdAt";

    public bool Descending { get; set; } = true;
}
