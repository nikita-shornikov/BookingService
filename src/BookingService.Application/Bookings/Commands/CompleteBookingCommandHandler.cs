using BookingService.Application.Interfaces;
using MediatR;

namespace BookingService.Application.Bookings.Commands;

public sealed class CompleteBookingCommandHandler : IRequestHandler<CompleteBookingCommand, Unit>
{
    private readonly IBookingService _bookingService;

    public CompleteBookingCommandHandler(IBookingService bookingService)
    {
        _bookingService = bookingService;
    }

    public async Task<Unit> Handle(CompleteBookingCommand request, CancellationToken cancellationToken)
    {
        await _bookingService.CompleteAsync(request.Id, cancellationToken);
        return Unit.Value;
    }
}