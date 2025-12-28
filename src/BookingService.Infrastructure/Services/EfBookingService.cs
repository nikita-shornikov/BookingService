using BookingService.Application.Contracts;
using BookingService.Application.Interfaces;
using BookingService.Domain.Entities;
using BookingService.Domain.Exceptions;
using BookingService.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace BookingService.Infrastructure.Services;

public sealed class EfBookingService : IBookingService
{
    private readonly BookingDbContext _dbContext;

    public EfBookingService(BookingDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Guid> CreateAsync(CreateBookingRequest request, CancellationToken cancellationToken = default)
    {
        var booking = new Booking(
            request.ResourceId,
            request.UserId,
            request.StartUtc,
            request.EndUtc);

        await _dbContext.Bookings.AddAsync(booking, cancellationToken);
        await _dbContext.SaveChangesAsync(cancellationToken);

        return booking.Id;
    }

    public async Task CancelAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var booking = await GetBookingInternalAsync(id, cancellationToken);
        booking.Cancel();
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task ConfirmAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var booking = await GetBookingInternalAsync(id, cancellationToken);
        booking.Confirm();
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task CompleteAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var booking = await GetBookingInternalAsync(id, cancellationToken);
        booking.Complete();
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task<BookingResponse> GetAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var booking = await _dbContext.Bookings
            .FirstOrDefaultAsync(b => b.Id == id, cancellationToken);

        if (booking is null)
            throw new DomainException("Booking not found");

        return new BookingResponse(
            booking.Id,
            booking.ResourceId,
            booking.UserId,
            booking.StartUtc,
            booking.EndUtc,
            booking.Status);
    }

    private async Task<Booking> GetBookingInternalAsync(Guid id, CancellationToken cancellationToken)
    {
        var booking = await _dbContext.Bookings
            .FirstOrDefaultAsync(b => b.Id == id, cancellationToken);

        if (booking is null)
            throw new DomainException("Booking not found");

        return booking;
    }
}