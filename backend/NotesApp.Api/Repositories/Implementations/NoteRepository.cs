using Dapper;
using NotesApp.Api.Data;
using NotesApp.Api.Models.Entities;
using NotesApp.Api.Repositories.Interfaces;

namespace NotesApp.Api.Repositories.Implementations;

public class NoteRepository : INoteRepository
{
    private readonly SqlConnectionFactory _connectionFactory;

    public NoteRepository(SqlConnectionFactory connectionFactory)
    {
        _connectionFactory = connectionFactory;
    }

    public async Task<IEnumerable<Note>> GetAllByUserIdAsync(Guid userId)
    {
        const string sql = @"
            SELECT *
            FROM Notes
            WHERE UserId = @UserId
              AND IsDeleted = 0
            ORDER BY CreatedAt DESC;";

        using var connection = _connectionFactory.CreateConnection();

        return await connection.QueryAsync<Note>(sql, new
        {
            UserId = userId
        });
    }

    public async Task<Note?> GetByIdAsync(Guid id)
    {
        const string sql = @"
            SELECT *
            FROM Notes
            WHERE Id = @Id
              AND IsDeleted = 0;";

        using var connection = _connectionFactory.CreateConnection();

        return await connection.QueryFirstOrDefaultAsync<Note>(
            sql,
            new { Id = id });
    }

    public async Task CreateAsync(Note note)
    {
        const string sql = @"
            INSERT INTO Notes
(
    Id,
    UserId,
    Title,
    Content,
    CreatedAt,
    UpdatedAt,
    IsDeleted
)
VALUES
(
    @Id,
    @UserId,
    @Title,
    @Content,
    @CreatedAt,
    @UpdatedAt,
    @IsDeleted
);";

        using var connection = _connectionFactory.CreateConnection();

        await connection.ExecuteAsync(sql, note);
    }

    public async Task UpdateAsync(Note note)
{
    const string sql = @"
        UPDATE Notes
        SET
            Title = @Title,
            Content = @Content,
            UpdatedAt = @UpdatedAt
        WHERE Id = @Id
          AND IsDeleted = 0;";

    using var connection = _connectionFactory.CreateConnection();

    await connection.ExecuteAsync(sql, note);
}

    public async Task DeleteAsync(Guid id)
{
    const string sql = @"
        UPDATE Notes
        SET
            IsDeleted = 1,
            UpdatedAt = @UpdatedAt
        WHERE Id = @Id
          AND IsDeleted = 0;";

    using var connection = _connectionFactory.CreateConnection();

    await connection.ExecuteAsync(sql, new
    {
        Id = id,
        UpdatedAt = DateTime.UtcNow
    });
}
}
