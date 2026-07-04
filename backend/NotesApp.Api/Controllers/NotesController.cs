using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NotesApp.Api.Extensions;
using NotesApp.Api.Models.Requests;
using NotesApp.Api.Models.Responses;
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

        return Ok(ApiResponse<IEnumerable<NoteResponse>>.Ok(
            notes,
            "Notes retrieved successfully."));
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var userId = User.GetUserId();

        var note = await _noteService.GetByIdAsync(id, userId);

        return Ok(ApiResponse<NoteResponse>.Ok(
            note,
            "Note retrieved successfully."));
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateNoteRequest request)
    {
        var userId = User.GetUserId();

        await _noteService.CreateAsync(userId, request);

        return Created(string.Empty, ApiResponse<object>.Ok(
            new
            {
                Title = request.Title,
                Content = request.Content
            },
            "Note created successfully."));
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Update(Guid id, [FromBody] UpdateNoteRequest request)
    {
        var userId = User.GetUserId();

        await _noteService.UpdateAsync(id, userId, request);

        return Ok(ApiResponse<object>.Ok(
            new
            {
                Title = request.Title,
                Content = request.Content
            },
            "Note updated successfully."));
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var userId = User.GetUserId();

        await _noteService.DeleteAsync(id, userId);

        return Ok(ApiResponse<object>.Ok(
            null,
            "Note deleted successfully."));
    }

    [HttpGet("search")]
    public async Task<IActionResult> Search([FromQuery] NoteQueryRequest request)
    {
        var userId = User.GetUserId();

        var notes = await _noteService.SearchAsync(userId, request);

        return Ok(ApiResponse<IEnumerable<NoteResponse>>.Ok(
            notes,
            "Notes retrieved successfully."));
    }
}
