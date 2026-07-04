using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NotesApp.Api.Extensions;
using NotesApp.Api.Models.Requests;
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

        return Ok(tags);
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var userId = User.GetUserId();

        var tag = await _tagService.GetByIdAsync(id, userId);

        if (tag == null)
            return NotFound(new
            {
                Message = "Tag not found."
            });

        return Ok(tag);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateTagRequest request)
    {
        var userId = User.GetUserId();

        var tag = await _tagService.CreateAsync(userId, request);

        return CreatedAtAction(
            nameof(GetById),
            new { id = tag.Id },
            tag);
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Update(
        Guid id,
        [FromBody] UpdateTagRequest request)
    {
        var userId = User.GetUserId();

        var tag = await _tagService.UpdateAsync(id, userId, request);

        if (tag == null)
            return NotFound(new
            {
                Message = "Tag not found."
            });

        return Ok(new
        {
            Message = "Tag updated successfully.",
            Tag = tag
        });
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var userId = User.GetUserId();

        var deleted = await _tagService.DeleteAsync(id, userId);

        if (!deleted)
            return NotFound(new
            {
                Message = "Tag not found."
            });

        return Ok(new
        {
            Message = "Tag deleted successfully."
        });
    }
}
