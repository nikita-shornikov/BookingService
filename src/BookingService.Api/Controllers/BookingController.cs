using BookingService.Application.Bookings.Commands;
using BookingService.Application.Bookings.Queries;
using BookingService.Application.Contracts;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BookingService.Api.Controllers;

[ApiController]
[Route("booking")]
public class BookingController : ControllerBase
{
    private readonly IMediator _mediator;

    public BookingController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<ActionResult<Guid>> Create([FromBody] CreateBookingRequest request, CancellationToken cancellationToken)
    {
        var id = await _mediator.Send(new CreateBookingCommand(request), cancellationToken);
        return Ok(id);
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<BookingResponse>> Get(Guid id, CancellationToken cancellationToken)
    {
        var booking = await _mediator.Send(new GetBookingQuery(id), cancellationToken);
        return Ok(booking);
    }

    [HttpPost("{id:guid}/confirm")]
    public async Task<IActionResult> Confirm(Guid id, CancellationToken cancellationToken)
    {
        await _mediator.Send(new ConfirmBookingCommand(id), cancellationToken);
        return NoContent();
    }

    [HttpPost("{id:guid}/complete")]
    public async Task<IActionResult> Complete(Guid id, CancellationToken cancellationToken)
    {
        await _mediator.Send(new CompleteBookingCommand(id), cancellationToken);
        return NoContent();
    }

    [HttpPost("{id:guid}/cancel")]
    public async Task<IActionResult> Cancel(Guid id, CancellationToken cancellationToken)
    {
        await _mediator.Send(new CancelBookingCommand(id), cancellationToken);
        return NoContent();
    }
}