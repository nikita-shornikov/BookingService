using BookingService.Application.Contracts;
using BookingService.Application.Contracts.Queries;
using BookingService.Application.Interfaces;
using MediatR;

namespace BookingService.Application.Handlers;

public sealed class GetBookingHandler : IRequestHandler<GetBookingQuery, BookingResponse>
{
    private readonly IBookingService _bookingService;

    public GetBookingHandler(IBookingService bookingService)
    {
        _bookingService = bookingService;
    }

    public Task<BookingResponse> Handle(GetBookingQuery request, CancellationToken cancellationToken)
    {
        return _bookingService.GetAsync(request.Id, cancellationToken);
    }
}