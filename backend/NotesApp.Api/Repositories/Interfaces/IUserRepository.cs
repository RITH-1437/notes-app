using NotesApp.Api.Models.Entities;

namespace NotesApp.Api.Repositories.Interfaces;

public interface IUserRepository
{
    Task<User?> GetByIdAsync(Guid id);

    Task<User?> GetByEmailAsync(string email);

    Task<User?> GetByUsernameAsync(string username);

    Task<Guid> CreateAsync(User user);
}