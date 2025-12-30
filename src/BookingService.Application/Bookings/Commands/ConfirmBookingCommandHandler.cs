using BookingService.Application.Interfaces;
using MediatR;

namespace BookingService.Application.Bookings.Commands;

public sealed class ConfirmBookingCommandHandler : IRequestHandler<ConfirmBookingCommand, Unit>
{
    private readonly IBookingService _bookingService;

    public ConfirmBookingCommandHandler(IBookingService bookingService)
    {
        _bookingService = bookingService;
    }

    public async Task<Unit> Handle(ConfirmBookingCommand request, CancellationToken cancellationToken)
    {
        await _bookingService.ConfirmAsync(request.Id, cancellationToken);
        return Unit.Value;
    }
}