using Microsoft.AspNetCore.Mvc;
using Shared.Interfaces;
using Shared.Models;

namespace TicketApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ClientesController(IGenericService<Clientes> _service) : ControllerBase
{
    // GET: api/Clientes
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Clientes>>> GetAll()
    {
        return await _service.GetAll();
    }

    // GET: api/Clientes/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Clientes>> Get(int id)
    {
        var cliente = await _service.Get(id);

        if (cliente == null)
        {
            return NotFound();
        }

        return cliente;
    }

    // POST: api/Clientes
    [HttpPost]
    public async Task<ActionResult<Clientes>> Post(Clientes cliente)
    {
        var clienteR = await _service.Add(cliente);
        return CreatedAtAction(nameof(Get), new { id = clienteR.ClienteId }, clienteR);
    }

    // PUT: api/Clientes/5
    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, Clientes cliente)
    {
        if (id != cliente.ClienteId)
        {
            return BadRequest();
        }
        await _service.Update(cliente);

        return NoContent();
    }

    // DELETE: api/Clientes/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var cliente = await _service.Delete(id);
        if (!cliente)
        {
            return NotFound();
        }

        return NoContent();
    }
}