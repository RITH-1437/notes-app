namespace NotesApp.Api.Services.Interfaces;
using System.Security.Claims;
using NotesApp.Api.Models.Entities;using NotesApp.Api.Models;

public interface IJwtService
{
    string GenerateAccessToken(User user);

    string GenerateRefreshToken();

    ClaimsPrincipal? GetPrincipalFromExpiredToken(string token);
}