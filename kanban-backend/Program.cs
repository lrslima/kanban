using System.Text;
using kanban_backed.Business.Configuration;
using kanban_backed.Business.Interfaces;
using kanban_backed.Business.Services;
using kanban_backed.Infra;
using kanban_backend.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add cors
builder.Services.AddCors(p => p.AddPolicy("corsapp", builder =>
{
    builder.WithOrigins("*").AllowAnyMethod().AllowAnyHeader();
}));

var configuration = builder.LoadConfiguration();

var authSettings = new AuthSettings();
configuration.GetSection("AuthSettings").Bind(authSettings);

var jwtSettings = new JwtSettings();
configuration.GetSection("Jwt").Bind(jwtSettings);

builder.Services.AddSingleton(authSettings);
builder.Services.AddSingleton(jwtSettings);

builder.Services.AddAppServices();

builder.Services.AddAppAuthentication(jwtSettings); 

builder.Services.AddAuthorization();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    var context = services.GetRequiredService<ApiContext>();
    context.Database.EnsureCreated();
    DbInitializer.Initialize(context);
}


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("corsapp");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseMiddleware<JwtMiddleware>();

app.Run();

