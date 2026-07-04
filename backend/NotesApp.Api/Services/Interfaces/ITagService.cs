using NotesApp.Api.Models.Requests;
using NotesApp.Api.Models.Entities;

namespace NotesApp.Api.Services.Interfaces;

public interface ITagService
{
    Task<IEnumerable<Tag>> GetAllAsync(Guid userId);

    Task<Tag> GetByIdAsync(Guid id, Guid userId);

    Task<Tag> CreateAsync(Guid userId, CreateTagRequest request);

    Task<Tag> UpdateAsync(Guid id, Guid userId, UpdateTagRequest request);

    Task DeleteAsync(Guid id, Guid userId);
}
