using BookingService.Application.Contracts;
using BookingService.Application.Contracts.Commands;
using BookingService.Application.Contracts.Queries;
using BookingService.Domain.Exceptions;
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
    public async Task<IActionResult> Create([FromBody] CreateBookingRequest request)
    {
        var id = await _mediator.Send(request);
        return Ok(id);
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> Get(Guid id)
    {
        try
        {
            var result = await _mediator.Send(new GetBookingQuery(id));
            return Ok(result);
        }
        catch (DomainException)
        {
            return NotFound();
        }
    }

    [HttpPost("{id:guid}/confirm")]
    public async Task<IActionResult> Confirm(Guid id)
    {
        try
        {
            await _mediator.Send(new ConfirmBookingCommand(id));
            return Ok();
        }
        catch (DomainException)
        {
            return NotFound();
        }
    }

    [HttpPost("{id:guid}/cancel")]
    public async Task<IActionResult> Cancel(Guid id)
    {
        try
        {
            await _mediator.Send(new CancelBookingCommand(id));
            return Ok();
        }
        catch (DomainException)
        {
            return NotFound();
        }
    }

    [HttpPost("{id:guid}/complete")]
    public async Task<IActionResult> Complete(Guid id)
    {
        try
        {
            await _mediator.Send(new CompleteBookingCommand(id));
            return Ok();
        }
        catch (DomainException)
        {
            return NotFound();
        }
    }
}