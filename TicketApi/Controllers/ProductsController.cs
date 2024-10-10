using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shared.Interfaces;
using Shared.Models;
using TicketApi.DAL;

namespace TicketApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductsController(IGenericService<Products> _service) : ControllerBase
{
    // GET: api/Products
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Products>>> GetAll()
    {
        return await _service.GetAll();
    }

    // GET: api/Products/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Products>> Get(int id)
    {
        var product = await _service.Get(id);

        if (product == null)
        {
            return NotFound();
        }

        return product;
    }

    // POST: api/Products
    [HttpPost]
    public async Task<ActionResult<Products>> Post(Products product)
    {
        var productR = await _service.Add(product);
        return CreatedAtAction(nameof(Get), new { id = productR.ProductId }, productR);
    }

    // PUT: api/Products/5
    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, Products product)
    {
        if (id != product.ProductId)
        {
            return BadRequest();
        }
        await _service.Update(product);

        return NoContent();
    }

    // DELETE: api/Products/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var product = await _service.Delete(id);
        if (!product)
        {
            return NotFound();
        }

        return NoContent();
    }
}