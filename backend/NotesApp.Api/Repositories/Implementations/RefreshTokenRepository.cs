using Dapper;
using NotesApp.Api.Data;
using NotesApp.Api.Models.Entities;
using NotesApp.Api.Repositories.Interfaces;

namespace NotesApp.Api.Repositories.Implementations;

public class RefreshTokenRepository : IRefreshTokenRepository
{
    private readonly SqlConnectionFactory _connectionFactory;

    public RefreshTokenRepository(SqlConnectionFactory connectionFactory)
    {
        _connectionFactory = connectionFactory;
    }

    public async Task SaveAsync(RefreshToken refreshToken)
    {
        using var connection = _connectionFactory.CreateConnection();

        const string sql = @"
INSERT INTO RefreshTokens
(
    Id,
    UserId,
    Token,
    ExpiresAt,
    CreatedAt,
    RevokedAt
)
VALUES
(
    @Id,
    @UserId,
    @Token,
    @ExpiresAt,
    @CreatedAt,
    @RevokedAt
);";

        await connection.ExecuteAsync(sql, refreshToken);
    }

    public async Task<RefreshToken?> GetByTokenAsync(string token)
    {
        using var connection = _connectionFactory.CreateConnection();

        const string sql = @"
    SELECT *
    FROM RefreshTokens
    WHERE Token = @Token;";

        return await connection.QueryFirstOrDefaultAsync<RefreshToken>(
            sql,
            new { Token = token });
    }

    public async Task RevokeAsync(Guid id)
    {
        using var connection = _connectionFactory.CreateConnection();

        const string sql = @"
            UPDATE RefreshTokens
            SET RevokedAt = GETUTCDATE()
            WHERE Id = @Id;";

        await connection.ExecuteAsync(sql, new { Id = id });
    }
}
