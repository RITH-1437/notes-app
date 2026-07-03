using NotesApp.Api.Models.Requests;
using NotesApp.Api.Models.Responses;

namespace NotesApp.Api.Services.Interfaces;

public interface INoteService
{
    Task<IEnumerable<NoteResponse>> GetAllAsync(Guid userId);

    Task<NoteResponse?> GetByIdAsync(Guid noteId, Guid userId);

    Task CreateAsync(Guid userId, CreateNoteRequest request);

    Task<bool> UpdateAsync(Guid noteId, Guid userId, UpdateNoteRequest request);

    Task<bool> DeleteAsync(Guid noteId, Guid userId);
}
