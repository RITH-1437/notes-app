using NotesApp.Api.Models.Entities;

namespace NotesApp.Api.Repositories.Interfaces;

public interface IRefreshTokenRepository
{
    Task SaveAsync(RefreshToken refreshToken);

    Task<RefreshToken?> GetByTokenAsync(string token);

    Task RevokeAsync(Guid id);
}