using System.ComponentModel.DataAnnotations;

namespace NotesApp.Api.Models.Requests;

public class CreateTagRequest
{
    [Required]
    [MaxLength(100)]
    public string Name { get; set; } = string.Empty;
}
