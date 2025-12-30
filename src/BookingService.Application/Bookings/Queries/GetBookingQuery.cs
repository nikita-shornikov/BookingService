using BookingService.Application.Contracts;
using MediatR;

namespace BookingService.Application.Bookings.Queries;

public sealed record GetBookingQuery(Guid Id) : IRequest<BookingResponse>;