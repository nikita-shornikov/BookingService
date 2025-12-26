using BookingService.Application.Contracts.Commands;
using BookingService.Application.Interfaces;
using MediatR;

namespace BookingService.Application.Handlers;

public sealed class CompleteBookingHandler : IRequestHandler<CompleteBookingCommand, Unit>
{
    private readonly IBookingService _bookingService;

    public CompleteBookingHandler(IBookingService bookingService)
    {
        _bookingService = bookingService;
    }

    public async Task<Unit> Handle(CompleteBookingCommand request, CancellationToken cancellationToken)
    {
        await _bookingService.CompleteAsync(request.Id, cancellationToken);
        return Unit.Value;
    }
}