using BookingService.Application.Contracts;
using MediatR;

namespace BookingService.Application.Bookings.Commands;

public sealed record CreateBookingCommand(CreateBookingRequest Request) : IRequest<Guid>;