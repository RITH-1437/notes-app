using NotesApp.Api.Models.Entities;
using NotesApp.Api.Models.Requests;

namespace NotesApp.Api.Repositories.Interfaces;

public interface INoteRepository
{
    Task<IEnumerable<Note>> GetAllByUserIdAsync(Guid userId);

    Task<IEnumerable<Note>> SearchAsync(
    Guid userId,
    NoteQueryRequest request);

    Task<Note?> GetByIdAsync(Guid id);

    Task CreateAsync(Note note);

    Task UpdateAsync(Note note);

    Task DeleteAsync(Guid id);
}
