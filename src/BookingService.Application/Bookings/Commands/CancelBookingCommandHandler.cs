using BookingService.Application.Interfaces;
using MediatR;

namespace BookingService.Application.Bookings.Commands;

public sealed class CancelBookingCommandHandler : IRequestHandler<CancelBookingCommand, Unit>
{
    private readonly IBookingService _bookingService;

    public CancelBookingCommandHandler(IBookingService bookingService)
    {
        _bookingService = bookingService;
    }

    public async Task<Unit> Handle(CancelBookingCommand request, CancellationToken cancellationToken)
    {
        await _bookingService.CancelAsync(request.Id, cancellationToken);
        return Unit.Value;
    }
}