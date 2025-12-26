using MediatR;

namespace BookingService.Application.Contracts.Queries;

public sealed record GetBookingQuery(Guid Id) : IRequest<BookingResponse>;