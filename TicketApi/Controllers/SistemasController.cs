using Microsoft.AspNetCore.Mvc;
using Shared.Interfaces;
using Shared.Models;

namespace TicketApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SistemasController(IGenericService<Sistemas> _service) : ControllerBase
{
    // GET: api/Sistemas
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Sistemas>>> GetAll()
    {
        return await _service.GetAll();
    }

    // GET: api/Sistemas/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Sistemas>> Get(int id)
    {
        var sistema = await _service.Get(id);

        if (sistema == null)
        {
            return NotFound();
        }

        return sistema;
    }

    // POST: api/Sistemas
    [HttpPost]
    public async Task<ActionResult<Sistemas>> Post(Sistemas sistema)
    {
        var sistemaR = await _service.Add(sistema);
        return CreatedAtAction(nameof(Get), new { id = sistemaR.SistemaId }, sistemaR);
    }

    // PUT: api/Sistemas/5
    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, Sistemas sistema)
    {
        if (id != sistema.SistemaId)
        {
            return BadRequest();
        }
        await _service.Update(sistema);

        return NoContent();
    }

    // DELETE: api/Sistemas/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var sistema = await _service.Delete(id);
        if (!sistema)
        {
            return NotFound();
        }

        return NoContent();
    }
}