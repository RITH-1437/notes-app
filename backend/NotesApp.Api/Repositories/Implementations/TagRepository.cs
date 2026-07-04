using Dapper;
using NotesApp.Api.Data;
using NotesApp.Api.Models.Entities;
using NotesApp.Api.Repositories.Interfaces;

namespace NotesApp.Api.Repositories.Implementations;

public class TagRepository : ITagRepository
{
    private readonly SqlConnectionFactory _connectionFactory;

    public TagRepository(SqlConnectionFactory connectionFactory)
    {
        _connectionFactory = connectionFactory;
    }

    public async Task<IEnumerable<Tag>> GetAllByUserIdAsync(Guid userId)
    {
        const string sql = @"
            SELECT *
            FROM Tags
            WHERE UserId = @UserId
              AND IsDeleted = 0
            ORDER BY Name;";

        using var connection = _connectionFactory.CreateConnection();

        return await connection.QueryAsync<Tag>(sql, new { UserId = userId });
    }

    public async Task<Tag?> GetByIdAsync(Guid id)
    {
        const string sql = @"
            SELECT *
            FROM Tags
            WHERE Id = @Id
              AND IsDeleted = 0;";

        using var connection = _connectionFactory.CreateConnection();

        return await connection.QueryFirstOrDefaultAsync<Tag>(sql, new { Id = id });
    }

    public async Task<Tag?> GetByNameAsync(Guid userId, string name)
    {
        const string sql = @"
            SELECT *
            FROM Tags
            WHERE UserId = @UserId
              AND Name = @Name
              AND IsDeleted = 0;";

        using var connection = _connectionFactory.CreateConnection();

        return await connection.QueryFirstOrDefaultAsync<Tag>(
            sql,
            new
            {
                UserId = userId,
                Name = name
            });
    }

    public async Task CreateAsync(Tag tag)
    {
        const string sql = @"
            INSERT INTO Tags
            (
                Id,
                UserId,
                Name,
                CreatedAt,
                UpdatedAt,
                IsDeleted
            )
            VALUES
            (
                @Id,
                @UserId,
                @Name,
                @CreatedAt,
                @UpdatedAt,
                @IsDeleted
            );";

        using var connection = _connectionFactory.CreateConnection();

        await connection.ExecuteAsync(sql, tag);
    }

    public async Task UpdateAsync(Tag tag)
    {
        const string sql = @"
            UPDATE Tags
            SET
                Name = @Name,
                UpdatedAt = @UpdatedAt
            WHERE Id = @Id
              AND IsDeleted = 0;";

        using var connection = _connectionFactory.CreateConnection();

        await connection.ExecuteAsync(sql, tag);
    }

    public async Task DeleteAsync(Guid id)
    {
        const string sql = @"
            UPDATE Tags
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
