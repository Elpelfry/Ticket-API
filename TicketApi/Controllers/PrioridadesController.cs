using Microsoft.AspNetCore.Mvc;
using Shared.Models;
using Shared.Interfaces;

namespace TicketApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PrioridadesController(IGenericService<Prioridades> _service) : ControllerBase
{
    // GET: api/Prioridades
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Prioridades>>> GetAll()
    {
        return await _service.GetAll();
    }

    // GET: api/Prioridades/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Prioridades>> Get(int id)
    {
        var prioridad = await _service.Get(id);

        if (prioridad == null)
        {
            return NotFound();
        }

        return prioridad;
    }

    // POST: api/Prioridades
    [HttpPost]
    public async Task<ActionResult<Prioridades>> Post(Prioridades prioridad)
    {
        var prioridadR = await _service.Add(prioridad);
        return CreatedAtAction(nameof(Get), new { id = prioridadR.PrioridadId }, prioridadR);
    }

    // PUT: api/Prioridades/5
    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, Prioridades prioridad)
    {
        if (id != prioridad.PrioridadId)
        {
            return BadRequest();
        }
        await _service.Update(prioridad);

        return NoContent();
    }

    // DELETE: api/Prioridades/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var prioridad = await _service.Delete(id);
        if (!prioridad)
        {
            return NotFound();
        }

        return NoContent();
    }
}