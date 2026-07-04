using NotesApp.Api.Models.Entities;

namespace NotesApp.Api.Repositories.Interfaces;

public interface ITagRepository
{
    Task<IEnumerable<Tag>> GetAllByUserIdAsync(Guid userId);

    Task<Tag?> GetByIdAsync(Guid id);

    Task<Tag?> GetByNameAsync(Guid userId, string name);

    Task CreateAsync(Tag tag);

    Task UpdateAsync(Tag tag);

    Task DeleteAsync(Guid id);
}
