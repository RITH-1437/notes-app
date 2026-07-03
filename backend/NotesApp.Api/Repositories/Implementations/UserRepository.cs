using Dapper;
using NotesApp.Api.Data;
using NotesApp.Api.Models.Entities;
using NotesApp.Api.Repositories.Interfaces;

namespace NotesApp.Api.Repositories.Implementations;

public class UserRepository : IUserRepository
{
    private readonly SqlConnectionFactory _connectionFactory;

    public UserRepository(SqlConnectionFactory connectionFactory)
    {
        _connectionFactory = connectionFactory;
    }

    public async Task<User?> GetByIdAsync(Guid id)
    {
        using var connection = _connectionFactory.CreateConnection();

        const string sql = @"
            SELECT *
            FROM Users
            WHERE Id = @Id
              AND IsDeleted = 0;";

        return await connection.QueryFirstOrDefaultAsync<User>(sql, new { Id = id });
    }

    public async Task<User?> GetByEmailAsync(string email)
    {
        using var connection = _connectionFactory.CreateConnection();

        const string sql = @"
            SELECT *
            FROM Users
            WHERE Email = @Email
              AND IsDeleted = 0;";

        return await connection.QueryFirstOrDefaultAsync<User>(sql, new { Email = email });
    }

    public async Task<User?> GetByUsernameAsync(string username)
    {
        using var connection = _connectionFactory.CreateConnection();

        const string sql = @"
            SELECT *
            FROM Users
            WHERE Username = @Username
              AND IsDeleted = 0;";

        return await connection.QueryFirstOrDefaultAsync<User>(sql, new { Username = username });
    }

    public async Task<Guid> CreateAsync(User user)
    {
        using var connection = _connectionFactory.CreateConnection();

        const string sql = @"
            INSERT INTO Users
            (
                Id,
                Username,
                FullName,
                Email,
                PasswordHash,
                CreatedAt,
                UpdatedAt,
                IsDeleted
            )
            VALUES
            (
                @Id,
                @Username,
                @FullName,
                @Email,
                @PasswordHash,
                @CreatedAt,
                @UpdatedAt,
                @IsDeleted
            );";

        await connection.ExecuteAsync(sql, user);

        return user.Id;
    }
}