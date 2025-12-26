using BookingService.Domain.Enums;
using BookingService.Domain.Exceptions;

namespace BookingService.Domain.Entities;

public sealed class Booking
{
    public Guid Id { get; private set; }
    public Guid ResourceId { get; private set; }
    public Guid UserId { get; private set; }
    public DateTime StartUtc { get; private set; }
    public DateTime EndUtc { get; private set; }
    public BookingStatus Status { get; private set; }

    private Booking() { }

    public Booking(Guid resourceId, Guid userId, DateTime startUtc, DateTime endUtc)
    {
        if (resourceId == Guid.Empty) throw new DomainException("ResourceId is required.");
        if (userId == Guid.Empty) throw new DomainException("UserId is required.");
        if (startUtc >= endUtc) throw new DomainException("StartUtc must be earlier than EndUtc.");

        Id = Guid.NewGuid();
        ResourceId = resourceId;
        UserId = userId;
        StartUtc = DateTime.SpecifyKind(startUtc, DateTimeKind.Utc);
        EndUtc = DateTime.SpecifyKind(endUtc, DateTimeKind.Utc);
        Status = BookingStatus.Draft;
    }

    public void Confirm()
    {
        if (Status != BookingStatus.Draft)
            throw new DomainException($"Cannot confirm booking in status {Status}.");

        Status = BookingStatus.Confirmed;
    }

    public void Cancel()
    {
        if (Status == BookingStatus.Completed)
            throw new DomainException("Cannot cancel completed booking.");

        if (Status == BookingStatus.Cancelled)
            return;

        Status = BookingStatus.Cancelled;
    }

    public void Complete()
    {
        if (Status != BookingStatus.Confirmed)
            throw new DomainException($"Cannot complete booking in status {Status}.");

        Status = BookingStatus.Completed;
    }
}