using BookingService.Application.Contracts.Commands;
using BookingService.Application.Interfaces;
using MediatR;

namespace BookingService.Application.Handlers;

public sealed class CancelBookingHandler : IRequestHandler<CancelBookingCommand, Unit>
{
    private readonly IBookingService _bookingService;

    public CancelBookingHandler(IBookingService bookingService)
    {
        _bookingService = bookingService;
    }

    public async Task<Unit> Handle(CancelBookingCommand request, CancellationToken cancellationToken)
    {
        await _bookingService.CancelAsync(request.Id, cancellationToken);
        return Unit.Value;
    }
}