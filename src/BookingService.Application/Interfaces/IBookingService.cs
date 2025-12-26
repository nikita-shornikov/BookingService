using BookingService.Application.Contracts;

namespace BookingService.Application.Interfaces;

public interface IBookingService
{
    Task<Guid> CreateAsync(CreateBookingRequest request, CancellationToken cancellationToken = default);
    Task CancelAsync(Guid id, CancellationToken cancellationToken = default);
    Task ConfirmAsync(Guid id, CancellationToken cancellationToken = default);
    Task CompleteAsync(Guid id, CancellationToken cancellationToken = default);
    Task<BookingResponse> GetAsync(Guid id, CancellationToken cancellationToken = default);
}