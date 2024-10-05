using Microsoft.EntityFrameworkCore;
using Shared.Interfaces;
using Shared.Models;
using TicketApi.DAL;

namespace TicketApi.Services;

public class ClientesService(Context _context) : IGenericService<Clientes>
{
    public async Task<Clientes> Get(int id)
    {
        return (await _context.Clientes.FindAsync(id))!;
    }

    public async Task<List<Clientes>> GetAll()
    {
        return await _context.Clientes.ToListAsync();
    }

    public async Task<Clientes> Add(Clientes type)
    {
        _context.Clientes.Add(type);
        await _context.SaveChangesAsync();
        return type;
    }

    public async Task<bool> Update(Clientes type)
    {
        _context.Entry(type).State = EntityState.Modified;
        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<bool> Delete(int id)
    {
        var type = await _context.Clientes.FindAsync(id);
        if (type is null) return false;
        _context.Clientes.Remove(type);
        return await _context.SaveChangesAsync() > 0;
    }
}
