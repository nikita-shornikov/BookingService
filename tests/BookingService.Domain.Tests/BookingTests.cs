using BookingService.Domain.Entities;
using BookingService.Domain.Enums;
using BookingService.Domain.Exceptions;
using Xunit;

namespace BookingService.Domain.Tests;

public sealed class BookingTests
{
    [Fact]
    public void New_booking_has_Draft_status()
    {
        var booking = CreateDraftBooking();
        Assert.Equal(BookingStatus.Draft, booking.Status);
    }

    [Fact]
    public void Cannot_create_booking_with_invalid_time_range()
    {
        Assert.Throws<DomainException>(() =>
            new Booking(Guid.NewGuid(), Guid.NewGuid(),
                DateTime.UtcNow.AddHours(2), DateTime.UtcNow.AddHours(1)));
    }

    [Fact]
    public void Draft_can_be_confirmed()
    {
        var booking = CreateDraftBooking();
        booking.Confirm();
        Assert.Equal(BookingStatus.Confirmed, booking.Status);
    }

    [Fact]
    public void Cannot_confirm_non_draft()
    {
        var booking = CreateDraftBooking();
        booking.Confirm();
        Assert.Throws<DomainException>(() => booking.Confirm());
    }

    [Fact]
    public void Confirmed_can_be_completed()
    {
        var booking = CreateDraftBooking();
        booking.Confirm();
        booking.Complete();
        Assert.Equal(BookingStatus.Completed, booking.Status);
    }

    [Fact]
    public void Cannot_cancel_completed_booking()
    {
        var booking = CreateDraftBooking();
        booking.Confirm();
        booking.Complete();
        Assert.Throws<DomainException>(() => booking.Cancel());
    }

    private static Booking CreateDraftBooking()
    {
        return new Booking(
            Guid.NewGuid(),
            Guid.NewGuid(),
            DateTime.UtcNow.AddHours(1),
            DateTime.UtcNow.AddHours(2));
    }
}