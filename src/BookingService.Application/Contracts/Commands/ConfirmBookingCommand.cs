using MediatR;

namespace BookingService.Application.Contracts.Commands;

public sealed record ConfirmBookingCommand(Guid Id) : IRequest<Unit>;