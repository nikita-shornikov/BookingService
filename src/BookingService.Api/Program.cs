using BookingService.Application.Interfaces;
using BookingService.Application.Services;
using MediatR;
using BookingServiceApiBookingService = BookingService.Application.Services.BookingService;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<IBookingService, BookingServiceApiBookingService>();

builder.Services.AddMediatR(typeof(IBookingService).Assembly);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();