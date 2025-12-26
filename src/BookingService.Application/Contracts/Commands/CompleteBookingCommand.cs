using MediatR;

namespace BookingService.Application.Contracts.Commands;

public sealed record CompleteBookingCommand(Guid Id) : IRequest<Unit>;