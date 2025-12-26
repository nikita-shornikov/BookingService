using BookingService.Domain.Enums;

namespace BookingService.Application.Contracts;

public sealed record BookingResponse(
    Guid Id,
    Guid ResourceId,
    Guid UserId,
    DateTime StartUtc,
    DateTime EndUtc,
    BookingStatus Status
    );