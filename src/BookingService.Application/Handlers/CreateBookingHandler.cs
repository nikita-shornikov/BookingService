using BookingService.Application.Contracts;
using BookingService.Application.Interfaces;
using MediatR;

namespace BookingService.Application.Handlers;

public sealed class CreateBookingHandler : IRequestHandler<CreateBookingRequest, Guid>
{
    private readonly IBookingService _bookingService;

    public CreateBookingHandler(IBookingService bookingService)
    {
        _bookingService = bookingService;
    }

    public Task<Guid> Handle(CreateBookingRequest request, CancellationToken cancellationToken)
    {
        return _bookingService.CreateAsync(request, cancellationToken);
    }
}