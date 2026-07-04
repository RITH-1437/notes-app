using System.Text;
using Dapper;
using NotesApp.Api.Data;
using NotesApp.Api.Models.Entities;
using NotesApp.Api.Models.Requests;
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
SELECT
    n.Id,
    n.UserId,
    n.TagId,
    t.Name AS TagName,
    n.Title,
    n.Content,
    n.CreatedAt,
    n.UpdatedAt,
    n.IsDeleted
FROM Notes n
LEFT JOIN Tags t
    ON n.TagId = t.Id
WHERE
    n.UserId = @UserId
    AND n.IsDeleted = 0
ORDER BY n.CreatedAt DESC;";

        using var connection = _connectionFactory.CreateConnection();

        return await connection.QueryAsync<Note>(sql, new
        {
            UserId = userId
        });
    }

    public async Task<IEnumerable<Note>> SearchAsync(
        Guid userId,
        NoteQueryRequest request)
    {
        var sql = new StringBuilder(@"
SELECT
    n.Id,
    n.UserId,
    n.TagId,
    t.Name AS TagName,
    n.Title,
    n.Content,
    n.CreatedAt,
    n.UpdatedAt,
    n.IsDeleted
FROM Notes n
LEFT JOIN Tags t
    ON n.TagId = t.Id
WHERE
    n.UserId = @UserId
    AND n.IsDeleted = 0
");

        var parameters = new DynamicParameters();

        parameters.Add("UserId", userId);

        if (!string.IsNullOrWhiteSpace(request.Search))
        {
            var search = EscapeLikePattern(request.Search.Trim());

            sql.Append(@"
AND
(
    n.Title LIKE @Search
    OR
    n.Content LIKE @Search
)");

            parameters.Add("Search", $"%{search}%");
        }

        if (!string.IsNullOrWhiteSpace(request.Title))
        {
            var title = EscapeLikePattern(request.Title.Trim());

            sql.Append(@"
AND
    n.Title LIKE @Title");

            parameters.Add("Title", $"%{title}%");
        }

        if (request.TagId.HasValue)
        {
            sql.Append(@"
AND
    n.TagId = @TagId");

            parameters.Add("TagId", request.TagId);
        }

        string orderBy = request.SortBy?.ToLower() switch
        {
            "title" => "n.Title",
            "updatedat" => "n.UpdatedAt",
            _ => "n.CreatedAt"
        };

        string direction = request.Descending ? "DESC" : "ASC";

        sql.Append($@"
ORDER BY {orderBy} {direction}, n.Id {direction};");

        using var connection = _connectionFactory.CreateConnection();

        return await connection.QueryAsync<Note>(
            sql.ToString(),
            parameters);
    }

    private static string EscapeLikePattern(string value)
    {
        return value
            .Replace("[", "[[]")
            .Replace("%", "[%]")
            .Replace("_", "[_]");
    }

    public async Task<Note?> GetByIdAsync(Guid id)
    {
        const string sql = @"
SELECT
    n.Id,
    n.UserId,
    n.TagId,
    t.Name AS TagName,
    n.Title,
    n.Content,
    n.CreatedAt,
    n.UpdatedAt,
    n.IsDeleted
FROM Notes n
LEFT JOIN Tags t
    ON n.TagId = t.Id
WHERE
    n.Id = @Id
    AND n.IsDeleted = 0;";

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
    TagId,
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
    @TagId,
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
    TagId = @TagId,
    Title = @Title,
    Content = @Content,
    UpdatedAt = @UpdatedAt
WHERE
    Id = @Id
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
WHERE
    Id = @Id
    AND IsDeleted = 0;";

        using var connection = _connectionFactory.CreateConnection();

        await connection.ExecuteAsync(sql, new
        {
            Id = id,
            UpdatedAt = DateTime.UtcNow
        });
    }
}
