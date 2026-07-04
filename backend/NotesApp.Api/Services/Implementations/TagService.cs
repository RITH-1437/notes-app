using NotesApp.Api.Exceptions;
using NotesApp.Api.Models.Entities;
using NotesApp.Api.Models.Requests;
using NotesApp.Api.Repositories.Interfaces;
using NotesApp.Api.Services.Interfaces;

namespace NotesApp.Api.Services.Implementations;

public class TagService : ITagService
{
    private readonly ITagRepository _tagRepository;

    public TagService(ITagRepository tagRepository)
    {
        _tagRepository = tagRepository;
    }

    public async Task<IEnumerable<Tag>> GetAllAsync(Guid userId)
    {
        return await _tagRepository.GetAllByUserIdAsync(userId);
    }

    public async Task<Tag> GetByIdAsync(Guid id, Guid userId)
    {
        var tag = await _tagRepository.GetByIdAsync(id);

        if (tag == null)
            throw new NotFoundException("Tag not found.");

        if (tag.UserId != userId)
            throw new ForbiddenException("You are not allowed to access this tag.");

        return tag;
    }

    public async Task<Tag> CreateAsync(Guid userId, CreateTagRequest request)
    {
        var existing = await _tagRepository.GetByNameAsync(userId, request.Name);

        if (existing != null)
            throw new BadRequestException("Tag already exists.");

        var tag = new Tag
        {
            Id = Guid.NewGuid(),
            UserId = userId,
            Name = request.Name,
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = null,
            IsDeleted = false
        };

        await _tagRepository.CreateAsync(tag);

        return tag;
    }

    public async Task<Tag> UpdateAsync(Guid id, Guid userId, UpdateTagRequest request)
    {
        var tag = await _tagRepository.GetByIdAsync(id);

        if (tag == null)
            throw new NotFoundException("Tag not found.");

        if (tag.UserId != userId)
            throw new ForbiddenException("You are not allowed to update this tag.");

        var duplicate = await _tagRepository.GetByNameAsync(userId, request.Name);

        if (duplicate != null && duplicate.Id != id)
            throw new BadRequestException("Tag name already exists.");

        tag.Name = request.Name;
        tag.UpdatedAt = DateTime.UtcNow;

        await _tagRepository.UpdateAsync(tag);

        return tag;
    }

    public async Task DeleteAsync(Guid id, Guid userId)
    {
        var tag = await _tagRepository.GetByIdAsync(id);

        if (tag == null)
            throw new NotFoundException("Tag not found.");

        if (tag.UserId != userId)
            throw new ForbiddenException("You are not allowed to delete this tag.");

        await _tagRepository.DeleteAsync(id);
    }
}
