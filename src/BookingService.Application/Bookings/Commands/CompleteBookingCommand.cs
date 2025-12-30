using MediatR;

namespace BookingService.Application.Bookings.Commands;

public sealed record CompleteBookingCommand(Guid Id) : IRequest;