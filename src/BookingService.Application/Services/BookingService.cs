using BookingService.Application.Contracts;
using BookingService.Application.Interfaces;
using BookingService.Domain.Entities;
using BookingService.Domain.Exceptions;
using BookingService.Domain.Enums;

namespace BookingService.Application.Services;

public sealed class BookingService : IBookingService
{
    private readonly Dictionary<Guid, Booking> _store = new();

    public Task<Guid> CreateAsync(CreateBookingRequest request, CancellationToken cancellationToken = default)
    {
        var booking = new Booking(
            request.ResourceId,
            request.UserId,
            request.StartUtc,
            request.EndUtc);

        _store[booking.Id] = booking;
        return Task.FromResult(booking.Id);
    }

    public Task CancelAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var booking = GetBooking(id);
        booking.Cancel();
        return Task.CompletedTask;
    }

    public Task ConfirmAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var booking = GetBooking(id);
        booking.Confirm();
        return Task.CompletedTask;
    }

    public Task CompleteAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var booking = GetBooking(id);
        booking.Complete();
        return Task.CompletedTask;
    }

    public Task<BookingResponse> GetAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var booking = GetBooking(id);

        var response = new BookingResponse(
            booking.Id,
            booking.ResourceId,
            booking.UserId,
            booking.StartUtc,
            booking.EndUtc,
            booking.Status);

        return Task.FromResult(response);
    }

    private Booking GetBooking(Guid id)
    {
        if (!_store.TryGetValue(id, out var booking))
            throw new DomainException("Booking not found");

        return booking;
    }
}