using Microsoft.AspNetCore.Mvc;
using Shared.Interfaces;
using Shared.Models;

namespace TicketApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TicketsController(IGenericService<Tickets> _service) : ControllerBase
{
    // GET: api/Tickets
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Tickets>>> GetAll()
    {
        return await _service.GetAll();
    }

    // GET: api/Tickets/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Tickets>> Get(int id)
    {
        var ticket = await _service.Get(id);

        if (ticket == null)
        {
            return NotFound();
        }

        return ticket;
    }

    // POST: api/Tickets
    [HttpPost]
    public async Task<ActionResult<Tickets>> Post(Tickets ticket)
    {
        var ticketR = await _service.Add(ticket);
        return CreatedAtAction(nameof(Get), new { id = ticketR.TicketId }, ticketR);
    }

    // PUT: api/Tickets/5
    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, Tickets ticket)
    {
        if (id != ticket.TicketId)
        {
            return BadRequest();
        }
        await _service.Update(ticket);

        return NoContent();
    }

    // DELETE: api/Tickets/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var ticket = await _service.Delete(id);
        if (!ticket)
        {
            return NotFound();
        }

        return NoContent();
    }
}