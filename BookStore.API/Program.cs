using BookStore.API.Extensions;
using BookStore.Application.Services;
using BookStore.CoreDomain.Abstractions;
using BookStore.CoreDomain.Enums;
using BookStore.DataAccess;
using BookStore.DataAccess.Repositories;
using BookStore.Infrastructure.Authentification;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<BookStoreDbContext>(
    options =>
    {
        options.UseNpgsql(builder.Configuration.GetConnectionString(nameof(BookStoreDbContext)));
    });
builder.Services.Configure<JwtOptions>(builder.Configuration.GetSection(nameof(JwtOptions)));
builder.Services.AddApiAuthentication(
    builder.Configuration,
    builder.Services.BuildServiceProvider().GetRequiredService<IOptions<JwtOptions>>() // Получаем JwtOptions из DI-контейнера
);


builder.Services.Configure<BookStore.DataAccess.AuthorizationOptions>(builder.Configuration.GetSection(nameof(BookStore.DataAccess.AuthorizationOptions)));

builder.Services.AddScoped<IBooksService, BooksService>();
builder.Services.AddScoped<IBooksRepository, BooksRepository>();

builder.Services.AddScoped<IJwtProvider, JwtProvider >();
builder.Services.AddScoped<IPasswordHasher, PasswordHasher>();

builder.Services.AddScoped<IUsersRepository, UsersRepository>();
builder.Services.AddScoped<IUsersService, UsersService>();

builder.Services.AddScoped<IPermissionService, PermissionService>();

builder.Services.AddSingleton<IAuthorizationHandler, PermissionAuthorizationHandler>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();
//app.UseCookiePolicy(new CookiePolicyOptions
//{
//    MinimumSameSitePolicy = SameSiteMode.Strict,
//    HttpOnly = HttpOnlyPolicy.Always,
//    Secure = CookieSecurePolicy.Always
//});


app.MapControllers();
app.MapGet("get", () =>
{
    return Results.Ok("Ok");
}).RequirePermissions(Permission.Read);

app.MapPost("post", () =>
{
    return Results.Ok("Ok");
}).RequirePermissions(Permission.Create);


app.Run();
