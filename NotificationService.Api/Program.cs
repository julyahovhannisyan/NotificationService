using NotificationService.Api.Middleware;
using NotificationService.Api.Validators;
using NotificationService.Application.Factories;
using NotificationService.Application.Interfaces;
using NotificationService.Application.Services;
using NotificationService.Domain.Interfaces;
using NotificationService.Infrastructure.Data;
using NotificationService.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using FluentValidation;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<NotificationServiceDbContext>(options =>
    options.UseSqlite("Data Source=notificationservice.db"));

// Register concrete notification senders
builder.Services.AddScoped<INotificationSender, EmailSender>();
builder.Services.AddScoped<INotificationSender, SMSSender>();
builder.Services.AddScoped<INotificationSender, PushSender>();

builder.Services.AddScoped<INotificationRepository, NotificationRepository>();

builder.Services.AddScoped<INotificationFactory, NotificationFactory>();

// Register services
builder.Services.AddScoped<NotificationSenderService>();

// Add FluentValidation
builder.Services.AddValidatorsFromAssemblyContaining<NotificationRequestValidator>();

// Add Swagger and API configuration
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add Controllers
builder.Services.AddControllers();

var app = builder.Build();

// Configure middleware and routing
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<ExceptionHandlingMiddleware>();
app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthorization();
app.MapControllers();
app.Run();
