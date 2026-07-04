using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NotesApp.Api.Extensions;
using NotesApp.Api.Models.Requests;
using NotesApp.Api.Services.Interfaces;

namespace NotesApp.Api.Controllers;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class NotesController : ControllerBase
{
    private readonly INoteService _noteService;

    public NotesController(INoteService noteService)
    {
        _noteService = noteService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var userId = User.GetUserId();

        var notes = await _noteService.GetAllAsync(userId);

        return Ok(notes);
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var userId = User.GetUserId();

        var note = await _noteService.GetByIdAsync(id, userId);

        return Ok(note);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateNoteRequest request)
    {
        var userId = User.GetUserId();

        await _noteService.CreateAsync(userId, request);

        return Created(string.Empty, new
        {
            Message = "Note created successfully.",
            Title = request.Title,
            Content = request.Content
        });
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Update(Guid id, [FromBody] UpdateNoteRequest request)
    {
        var userId = User.GetUserId();

        await _noteService.UpdateAsync(id, userId, request);

        return Ok(new
        {
            Message = "Note updated successfully.",
            Title = request.Title,
            Content = request.Content
        });
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var userId = User.GetUserId();

        await _noteService.DeleteAsync(id, userId);

        return Ok(new
        {
            Message = "Note deleted successfully."
        });
    }

    [HttpGet("search")]
    public async Task<IActionResult> Search([FromQuery] NoteQueryRequest request)
    {
        var userId = User.GetUserId();

        var notes = await _noteService.SearchAsync(userId, request);

        return Ok(notes);
    }
}
