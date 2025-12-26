using BookingService.Application.Contracts.Commands;
using BookingService.Application.Interfaces;
using MediatR;

namespace BookingService.Application.Handlers;

public sealed class ConfirmBookingHandler : IRequestHandler<ConfirmBookingCommand, Unit>
{
    private readonly IBookingService _bookingService;

    public ConfirmBookingHandler(IBookingService bookingService)
    {
        _bookingService = bookingService;
    }

    public async Task<Unit> Handle(ConfirmBookingCommand request, CancellationToken cancellationToken)
    {
        await _bookingService.ConfirmAsync(request.Id, cancellationToken);
        return Unit.Value;
    }
}