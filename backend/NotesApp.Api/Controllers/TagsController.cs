using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NotesApp.Api.Extensions;
using NotesApp.Api.Models.Entities;
using NotesApp.Api.Models.Requests;
using NotesApp.Api.Models.Responses;
using NotesApp.Api.Services.Interfaces;

namespace NotesApp.Api.Controllers;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class TagsController : ControllerBase
{
    private readonly ITagService _tagService;

    public TagsController(ITagService tagService)
    {
        _tagService = tagService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var userId = User.GetUserId();

        var tags = await _tagService.GetAllAsync(userId);

        return Ok(ApiResponse<IEnumerable<Tag>>.Ok(
            tags,
            "Tags retrieved successfully."));
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var userId = User.GetUserId();

        var tag = await _tagService.GetByIdAsync(id, userId);

        return Ok(ApiResponse<Tag>.Ok(
            tag,
            "Tag retrieved successfully."));
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateTagRequest request)
    {
        var userId = User.GetUserId();

        var tag = await _tagService.CreateAsync(userId, request);

        return CreatedAtAction(
            nameof(GetById),
            new { id = tag.Id },
            ApiResponse<Tag>.Ok(tag, "Tag created successfully."));
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Update(
        Guid id,
        [FromBody] UpdateTagRequest request)
    {
        var userId = User.GetUserId();

        var tag = await _tagService.UpdateAsync(id, userId, request);

        return Ok(ApiResponse<Tag>.Ok(
            tag,
            "Tag updated successfully."));
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var userId = User.GetUserId();

        await _tagService.DeleteAsync(id, userId);

        return Ok(ApiResponse<object>.Ok(
            null,
            "Tag deleted successfully."));
    }
}
