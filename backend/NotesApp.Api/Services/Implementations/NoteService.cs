using NotesApp.Api.Models.Entities;
using NotesApp.Api.Models.Requests;
using NotesApp.Api.Models.Responses;
using NotesApp.Api.Repositories.Interfaces;
using NotesApp.Api.Services.Interfaces;

namespace NotesApp.Api.Services.Implementations;

public class NoteService : INoteService
{
    private readonly INoteRepository _noteRepository;

    public NoteService(INoteRepository noteRepository)
    {
        _noteRepository = noteRepository;
    }

    public async Task<IEnumerable<NoteResponse>> GetAllAsync(Guid userId)
    {
        var notes = await _noteRepository.GetAllByUserIdAsync(userId);

        return notes.Select(n => new NoteResponse
{
    Id = n.Id,
    Title = n.Title,
    Content = n.Content,
    CreatedAt = n.CreatedAt,
    UpdatedAt = n.UpdatedAt
});
    }

    public async Task<NoteResponse?> GetByIdAsync(Guid noteId, Guid userId)
    {
        var note = await _noteRepository.GetByIdAsync(noteId);

        if (note == null || note.UserId != userId)
            return null;

        return new NoteResponse
        {
            Id = note.Id,
            Title = note.Title,
            Content = note.Content,
            CreatedAt = note.CreatedAt,
            UpdatedAt = note.UpdatedAt
        };
    }

    public async Task CreateAsync(Guid userId, CreateNoteRequest request)
    {
        var note = new Note
{
    Id = Guid.NewGuid(),
    UserId = userId,
    Title = request.Title,
    Content = request.Content,
    CreatedAt = DateTime.UtcNow,
    UpdatedAt = null,
    IsDeleted = false
};

        await _noteRepository.CreateAsync(note);
    }

    public async Task<bool> UpdateAsync(Guid noteId, Guid userId, UpdateNoteRequest request)
    {
        var note = await _noteRepository.GetByIdAsync(noteId);

        if (note == null || note.UserId != userId)
            return false;

        note.Title = request.Title;
        note.Content = request.Content;
        note.UpdatedAt = DateTime.UtcNow;

        await _noteRepository.UpdateAsync(note);

        return true;
    }

    public async Task<bool> DeleteAsync(Guid noteId, Guid userId)
    {
        var note = await _noteRepository.GetByIdAsync(noteId);

        if (note == null || note.UserId != userId)
            return false;

        await _noteRepository.DeleteAsync(noteId);

        return true;
    }
}
