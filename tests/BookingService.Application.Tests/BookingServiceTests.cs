using BookingService.Application.Contracts;
using BookingService.Application.Interfaces;
using BookingService.Domain.Enums;
using BookingService.Domain.Exceptions;
using Service = BookingService.Application.Services.BookingService;
using Xunit;

namespace BookingService.Application.Tests;

public sealed class BookingServiceTests
{
    [Fact]
    public async Task CreateAsync_creates_booking_and_returns_id()
    {
        var service = CreateService();

        var id = await service.CreateAsync(new CreateBookingRequest(
            Guid.NewGuid(),
            Guid.NewGuid(),
            DateTime.UtcNow.AddHours(1),
            DateTime.UtcNow.AddHours(2)));

        Assert.NotEqual(Guid.Empty, id);
    }

    [Fact]
    public async Task ConfirmAsync_changes_status()
    {
        var service = CreateService();

        var id = await service.CreateAsync(new CreateBookingRequest(
            Guid.NewGuid(),
            Guid.NewGuid(),
            DateTime.UtcNow.AddHours(1),
            DateTime.UtcNow.AddHours(2)));

        await service.ConfirmAsync(id);
        var booking = await service.GetAsync(id);

        Assert.Equal(BookingStatus.Confirmed, booking.Status);
    }

    [Fact]
    public async Task CompleteAsync_changes_status()
    {
        var service = CreateService();

        var id = await service.CreateAsync(new CreateBookingRequest(
            Guid.NewGuid(),
            Guid.NewGuid(),
            DateTime.UtcNow.AddHours(1),
            DateTime.UtcNow.AddHours(2)));

        await service.ConfirmAsync(id);
        await service.CompleteAsync(id);

        var booking = await service.GetAsync(id);

        Assert.Equal(BookingStatus.Completed, booking.Status);
    }

    [Fact]
    public async Task CancelAsync_changes_status()
    {
        var service = CreateService();

        var id = await service.CreateAsync(new CreateBookingRequest(
            Guid.NewGuid(),
            Guid.NewGuid(),
            DateTime.UtcNow.AddHours(1),
            DateTime.UtcNow.AddHours(2)));

        await service.CancelAsync(id);

        var booking = await service.GetAsync(id);

        Assert.Equal(BookingStatus.Cancelled, booking.Status);
    }

    [Fact]
    public async Task GetAsync_throws_if_not_found()
    {
        var service = CreateService();

        await Assert.ThrowsAsync<DomainException>(async () =>
        {
            await service.GetAsync(Guid.NewGuid());
        });
    }

    private static IBookingService CreateService() =>
        new Service();
}