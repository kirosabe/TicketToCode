// Connection to database
using Microsoft.EntityFrameworkCore;
using TicketToCode.Core.Data;
using TicketToCode.Core.Services;

using TicketToCode.Api.Endpoints;
using TicketToCode.Api.Services;
using TicketToCode.Core.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowBlazorClient",
        policy => policy.WithOrigins("https://localhost:7075") 
                        .AllowAnyMethod()
                        .AllowAnyHeader()
                        .AllowCredentials());
});


// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
// Default mapping is /openapi/v1.json
builder.Services.AddOpenApi();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<EventService>();

// Add cookie authentication
builder.Services.AddAuthentication("Cookies")
    .AddCookie("Cookies", options =>
    {
        options.Cookie.Name = "auth";
        options.Cookie.HttpOnly = true;
        options.Cookie.SameSite = SameSiteMode.Strict;
    });

builder.Services.AddAuthorization();

var app = builder.Build();



// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();

    // Todo: consider scalar? https://youtu.be/Tx49o-5tkis?feature=shared
    app.UseSwaggerUI( options =>
    {
        options.SwaggerEndpoint("/openapi/v1.json", "v1");
        options.DefaultModelsExpandDepth(-1);
    });
}
app.UseCors("AllowBlazorClient");
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

// Map all endpoints
app.MapEndpoints<Program>();

app.Run();

