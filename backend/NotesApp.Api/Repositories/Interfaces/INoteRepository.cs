using NotesApp.Api.Models.Entities;

namespace NotesApp.Api.Repositories.Interfaces;

public interface INoteRepository
{
    Task<IEnumerable<Note>> GetAllByUserIdAsync(Guid userId);

    Task<Note?> GetByIdAsync(Guid id);

    Task CreateAsync(Note note);

    Task UpdateAsync(Note note);

    Task DeleteAsync(Guid id);
}
