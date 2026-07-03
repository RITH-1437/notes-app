using NotesApp.Api.Models.Entities;
using NotesApp.Api.Models.Requests;
using NotesApp.Api.Models.Responses;
using NotesApp.Api.Repositories.Interfaces;
using NotesApp.Api.Services.Interfaces;

namespace NotesApp.Api.Services.Implementations;

public class AuthService : IAuthService
{
    private readonly IUserRepository _userRepository;
    private readonly IRefreshTokenRepository _refreshTokenRepository;
    private readonly IPasswordService _passwordService;
    private readonly IJwtService _jwtService;

    public AuthService(
        IUserRepository userRepository,
        IRefreshTokenRepository refreshTokenRepository,
        IPasswordService passwordService,
        IJwtService jwtService)
    {
        _userRepository = userRepository;
        _refreshTokenRepository = refreshTokenRepository;
        _passwordService = passwordService;
        _jwtService = jwtService;
    }

    public async Task<AuthResponse> RegisterAsync(RegisterRequest request)
    {
        var existingEmail = await _userRepository.GetByEmailAsync(request.Email);

        if (existingEmail != null)
        {
            return new AuthResponse
            {
                Success = false,
                Message = "Email already exists."
            };
        }

        var existingUsername = await _userRepository.GetByUsernameAsync(request.Username);

        if (existingUsername != null)
        {
            return new AuthResponse
            {
                Success = false,
                Message = "Username already exists."
            };
        }

        var user = new User
        {
            Id = Guid.NewGuid(),
            Username = request.Username,
            FullName = request.FullName,
            Email = request.Email,
            PasswordHash = _passwordService.HashPassword(request.Password),
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = null,
            IsDeleted = false
        };

        await _userRepository.CreateAsync(user);

        var accessToken = _jwtService.GenerateAccessToken(user);
        var refreshToken = _jwtService.GenerateRefreshToken();

        var refreshTokenEntity = new RefreshToken
        {
            Id = Guid.NewGuid(),
            UserId = user.Id,
            Token = refreshToken,
            CreatedAt = DateTime.UtcNow,
            ExpiresAt = DateTime.UtcNow.AddDays(7),
            RevokedAt = null
        };

        await _refreshTokenRepository.SaveAsync(refreshTokenEntity);

        return new AuthResponse
        {
            Success = true,
            Message = "Registration successful.",
            AccessToken = accessToken,
            RefreshToken = refreshToken,
            ExpiresAt = refreshTokenEntity.ExpiresAt
        };
    }

    public async Task<AuthResponse> LoginAsync(LoginRequest request)
    {
        var user = await _userRepository.GetByEmailAsync(request.Email);

        if (user == null)
        {
            return new AuthResponse
            {
                Success = false,
                Message = "Invalid email or password."
            };
        }

        var isPasswordValid = _passwordService.VerifyPassword(
            request.Password,
            user.PasswordHash);

        if (!isPasswordValid)
        {
            return new AuthResponse
            {
                Success = false,
                Message = "Invalid email or password."
            };
        }

        var accessToken = _jwtService.GenerateAccessToken(user);
        var refreshToken = _jwtService.GenerateRefreshToken();

        var refreshTokenEntity = new RefreshToken
        {
            Id = Guid.NewGuid(),
            UserId = user.Id,
            Token = refreshToken,
            CreatedAt = DateTime.UtcNow,
            ExpiresAt = DateTime.UtcNow.AddDays(7),
            RevokedAt = null
        };

        await _refreshTokenRepository.SaveAsync(refreshTokenEntity);

        return new AuthResponse
        {
            Success = true,
            Message = "Login successful.",
            AccessToken = accessToken,
            RefreshToken = refreshToken,
            ExpiresAt = refreshTokenEntity.ExpiresAt
        };
    }

    public async Task<AuthResponse> RefreshTokenAsync(RefreshTokenRequest request)
    {
        var storedToken = await _refreshTokenRepository.GetByTokenAsync(request.RefreshToken);

        if (storedToken == null)
        {
            return new AuthResponse
            {
                Success = false,
                Message = "Invalid refresh token."
            };
        }

        if (storedToken.RevokedAt != null)
        {
            return new AuthResponse
            {
                Success = false,
                Message = "Refresh token has been revoked."
            };
        }

        if (storedToken.ExpiresAt <= DateTime.UtcNow)
        {
            return new AuthResponse
            {
                Success = false,
                Message = "Refresh token has expired."
            };
        }

        var user = await _userRepository.GetByIdAsync(storedToken.UserId);

        if (user == null)
        {
            return new AuthResponse
            {
                Success = false,
                Message = "User not found."
            };
        }

        await _refreshTokenRepository.RevokeAsync(storedToken.Id);

        var newAccessToken = _jwtService.GenerateAccessToken(user);
        var newRefreshToken = _jwtService.GenerateRefreshToken();

        var refreshTokenEntity = new RefreshToken
        {
            Id = Guid.NewGuid(),
            UserId = user.Id,
            Token = newRefreshToken,
            CreatedAt = DateTime.UtcNow,
            ExpiresAt = DateTime.UtcNow.AddDays(7),
            RevokedAt = null
        };

        await _refreshTokenRepository.SaveAsync(refreshTokenEntity);

        return new AuthResponse
        {
            Success = true,
            Message = "Token refreshed successfully.",
            AccessToken = newAccessToken,
            RefreshToken = newRefreshToken,
            ExpiresAt = refreshTokenEntity.ExpiresAt
        };
    }

    public async Task LogoutAsync(string refreshToken)
    {
        var storedToken = await _refreshTokenRepository.GetByTokenAsync(refreshToken);

        if (storedToken == null)
        {
            return;
        }

        await _refreshTokenRepository.RevokeAsync(storedToken.Id);
    }
}