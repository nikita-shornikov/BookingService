using BookingService.Application.Contracts;
using BookingService.Application.Interfaces;
using MediatR;

namespace BookingService.Application.Bookings.Queries;

public sealed class GetBookingQueryHandler : IRequestHandler<GetBookingQuery, BookingResponse>
{
    private readonly IBookingService _bookingService;

    public GetBookingQueryHandler(IBookingService bookingService)
    {
        _bookingService = bookingService;
    }

    public Task<BookingResponse> Handle(GetBookingQuery request, CancellationToken cancellationToken)
    {
        return _bookingService.GetAsync(request.Id, cancellationToken);
    }
}