using MediatR;

namespace BookingService.Application.Contracts.Commands;

public sealed record CancelBookingCommand(Guid Id) : IRequest<Unit>;