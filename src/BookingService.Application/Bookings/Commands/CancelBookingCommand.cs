using MediatR;

namespace BookingService.Application.Bookings.Commands;

public sealed record CancelBookingCommand(Guid Id) : IRequest;