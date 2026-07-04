using NotesApp.Api.Models.Requests;
using NotesApp.Api.Models.Responses;

namespace NotesApp.Api.Services.Interfaces;

public interface INoteService
{
    Task<IEnumerable<NoteResponse>> GetAllAsync(Guid userId);

    Task<IEnumerable<NoteResponse>> SearchAsync(
        Guid userId,
        NoteQueryRequest request);

    Task<NoteResponse> GetByIdAsync(Guid noteId, Guid userId);

    Task CreateAsync(Guid userId, CreateNoteRequest request);

    Task UpdateAsync(Guid noteId, Guid userId, UpdateNoteRequest request);

    Task DeleteAsync(Guid noteId, Guid userId);
}
