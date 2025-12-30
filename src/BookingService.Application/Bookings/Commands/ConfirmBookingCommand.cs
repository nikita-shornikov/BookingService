using MediatR;

namespace BookingService.Application.Bookings.Commands;

public sealed record ConfirmBookingCommand(Guid Id) : IRequest;