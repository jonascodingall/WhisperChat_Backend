using Microsoft.EntityFrameworkCore;
using WhisperChat.ChatServer.Data;
using WhisperChat.ChatServer.Data.Repos;
using WhisperChat.ChatServer.Hubs;
using WhisperChat.ChatServer.Models;
using WhisperChat.ChatServer.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSignalR();

builder.Services.AddCors(options =>
{
    options.AddPolicy("reactApp", builder =>
    {
        builder.WithOrigins("http://localhost:5173")
            .AllowAnyHeader()
            .AllowAnyMethod()
            .AllowCredentials();
        
    });
});

builder.Services.AddDbContext<ChatContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddTransient<IRepository<MessageModel>, Repository<ChatContext, MessageModel>>();
builder.Services.AddTransient<IMessageService, MessageService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapHub<ChatHub>("chat-hub");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseCors("reactApp");

app.Run();
