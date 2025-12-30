using BookingService.Application.Interfaces;
using MediatR;

namespace BookingService.Application.Bookings.Commands;

public sealed class CreateBookingCommandHandler : IRequestHandler<CreateBookingCommand, Guid>
{
    private readonly IBookingService _bookingService;

    public CreateBookingCommandHandler(IBookingService bookingService)
    {
        _bookingService = bookingService;
    }

    public Task<Guid> Handle(CreateBookingCommand request, CancellationToken cancellationToken)
    {
        return _bookingService.CreateAsync(request.Request, cancellationToken);
    }
}