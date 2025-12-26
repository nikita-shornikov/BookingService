namespace BookingService.Application.Contracts;

public sealed record CreateBookingRequest(
    Guid ResourceId,
    Guid UserId,
    DateTime StartUtc,
    DateTime EndUtc
    );