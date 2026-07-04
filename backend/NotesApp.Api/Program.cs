using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using NotesApp.Api.Configurations;
using NotesApp.Api.Data;
using NotesApp.Api.Services.Implementations;
using NotesApp.Api.Services.Interfaces;
using NotesApp.Api.Repositories.Interfaces;
using NotesApp.Api.Repositories.Implementations;
using Microsoft.OpenApi.Models;
using FluentValidation;
using FluentValidation.AspNetCore;
using NotesApp.Api.Middleware;

var builder = WebApplication.CreateBuilder(args);

// ==============================
// Configuration
// ==============================

builder.Services.Configure<DatabaseSettings>(
    builder.Configuration.GetSection("ConnectionStrings"));

builder.Services.Configure<JwtSettings>(
    builder.Configuration.GetSection("Jwt"));

// Read JWT settings
var jwtSettings = builder.Configuration
    .GetSection("Jwt")
    .Get<JwtSettings>()!;

// ==============================
// Services
// ==============================

builder.Services.AddControllers();
builder.Services.AddFluentValidationAutoValidation();

builder.Services.AddValidatorsFromAssemblyContaining<Program>();

builder.Services.AddSingleton<SqlConnectionFactory>();
builder.Services.AddScoped<IPasswordService, PasswordService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IRefreshTokenRepository, RefreshTokenRepository>();
builder.Services.AddScoped<INoteRepository, NoteRepository>();
builder.Services.AddScoped<IJwtService, JwtService>();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<INoteService, NoteService>();
builder.Services.AddScoped<ITagRepository, TagRepository>();
builder.Services.AddScoped<ITagService, TagService>();
builder.Services.AddEndpointsApiExplorer();


builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "NotesApp API",
        Version = "v1",
        Description = "REST API for NotesApp"
    });

    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        Scheme = "bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "Enter JWT token. Example: Bearer eyJhbGciOiJIUzI1Ni..."
    });

    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            Array.Empty<string>()
        }
    });
});


// Authentication
builder.Services
    .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,

            ValidIssuer = jwtSettings.Issuer,
            ValidAudience = jwtSettings.Audience,

            IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(jwtSettings.Secret))
        };
    });

// Authorization
builder.Services.AddAuthorization();

// ==============================
// Build
// ==============================

var app = builder.Build();

// ==============================
// Middleware
// ==============================

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// app.UseHttpsRedirection();

app.UseMiddleware<ExceptionMiddleware>();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
