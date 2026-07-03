using System.ComponentModel.DataAnnotations;

namespace NotesApp.Api.Models.Requests;

public class RefreshTokenRequest
{
    [Required]
    public string RefreshToken { get; set; } = string.Empty;
}