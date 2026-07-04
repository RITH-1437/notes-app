using NotesApp.Api.Models.Entities;
using NotesApp.Api.Models.Requests;
using NotesApp.Api.Models.Responses;
using NotesApp.Api.Repositories.Interfaces;
using NotesApp.Api.Services.Interfaces;
using NotesApp.Api.Exceptions;
namespace NotesApp.Api.Services.Implementations;

public class NoteService : INoteService
{
    private readonly INoteRepository _noteRepository;
    private readonly ITagRepository _tagRepository;

    public NoteService(
        INoteRepository noteRepository,
        ITagRepository tagRepository)
    {
        _noteRepository = noteRepository;
        _tagRepository = tagRepository;
    }

    public async Task<IEnumerable<NoteResponse>> GetAllAsync(Guid userId)
    {
        var notes = await _noteRepository.GetAllByUserIdAsync(userId);

        return notes.Select(n => new NoteResponse
        {
            Id = n.Id,
            Title = n.Title,
            Content = n.Content,
            TagId = n.TagId,
            TagName = n.TagName,
            CreatedAt = n.CreatedAt,
            UpdatedAt = n.UpdatedAt
        });
    }

    public async Task<NoteResponse> GetByIdAsync(Guid noteId, Guid userId)
{
    var note = await _noteRepository.GetByIdAsync(noteId);

    if (note == null)
        throw new NotFoundException("Note not found.");

    if (note.UserId != userId)
        throw new ForbiddenException("You are not allowed to access this note.");

    return new NoteResponse
    {
        Id = note.Id,
        Title = note.Title,
        Content = note.Content,
        TagId = note.TagId,
        TagName = note.TagName,
        CreatedAt = note.CreatedAt,
        UpdatedAt = note.UpdatedAt
    };
}

    public async Task CreateAsync(Guid userId, CreateNoteRequest request)
    {
        if (request.TagId.HasValue)
        {
            var tag = await _tagRepository.GetByIdAsync(request.TagId.Value);

            if (tag == null || tag.UserId != userId)
                throw new BadRequestException("Invalid tag.");
        }

        var note = new Note
        {
            Id = Guid.NewGuid(),
            UserId = userId,
            TagId = request.TagId,
            Title = request.Title,
            Content = request.Content,
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = null,
            IsDeleted = false
        };

        await _noteRepository.CreateAsync(note);
    }

    public async Task UpdateAsync(Guid noteId, Guid userId, UpdateNoteRequest request)
    {
        var note = await _noteRepository.GetByIdAsync(noteId);

if (note == null)
    throw new NotFoundException("Note not found.");

if (note.UserId != userId)
    throw new ForbiddenException("You are not allowed to access this note.");

if (request.TagId.HasValue)
{
    var tag = await _tagRepository.GetByIdAsync(request.TagId.Value);

    if (tag == null || tag.UserId != userId)
        throw new BadRequestException("Invalid tag.");
}

note.Title = request.Title;
note.Content = request.Content;
note.TagId = request.TagId;
note.UpdatedAt = DateTime.UtcNow;

await _noteRepository.UpdateAsync(note);
    }

    public async Task DeleteAsync(Guid noteId, Guid userId)
    {var note = await _noteRepository.GetByIdAsync(noteId);

if (note == null)
    throw new NotFoundException("Note not found.");

if (note.UserId != userId)
    throw new ForbiddenException("You are not allowed to access this note.");

await _noteRepository.DeleteAsync(noteId);
    }

    public async Task<IEnumerable<NoteResponse>> SearchAsync(
        Guid userId,
        NoteQueryRequest request)
    {
        // Validate tag ownership
        if (request.TagId.HasValue)
        {
            var tag = await _tagRepository.GetByIdAsync(request.TagId.Value);

            if (tag == null || tag.UserId != userId)
                throw new BadRequestException("Invalid tag.");
        }

        var notes = await _noteRepository.SearchAsync(userId, request);

        return notes.Select(n => new NoteResponse
        {
            Id = n.Id,
            Title = n.Title,
            Content = n.Content,
            TagId = n.TagId,
            TagName = n.TagName,
            CreatedAt = n.CreatedAt,
            UpdatedAt = n.UpdatedAt
        });
    }
}
