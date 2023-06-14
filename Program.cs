using ChatGpt_back.Context;
using ChatGpt_back.Repository;
using ChatGpt_back.Service;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckl
string serverConnection = builder.Configuration.GetConnectionString("localServerConnection");
builder.Services.AddDbContext<ChatDbContext>(u => u.UseSqlServer(serverConnection));
builder.Services.AddScoped<IChatService, ChatService>();
builder.Services.AddScoped<IChatRepo, ChatRepo>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors(c =>
{
    c.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin();
});
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
